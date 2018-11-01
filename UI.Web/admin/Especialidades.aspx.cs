using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Business.Entities;
using Business.Logic;

namespace UI.Web.admin {
    public partial class Especialidades : System.Web.UI.Page {
        public enum FormModes { Alta, Baja, Modificacion }
        private Especialidad _EspecialidadActual;
        private EspecialidadLogic _EspecialidadLogic;
        public FormModes FormMode {
            get { return (FormModes)ViewState["FormMode"]; }
            set { ViewState["FormMode"] = value; }
        }
        public Especialidad EspecialidadActual { get => _EspecialidadActual; set => _EspecialidadActual = value; }
        private int SelectedID {
            get {
                if (ViewState["SelectedID"] != null) return (int)ViewState["SelectedID"];
                else return 0;
            }
            set {
                ViewState["SelectedID"] = value;
            }
        }
        public EspecialidadLogic EspecialidadLogic {
            get {
                if (_EspecialidadLogic == null) { _EspecialidadLogic = new EspecialidadLogic(); }
                return _EspecialidadLogic;
            }
        }

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                Listar();
                gvEspecialidades.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        private void Listar() {
            EspecialidadLogic el = new EspecialidadLogic();
            gvEspecialidades.DataSource = el.GetListado();
            gvEspecialidades.DataBind();
            gvEspecialidades.SelectedIndex = -1;
            algo();
        }
        private void ClearForm() {
            inputID.Text = "";
            txtDescripcion.Text = string.Empty;
            modalHeader.Text = "Nueva Especialidad";
            btnAceptar.Text = "Crear";
            UpdatePanelModal.Update();
        }
        private void EnableForm(bool enable) {
            txtDescripcion.Enabled = enable;
        }
        private void LoadForm(int id) {
            EspecialidadActual = EspecialidadLogic.GetOne(id);
            inputID.Text = EspecialidadActual.ID.ToString();
            txtDescripcion.Text = EspecialidadActual.Descripcion;
            if (this.FormMode == FormModes.Baja) {
                modalHeader.Text = "Eliminar Especialidad";
                btnAceptar.Text = "Eliminar";
            }
            else if (this.FormMode == FormModes.Modificacion) {
                modalHeader.Text = "Editar Especialidad";
                btnAceptar.Text = "Guardar";
            }
            UpdatePanelModal.Update();
        }

        private void LoadEntity() {
            EspecialidadActual.Descripcion = txtDescripcion.Text;
        }
        private void SaveEntity(Especialidad especialidad) {
            EspecialidadLogic.Save(especialidad);
        }
        private void algo() {

            if (SelectedID == 0) {
                btnEditar.CssClass = "btn btn-outline-secondary btn-sm";
                btnEditar.Enabled = false;
                btnEliminar.CssClass = "btn btn-outline-secondary btn-sm";
                btnEliminar.Enabled = false;
                btnDeseleccionar.Visible = false;
            }
            else {
                btnEditar.CssClass = "btn btn-outline-success btn-sm";
                btnEditar.Enabled = true;
                btnEliminar.CssClass = "btn btn-outline-success btn-sm";
                btnEliminar.Enabled = true;
                btnDeseleccionar.Visible = true;
            }
            UpdatePanelButtons.Update();
        }
        private bool Validar() {
            lblRedDesc.Visible = (string.IsNullOrEmpty(txtDescripcion.Text) ||
                                    string.IsNullOrWhiteSpace(txtDescripcion.Text)) ? true : false;
            return !lblRedDesc.Visible;
        }
        protected void gvEspecialidades_SelectedIndexChanged(object sender, EventArgs e) {
            SelectedID = (gvEspecialidades.SelectedValue != null) ? (int)gvEspecialidades.SelectedValue : 0;
            algo();

        }

        protected void btnNuevo_Click(object sender, EventArgs e) {
            this.FormMode = FormModes.Alta;
            ClearForm();
            EnableForm(true);
            lblRedDesc.Visible = false;
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#ModalEspecialidad').modal('show');", true);
        }

        protected void btnEditar_Click(object sender, EventArgs e) {
            EnableForm(true);
            FormMode = FormModes.Modificacion;
            LoadForm(this.SelectedID);
            lblRedDesc.Visible = false;
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#ModalEspecialidad').modal('show');", true);
        }
      

        protected void btnEliminar_Click(object sender, EventArgs e) {
            FormMode = FormModes.Baja;
            EnableForm(false);
            LoadForm(this.SelectedID);
            lblRedDesc.Visible = false;
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#ModalEspecialidad').modal('show');", true);
        }

        protected void btnDeseleccionar_Click(object sender, EventArgs e) {
            gvEspecialidades.SelectedIndex = -1;
            gvEspecialidades_SelectedIndexChanged(sender, e);
            UpdatePanelGrid.Update();
        }

        protected void btnAceptar_Click(object sender, EventArgs e) {
            if (Validar() == true) {
                switch (FormMode) {
                    case FormModes.Baja:
                        EspecialidadActual = new Especialidad();
                        EspecialidadActual.ID = SelectedID;
                        EspecialidadActual.State = BusinessEntity.States.Deleted;
                        break;
                    case FormModes.Modificacion:
                        EspecialidadActual = new Especialidad {
                            ID = SelectedID,
                            Habilitado = true,
                            State = BusinessEntity.States.Modified
                        };
                        LoadEntity();
                        break;
                    case FormModes.Alta:
                        EspecialidadActual = new Especialidad {
                            State = BusinessEntity.States.New,
                            Descripcion = txtDescripcion.Text,
                            Habilitado = true
                        };
                        break;
                }
                SaveEntity(EspecialidadActual);
                SelectedID = 0;
                Listar();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#ModalEspecialidad').modal('hide');", true);
            }
            {
                UpdatePanelGrid.Update();
                UpdatePanelModal.Update();
            }

        }
    }
}