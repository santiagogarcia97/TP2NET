using System;
using System.Collections.Generic;
using System.Data;
using Util;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using System.Globalization;
using System.ComponentModel.DataAnnotations;


namespace UI.Web {
    public partial class Usuarios : System.Web.UI.Page {

        public enum FormModes { Alta, Baja, Modificacion }
        private Usuario _UsuarioActual;
        private UsuarioLogic _UserLogic;
        public FormModes FormMode {
            get { return (FormModes)ViewState["FormMode"]; }
            set { ViewState["FormMode"] = value; }
        }
        public Usuario UsuarioActual { get => _UsuarioActual; set => _UsuarioActual = value; }

        private int SelectedID {
            get {
                if (ViewState["SelectedID"] != null) return (int)ViewState["SelectedID"];
                else return 0;
            }
            set {
                ViewState["SelectedID"] = value;
            }
        }

        public UsuarioLogic UserLogic {
            get {
                if (_UserLogic == null) { _UserLogic = new UsuarioLogic(); }
                return _UserLogic;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["tipo"] == null || (int)Session["tipo"] != 3) {
                Response.Clear();
                Response.StatusCode = 404;
                Response.End();
            }
            else {
                if (!IsPostBack) {
                    Listar();
                    gvUsuarios.HeaderRow.TableSection = TableRowSection.TableHeader;
                    GenerarEsp();
                    GenerarTipos();
                }
            }
        }
        private void Listar()
        {
            List<Usuario> users = UserLogic.GetAll();

            gvUsuarios.DataSource = Listado.Generar(users);
            gvUsuarios.DataBind();
            gvUsuarios.SelectedIndex = -1;
 //           ButtonState();
        }
        private void ClearForm()
        {
            lblID.Text = "-";
            lblLegajo.Text = "-";
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtFechaNac.Text = string.Empty;
            txtDirec.Text = string.Empty;
            txtTel.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtUser.Text = string.Empty;
            txtPass.Text = string.Empty;
            ddTipo.SelectedValue = 0.ToString();
            ddPlan.SelectedValue = 0.ToString();
            ddEsp.SelectedValue = 0.ToString();

            modalHeader.Text = "Nuevo Usuario";
            btnAceptar.Text = "Guardar";
        }
       private void EnableForm(bool enable)
        {
            txtNombre.Enabled = enable;
            txtApellido.Enabled = enable;
            txtFechaNac.Enabled = enable;
            txtDirec.Enabled = enable;
            txtTel.Enabled = enable;
            txtEmail.Enabled = enable;
            txtUser.Enabled = enable;
            txtPass.Enabled = enable;
            ddTipo.Enabled = enable;
            ddPlan.Enabled = enable;
            ddEsp.Enabled = enable;
        }
         private void LoadForm()
        {
            UsuarioActual = UserLogic.GetOne(SelectedID);
            PlanLogic pl = new PlanLogic();
            Plan plan = pl.GetOne(UsuarioActual.IDPlan);

            lblID.Text = UsuarioActual.ID.ToString();
            lblLegajo.Text = UsuarioActual.Legajo.ToString();
            txtNombre.Text = UsuarioActual.Nombre;
            txtApellido.Text = UsuarioActual.Apellido;
            txtFechaNac.Text = UsuarioActual.FechaNacimiento.ToString("dd/MM/yyyy");
            txtDirec.Text = UsuarioActual.Direccion;
            txtTel.Text = UsuarioActual.Telefono;
            txtEmail.Text = UsuarioActual.Email;
            txtUser.Text = UsuarioActual.NombreUsuario;

            divPass.Visible = false;

            ddTipo.SelectedValue = ((int)UsuarioActual.TipoPersona).ToString();
            ddEsp.SelectedValue = plan.IDEspecialidad.ToString();
            GenerarPlanes(plan.IDEspecialidad);
            ddPlan.SelectedValue = UsuarioActual.IDPlan.ToString();

            if (this.FormMode == FormModes.Baja) {
                modalHeader.Text = "Eliminar Usuario";
                btnAceptar.Text = "Eliminar";
            }
            else if (this.FormMode == FormModes.Modificacion) {
                modalHeader.Text = "Editar Usuario";
                btnAceptar.Text = "Guardar";
            }
        }
/*
        private void LoadEntity()
        {
            CursoActual.AnioCalendario = int.Parse(txtAnio.Text);
            CursoActual.Cupo = int.Parse(txtCupo.Text);
            CursoActual.IDComision = Int32.Parse(ddCom.SelectedValue);
            CursoActual.IDMateria = Int32.Parse(ddMat.SelectedValue);
        }
        private void SaveEntity()
        {
            CursoLogic.Save(CursoActual);
        }*/
        private void ButtonState()
        {

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
        protected void gvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedID = (gvUsuarios.SelectedValue != null) ? (int)gvUsuarios.SelectedValue : 0;
            ButtonState();
        }

       protected void btnNuevo_Click(object sender, EventArgs e)
        {
            this.FormMode = FormModes.Alta;
            SetFormControlCSS();
            ClearForm();
            EnableForm(true);
            UpdatePanelModal.Update();
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#ModalUsuarios').modal('show');", true);
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            SetFormControlCSS();
            EnableForm(true);
            FormMode = FormModes.Modificacion;
            LoadForm();
            UpdatePanelModal.Update();
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#ModalUsuarios').modal('show');", true);
        }

/* 
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            FormMode = FormModes.Baja;
            SetFormControlCSS();
            EnableForm(false);
            LoadForm(this.SelectedID);
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#ModalCursos').modal('show');", true);
        }

        protected void btnDeseleccionar_Click(object sender, EventArgs e)
        {
            gvCursos.SelectedIndex = -1;
            gvCursos_SelectedIndexChanged(sender, e);
            UpdatePanelGrid.Update();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
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
        private bool Validar()
        {
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
*/
        private void SetFormControlCSS()
        {
            txtNombre.CssClass = "form-control";
            txtApellido.CssClass = "form-control";
            txtFechaNac.CssClass = "form-control";
            txtDirec.CssClass = "form-control";
            txtTel.CssClass = "form-control";
            txtEmail.CssClass = "form-control";
            txtPass.CssClass = "form-control";
            txtUser.CssClass = "form-control";
            ddTipo.CssClass = "form-control";
            ddEsp.CssClass = "form-control";
            ddPlan.CssClass = "form-control";
        }
/*
        protected void ddEsp_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerarPlanes(int.Parse(ddEsp.SelectedValue));
        }
        protected void ddPlan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }*/
        protected void GenerarPlanes(int idEsp)
        {
            ddPlan.DataValueField = "id_plan";
            ddPlan.DataTextField = "desc_plan";
            ddPlan.DataSource = GenerarComboBox.getPlanes(idEsp);
            ddPlan.DataBind();
            ddPlan.SelectedValue = 0.ToString();
        }
        protected void GenerarEsp()
        {
            ddEsp.DataValueField = "id_esp";
            ddEsp.DataTextField = "desc_esp";
            ddEsp.DataSource = GenerarComboBox.getEspecialidades();
            ddEsp.DataBind();
            ddPlan.SelectedValue = 0.ToString();
        }
        protected void GenerarTipos()
        {
            ddTipo.DataValueField = "tipo_persona";
            ddTipo.DataTextField = "desc_tipo";
            ddTipo.DataSource = GenerarComboBox.getTiposPersona();
            ddTipo.DataBind();
            ddTipo.SelectedValue = 0.ToString();
        }
    }
}