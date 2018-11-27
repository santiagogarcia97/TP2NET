using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using Util;

namespace UI.Web.admin {
    public partial class Materias : System.Web.UI.Page {
        public enum FormModes { Alta, Baja, Modificacion }
        private Materia _MateriaActual;
        private MateriaLogic _MateriaLogic;
        public FormModes FormMode {
            get { return (FormModes)ViewState["FormMode"]; }
            set { ViewState["FormMode"] = value; }
        }
        public Materia MateriaActual { get => _MateriaActual; set => _MateriaActual = value; }
        private int SelectedID {
            get {
                if (ViewState["SelectedID"] != null) return (int)ViewState["SelectedID"];
                else return 0;
            }
            set {
                ViewState["SelectedID"] = value;
            }
        }
        public MateriaLogic MateriaLogic {
            get {
                if (_MateriaLogic == null) { _MateriaLogic = new MateriaLogic(); }
                return _MateriaLogic;
            }
        }

        protected void Page_Load(object sender, EventArgs e) {
            if (Session["tipo"] == null || (int)Session["tipo"] != 3) {
                Response.Clear();
                Response.StatusCode = 404;
                Response.End();
            }
            else {
                if (SelectedID != 0) MateriaActual = MateriaLogic.GetOne(SelectedID);
                if (!IsPostBack) {
                    Listar();
                    gvMat.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
        }
        private void Listar() {
            List<Materia> mats = MateriaLogic.GetAll().Where(x => x.Habilitado == true).ToList();

            if (mats.Count == 0) {
                divSinMaterias.Visible = true;
            }
            else {
                gvMat.DataSource = Listado.Generar(mats);
                gvMat.DataBind();
                gvMat.SelectedIndex = -1;
                ButtonState();
            }

        }
        private void ClearForm() {
            GenerarEsp(0);
            txtID.Text = "";
            txtDescripcion.Text = string.Empty;
            txtHSSem.Text = 0.ToString();
            txtHSTot.Text = 0.ToString();
            ddPlan.SelectedValue = 0.ToString();
            ddEsp.SelectedValue = 0.ToString();
            modalHeader.Text = "Nueva Materia";
            btnAceptar.Text = "Crear";
            UpdatePanelModal.Update();
        }
        private void EnableForm(bool enable) {
            txtDescripcion.Enabled = enable;
            txtHSSem.Enabled = enable;
            txtHSTot.Enabled = enable;
            ddPlan.Enabled = enable;
            ddEsp.Enabled = enable;
        }
        private void LoadForm(int id) {
            MateriaActual = MateriaLogic.GetOne(id);
            PlanLogic pl = new PlanLogic();
            Plan plan = pl.GetOne(MateriaActual.IDPlan);

            txtID.Text = MateriaActual.ID.ToString();
            txtDescripcion.Text = MateriaActual.Descripcion;
            txtHSSem.Text = MateriaActual.HSSemanales.ToString();
            txtHSTot.Text = MateriaActual.HSTotales.ToString();
            GenerarEsp(plan.IDEspecialidad);
            GenerarPlanes(plan.IDEspecialidad, MateriaActual.IDPlan);
            ddEsp.SelectedValue = plan.IDEspecialidad.ToString();
            ddPlan.SelectedValue = MateriaActual.IDPlan.ToString();

            if (this.FormMode == FormModes.Baja) {
                modalHeader.Text = "Eliminar Materia";
                btnAceptar.Text = "Eliminar";
            }
            else if (this.FormMode == FormModes.Modificacion) {
                modalHeader.Text = "Editar Materia";
                btnAceptar.Text = "Guardar";
            }
            UpdatePanelModal.Update();
        }

        private void LoadEntity() {
            MateriaActual.Descripcion = txtDescripcion.Text;
            MateriaActual.HSSemanales = int.Parse(txtHSSem.Text);
            MateriaActual.HSTotales = int.Parse(txtHSTot.Text);
            MateriaActual.IDPlan = Int32.Parse(ddPlan.SelectedValue);
        }
        private void SaveEntity() {
            MateriaLogic.Save(MateriaActual);
        }
        private void ButtonState() {

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
        protected void gvMat_SelectedIndexChanged(object sender, EventArgs e) {
            SelectedID = (gvMat.SelectedValue != null) ? (int)gvMat.SelectedValue : 0;
            ButtonState();
        }

        protected void btnNuevo_Click(object sender, EventArgs e) {
            this.FormMode = FormModes.Alta;
            SetFormControlCSS();
            ClearForm();
            EnableForm(true);
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#ModalMaterias').modal('show');", true);
        }

        protected void btnEditar_Click(object sender, EventArgs e) {
            SetFormControlCSS();
            EnableForm(true);
            FormMode = FormModes.Modificacion;
            LoadForm(this.SelectedID);
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#ModalMaterias').modal('show');", true);
        }


        protected void btnEliminar_Click(object sender, EventArgs e) {
            FormMode = FormModes.Baja;
            SetFormControlCSS();
            EnableForm(false);
            LoadForm(this.SelectedID);
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#ModalMaterias').modal('show');", true);
        }

        protected void btnDeseleccionar_Click(object sender, EventArgs e) {
            gvMat.SelectedIndex = -1;
            gvMat_SelectedIndexChanged(sender, e);
            UpdatePanelGrid.Update();
        }

        protected void btnAceptar_Click(object sender, EventArgs e) {
            if (Validar() == true) {
                switch (FormMode) {
                    case FormModes.Baja:
                        MateriaActual = new Materia {
                            ID = SelectedID,
                            State = BusinessEntity.States.Deleted
                        };
                        break;
                    case FormModes.Modificacion:
                        MateriaActual = new Materia {
                            ID = SelectedID,
                            Habilitado = true,
                            State = BusinessEntity.States.Modified
                        };
                        LoadEntity();
                        break;
                    case FormModes.Alta:
                        MateriaActual = new Materia {
                            Habilitado = true,
                            State = BusinessEntity.States.New
                        };
                        LoadEntity();
                        break;
                }
                SaveEntity();
                SelectedID = 0;
                Listar();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#ModalMaterias').modal('hide');", true);
                UpdatePanelGrid.Update();
            }
            UpdatePanelModal.Update();
        }
        private bool Validar() {
            bool isvalid = true;

            if (Validaciones.ValTexto(txtDescripcion.Text)) txtDescripcion.CssClass = "form-control";
            else {
                txtDescripcion.CssClass = "form-control is-invalid";
                isvalid = false;
            }
            if (Validaciones.ValTexto(txtHSSem.Text) && int.Parse(txtHSSem.Text) != 0) txtHSSem.CssClass = "form-control";
            else {
                txtHSSem.CssClass = "form-control is-invalid";
                isvalid = false;
            }
            if (Validaciones.ValTexto(txtHSTot.Text) && int.Parse(txtHSTot.Text) != 0) txtHSSem.CssClass = "form-control";
            else {
                txtHSTot.CssClass = "form-control is-invalid";
                isvalid = false;
            }
            if (ddEsp.SelectedValue == string.Empty || int.Parse(ddEsp.SelectedValue) == 0) {
                ddEsp.CssClass = "form-control is-invalid";
                isvalid = false;
            }
            else {
                ddEsp.CssClass = "form-control";
            }
            if (ddPlan.SelectedValue == string.Empty || int.Parse(ddPlan.SelectedValue) == 0) {
                ddPlan.CssClass = "form-control is-invalid";
                isvalid = false;
            }
            else {
                ddPlan.CssClass = "form-control";
            }

            return isvalid;
        }

        private void SetFormControlCSS() {
            txtDescripcion.CssClass = "form-control";
            txtHSSem.CssClass = "form-control";
            txtHSTot.CssClass = "form-control";
            ddEsp.CssClass = "form-control";
            ddPlan.CssClass = "form-control";
        }

        protected void ddEsp_SelectedIndexChanged(object sender, EventArgs e) {
            if (FormMode == FormModes.Alta) GenerarPlanes(int.Parse(ddEsp.SelectedValue), 0);
            else GenerarPlanes(int.Parse(ddEsp.SelectedValue), MateriaActual.IDPlan);
        }
        protected void GenerarPlanes(int idEsp, int idPlanActual) {
            ddPlan.DataValueField = "id_plan";
            ddPlan.DataTextField = "desc_plan";
            ddPlan.DataSource = GenerarComboBox.getPlanes(idEsp, idPlanActual);
            ddPlan.DataBind();
            ddPlan.SelectedValue = 0.ToString();
            UpdatePanelModal.Update();
        }
        protected void GenerarEsp(int idEspActual)
        {
            ddEsp.DataValueField = "id_esp";
            ddEsp.DataTextField = "desc_esp";
            ddEsp.DataSource = GenerarComboBox.getEspecialidades(idEspActual);
            ddEsp.DataBind();
        }
    }
}