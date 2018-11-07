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
    public partial class Cursos : System.Web.UI.Page {
        public enum FormModes { Alta, Baja, Modificacion }
        private Curso _CursoActual;
        private CursoLogic _CursoLogic;
        public FormModes FormMode {
            get { return (FormModes)ViewState["FormMode"]; }
            set { ViewState["FormMode"] = value; }
        }
        public Curso CursoActual { get => _CursoActual; set => _CursoActual = value; }
        private int SelectedID {
            get {
                if (ViewState["SelectedID"] != null) return (int)ViewState["SelectedID"];
                else return 0;
            }
            set {
                ViewState["SelectedID"] = value;
            }
        }
        public CursoLogic CursoLogic {
            get {
                if (_CursoLogic == null) { _CursoLogic = new CursoLogic(); }
                return _CursoLogic;
            }
        }

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                Listar();
                gvCursos.HeaderRow.TableSection = TableRowSection.TableHeader;
                ddEsp.DataValueField = "id_esp";
                ddEsp.DataTextField = "desc_esp";
                ddEsp.DataSource = GenerarComboBox.getEspecialidades();
                ddEsp.DataBind();
            }
        }
        private void Listar() {
            Usuario user = new Usuario();
            user.TipoPersona = 3;

            gvCursos.DataSource = CursoLogic.GetListado(user);
            gvCursos.DataBind();
            gvCursos.SelectedIndex = -1;
            ButtonState();
        }
        private void ClearForm() {
            txtID.Text = "";
            txtAnio.Text = DateTime.Today.Year.ToString();
            ddPlan.SelectedValue = 0.ToString();
            ddEsp.SelectedValue = 0.ToString();
            ddCom.SelectedValue = 0.ToString();
            ddMat.SelectedValue = 0.ToString();
            txtCupo.Text = 0.ToString();
            modalHeader.Text = "Nuevo Curso";
            btnAceptar.Text = "Crear";
            UpdatePanelModal.Update();
        }
        private void EnableForm(bool enable) {
            txtCupo.Enabled = enable;
            txtAnio.Enabled = enable;
            ddPlan.Enabled = enable;
            ddEsp.Enabled = enable;
            ddMat.Enabled = enable;
            ddCom.Enabled = enable;
        }
        private void LoadForm(int id) {
            CursoActual = CursoLogic.GetOne(id);
            MateriaLogic ml = new MateriaLogic();
            Materia mat = ml.GetOne(CursoActual.IDMateria);
            PlanLogic pl = new PlanLogic();
            Plan plan = pl.GetOne(mat.IDPlan);

            txtID.Text = CursoActual.ID.ToString();
            txtCupo.Text = CursoActual.Cupo.ToString();
            txtAnio.Text = CursoActual.AnioCalendario.ToString();
            ddEsp.SelectedValue = plan.IDEspecialidad.ToString();
            GenerarPlanes(plan.IDEspecialidad);
            ddPlan.SelectedValue = mat.IDPlan.ToString();
            GenerarMaterias(plan.ID);
            GenerarComisiones(plan.ID);
            ddCom.SelectedValue = CursoActual.IDComision.ToString();
            ddMat.SelectedValue = CursoActual.IDMateria.ToString();

            if (this.FormMode == FormModes.Baja) {
                modalHeader.Text = "Eliminar Curso";
                btnAceptar.Text = "Eliminar";
            }
            else if (this.FormMode == FormModes.Modificacion) {
                modalHeader.Text = "Editar Curso";
                btnAceptar.Text = "Guardar";
            }
            UpdatePanelModal.Update();
        }

        private void LoadEntity() {
            CursoActual.AnioCalendario = int.Parse(txtAnio.Text);
            CursoActual.Cupo = int.Parse(txtCupo.Text);
            CursoActual.IDComision = Int32.Parse(ddCom.SelectedValue);
            CursoActual.IDMateria = Int32.Parse(ddMat.SelectedValue);
        }
        private void SaveEntity() {
            CursoLogic.Save(CursoActual);
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
        protected void gvCursos_SelectedIndexChanged(object sender, EventArgs e) {
            SelectedID = (gvCursos.SelectedValue != null) ? (int)gvCursos.SelectedValue : 0;
            ButtonState();
        }

        protected void btnNuevo_Click(object sender, EventArgs e) {
            this.FormMode = FormModes.Alta;
            SetFormControlCSS();
            ClearForm();
            EnableForm(true);
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#ModalCursos').modal('show');", true);
        }

        protected void btnEditar_Click(object sender, EventArgs e) {
            SetFormControlCSS();
            EnableForm(true);
            FormMode = FormModes.Modificacion;
            LoadForm(this.SelectedID);
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#ModalCursos').modal('show');", true);
        }


        protected void btnEliminar_Click(object sender, EventArgs e) {
            FormMode = FormModes.Baja;
            SetFormControlCSS();
            EnableForm(false);
            LoadForm(this.SelectedID);
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#ModalCursos').modal('show');", true);
        }

        protected void btnDeseleccionar_Click(object sender, EventArgs e) {
            gvCursos.SelectedIndex = -1;
            gvCursos_SelectedIndexChanged(sender, e);
            UpdatePanelGrid.Update();
        }

        protected void btnAceptar_Click(object sender, EventArgs e) {
            if (Validar() == true) {
                switch (FormMode) {
                    case FormModes.Baja:
                        CursoActual = new Curso {
                            ID = SelectedID,
                            State = BusinessEntity.States.Deleted
                        };
                        break;
                    case FormModes.Modificacion:
                        CursoActual = new Curso {
                            ID = SelectedID,
                            Habilitado = true,
                            State = BusinessEntity.States.Modified
                        };
                        LoadEntity();
                        break;
                    case FormModes.Alta:
                        CursoActual = new Curso {
                            Habilitado = true,
                            State = BusinessEntity.States.New
                        };
                        LoadEntity();
                        break;
                }
                SaveEntity();
                SelectedID = 0;
                Listar();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#ModalCursos').modal('hide');", true);
                UpdatePanelGrid.Update();
            }
            UpdatePanelModal.Update();
        }
        private bool Validar() {
            bool isvalid = true;

            if (string.IsNullOrEmpty(txtAnio.Text) ||
                 string.IsNullOrWhiteSpace(txtAnio.Text) ||
                 int.Parse(txtAnio.Text) == 0) {
                txtAnio.CssClass = "form-control is-invalid";
                isvalid = false;
            }
            else {
                txtAnio.CssClass = "form-control";
            }
            if (string.IsNullOrEmpty(txtCupo.Text) ||
                string.IsNullOrWhiteSpace(txtCupo.Text) ||
                int.Parse(txtCupo.Text) == 0) {
                txtCupo.CssClass = "form-control is-invalid";
                isvalid = false;
            }
            else {
                txtCupo.CssClass = "form-control";
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
            if (ddCom.SelectedValue == string.Empty || int.Parse(ddCom.SelectedValue) == 0) {
                ddCom.CssClass = "form-control is-invalid";
                isvalid = false;
            }
            else {
                ddCom.CssClass = "form-control";
            }
            if (ddMat.SelectedValue == string.Empty || int.Parse(ddMat.SelectedValue) == 0) {
                ddMat.CssClass = "form-control is-invalid";
                isvalid = false;
            }
            else {
                ddMat.CssClass = "form-control";
            }

            return isvalid;
        }

        private void SetFormControlCSS() {
            txtCupo.CssClass = "form-control";
            txtAnio.CssClass = "form-control";
            ddEsp.CssClass = "form-control";
            ddPlan.CssClass = "form-control";
            ddCom.CssClass = "form-control";
            ddMat.CssClass = "form-control";
        }

        protected void ddEsp_SelectedIndexChanged(object sender, EventArgs e) {
            GenerarPlanes(int.Parse(ddEsp.SelectedValue));
        }
        protected void ddPlan_SelectedIndexChanged(object sender, EventArgs e) {
            GenerarComisiones(int.Parse(ddPlan.SelectedValue));
            GenerarMaterias(int.Parse(ddPlan.SelectedValue));
        }
        protected void GenerarPlanes(int idEsp) {
            ddPlan.DataValueField = "id_plan";
            ddPlan.DataTextField = "desc_plan";
            ddPlan.DataSource = GenerarComboBox.getPlanes(idEsp);
            ddPlan.DataBind();
            ddPlan.SelectedValue = 0.ToString();
            UpdatePanelModal.Update();
        }
        protected void GenerarMaterias(int idPlan) {
            ddMat.DataValueField = "id_mat";
            ddMat.DataTextField = "desc_mat";
            ddMat.DataSource = GenerarComboBox.getMaterias(idPlan);
            ddMat.DataBind();
            ddMat.SelectedValue = 0.ToString();
            UpdatePanelModal.Update();
        }
        protected void GenerarComisiones(int idPlan) {
            ddCom.DataValueField = "id_com";
            ddCom.DataTextField = "desc_com";
            ddCom.DataSource = GenerarComboBox.getComisiones(idPlan);
            ddCom.DataBind();
            ddCom.SelectedValue = 0.ToString();
            UpdatePanelModal.Update();
        }
    }
}