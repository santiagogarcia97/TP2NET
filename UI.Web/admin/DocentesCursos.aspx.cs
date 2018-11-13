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
    public partial class DocentesCursos : System.Web.UI.Page {
        public enum FormModes { Alta, Baja, Modificacion }
        private DocenteCurso _DocenteCursoActual;
        private DocenteCursoLogic _DocenteCursoLogic;
        public FormModes FormMode {
            get { return (FormModes)ViewState["FormMode"]; }
            set { ViewState["FormMode"] = value; }
        }
        public DocenteCurso DocenteCursoActual { get => _DocenteCursoActual; set => _DocenteCursoActual = value; }
        private int SelectedID {
            get {
                if (ViewState["SelectedID"] != null) return (int)ViewState["SelectedID"];
                else return 0;
            }
            set {
                ViewState["SelectedID"] = value;
            }
        }
        public DocenteCursoLogic DocenteCursoLogic {
            get {
                if (_DocenteCursoLogic == null) { _DocenteCursoLogic = new DocenteCursoLogic(); }
                return _DocenteCursoLogic;
            }
        }

        protected void Page_Load(object sender, EventArgs e) {
            if (Session["tipo"] == null || (int)Session["tipo"] != 3) {
                Response.Clear();
                Response.StatusCode = 404;
                Response.End();
            }
            else {
                if (!IsPostBack) {
                    Listar();
                    GenerarCargos();
                    if(SelectedID != 0) {
                        DocenteCursoActual = DocenteCursoLogic.GetOne(SelectedID);
                        GenerarCursos(DocenteCursoActual.IDCurso);
                        GenerarDocentes(DocenteCursoActual.IDDocente);
                    }
                    else {
                        GenerarCursos(0);
                        GenerarDocentes(0);
                    }

                }
            }
        }
        private void Listar() {
            List<DocenteCurso> dclist = DocenteCursoLogic.GetAll().Where(x => x.Habilitado == true).ToList();

            if (dclist.Count == 0) {
                divSinDC.Visible = true;
            }
            else {
                gvDC.DataSource = Listado.Generar(dclist);
                gvDC.DataBind();
                gvDC.SelectedIndex = -1;
                ButtonState();
            }
        }
        private void ClearForm() {
            txtID.Text = "";
            ddCurso.SelectedValue = 0.ToString();
            ddDocente.SelectedValue = 0.ToString();
            ddCargo.SelectedValue = 0.ToString();
            modalHeader.Text = "Nuevo Docente - Curso";
            btnAceptar.Text = "Crear";
            UpdatePanelModal.Update();
        }
        private void EnableForm(bool enable) {
            ddCargo.Enabled = enable;
            ddCurso.Enabled = enable;
            ddDocente.Enabled = enable;
        }
        private void LoadForm(int id) {
            DocenteCursoActual = DocenteCursoLogic.GetOne(id);
            GenerarCursos(DocenteCursoActual.IDCurso);
            GenerarDocentes(DocenteCursoActual.IDDocente);

            txtID.Text = DocenteCursoActual.ID.ToString();
            ddCargo.SelectedValue = ((int)DocenteCursoActual.Cargo).ToString();
            ddCurso.SelectedValue = DocenteCursoActual.IDCurso.ToString();
            ddDocente.SelectedValue = DocenteCursoActual.IDDocente.ToString();

            if (this.FormMode == FormModes.Baja) {
                modalHeader.Text = "Eliminar Docente - Curso";
                btnAceptar.Text = "Eliminar";
            }
            else if (this.FormMode == FormModes.Modificacion) {
                modalHeader.Text = "Editar Docente - Curso";
                btnAceptar.Text = "Guardar";
            }
            UpdatePanelModal.Update();
        }

        private void LoadEntity() {
            DocenteCursoActual.IDCurso = int.Parse(ddCurso.SelectedValue);
            DocenteCursoActual.IDDocente = int.Parse(ddDocente.SelectedValue);
            DocenteCursoActual.Cargo = (DocenteCurso.TipoCargos)int.Parse(ddCargo.SelectedValue);
        }
        private void SaveEntity() {
            DocenteCursoLogic.Save(DocenteCursoActual);
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
        protected void gvDC_SelectedIndexChanged(object sender, EventArgs e) {
            SelectedID = (gvDC.SelectedValue != null) ? (int)gvDC.SelectedValue : 0;
            ButtonState();
        }

        protected void btnNuevo_Click(object sender, EventArgs e) {
            this.FormMode = FormModes.Alta;
            SetFormControlCSS();
            ClearForm();
            EnableForm(true);
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#ModalDocentesCursos').modal('show');", true);
        }

        protected void btnEditar_Click(object sender, EventArgs e) {
            SetFormControlCSS();
            EnableForm(true);
            FormMode = FormModes.Modificacion;
            LoadForm(this.SelectedID);
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#ModalDocentesCursos').modal('show');", true);
        }


        protected void btnEliminar_Click(object sender, EventArgs e) {
            FormMode = FormModes.Baja;
            SetFormControlCSS();
            EnableForm(false);
            LoadForm(this.SelectedID);
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#ModalDocentesCursos').modal('show');", true);
        }

        protected void btnDeseleccionar_Click(object sender, EventArgs e) {
            gvDC.SelectedIndex = -1;
            gvDC_SelectedIndexChanged(sender, e);
            UpdatePanelGrid.Update();
        }

        protected void btnAceptar_Click(object sender, EventArgs e) {
            if (Validar() == true) {
                switch (FormMode) {
                    case FormModes.Baja:
                        DocenteCursoActual = new DocenteCurso {
                            ID = SelectedID,
                            State = BusinessEntity.States.Deleted
                        };
                        break;
                    case FormModes.Modificacion:
                        DocenteCursoActual = new DocenteCurso {
                            ID = SelectedID,
                            Habilitado = true,
                            State = BusinessEntity.States.Modified
                        };
                        LoadEntity();
                        break;
                    case FormModes.Alta:
                        DocenteCursoActual = new DocenteCurso {
                            Habilitado = true,
                            State = BusinessEntity.States.New
                        };
                        LoadEntity();
                        break;
                }
                SaveEntity();
                SelectedID = 0;
                Listar();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#ModalDocentesCursos').modal('hide');", true);
                UpdatePanelGrid.Update();
            }
            UpdatePanelModal.Update();
        }
        private bool Validar() {
            bool isvalid = true;

            if (ddCargo.SelectedValue == string.Empty || int.Parse(ddCargo.SelectedValue) == 0) {
                ddCargo.CssClass = "form-control is-invalid";
                isvalid = false;
            }
            else {
                ddCargo.CssClass = "form-control";
            }
            if (ddCurso.SelectedValue == string.Empty || int.Parse(ddCurso.SelectedValue) == 0) {
                ddCurso.CssClass = "form-control is-invalid";
                isvalid = false;
            }
            else {
                ddCurso.CssClass = "form-control";
            }
            if (ddDocente.SelectedValue == string.Empty || int.Parse(ddDocente.SelectedValue) == 0) {
                ddDocente.CssClass = "form-control is-invalid";
                isvalid = false;
            }
            else {
                ddDocente.CssClass = "form-control";
            }

            return isvalid;
        }

        private void SetFormControlCSS() {
            ddCargo.CssClass = "form-control";
            ddCurso.CssClass = "form-control";
            ddDocente.CssClass = "form-control";
        }

        protected void GenerarDocentes(int idDocActual) {
            ddDocente.DataValueField = "id_docente";
            ddDocente.DataTextField = "desc_docente";
            ddDocente.DataSource = GenerarComboBox.getDocentes(idDocActual);
            ddDocente.DataBind();
            ddDocente.SelectedValue = 0.ToString();
            UpdatePanelModal.Update();
        }
        protected void GenerarCursos(int idCurActual) {
            ddCurso.DataValueField = "id_curso";
            ddCurso.DataTextField = "desc_curso";
            ddCurso.DataSource = GenerarComboBox.getCursos(idCurActual);
            ddCurso.DataBind();
            ddCurso.SelectedValue = 0.ToString();
            UpdatePanelModal.Update();
        }
        protected void GenerarCargos() {
            ddCargo.DataValueField = "id_cargo";
            ddCargo.DataTextField = "desc_cargo";
            ddCargo.DataSource = GenerarComboBox.getCargos();
            ddCargo.DataBind();
            ddCargo.SelectedValue = 0.ToString();
            UpdatePanelModal.Update();
        }
    }
}