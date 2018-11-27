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
                if (SelectedID != 0) UsuarioActual = UserLogic.GetOne(SelectedID);
                if (!IsPostBack) {
                    Listar();
                    gvUsuarios.HeaderRow.TableSection = TableRowSection.TableHeader;
                    GenerarEsp(0);
                    GenerarTipos();
                }
            }
        }
        private void Listar()
        {
            List<Usuario> users = UserLogic.GetAll().Where(x => x.Habilitado == true).ToList();

            if (users.Count == 0) {
                divSinUsers.Visible = true;
            }
            else {
                gvUsuarios.DataSource = Listado.Generar(users);
                gvUsuarios.DataBind();
                gvUsuarios.SelectedIndex = -1;
                ButtonState();
            }
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

            GenerarEsp(plan.IDEspecialidad);
            GenerarPlanes(plan.IDEspecialidad, UsuarioActual.IDPlan);
            ddEsp.SelectedValue = plan.IDEspecialidad.ToString();
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

        private void LoadEntity()
        {
            UsuarioActual.Nombre = txtNombre.Text;
            UsuarioActual.Apellido = txtApellido.Text;

            DateTime dt;
            DateTime.TryParseExact(txtFechaNac.Text, Util.Validaciones.FormatosFecha, null, DateTimeStyles.None, out dt);
            UsuarioActual.FechaNacimiento = dt;
            UsuarioActual.Direccion = txtDirec.Text;
            UsuarioActual.Telefono = txtTel.Text;
            UsuarioActual.Email = txtEmail.Text;
            UsuarioActual.NombreUsuario = txtUser.Text;
            UsuarioActual.TipoPersona = (Usuario.TiposPersona)int.Parse(ddTipo.SelectedValue);
            UsuarioActual.IDPlan = int.Parse(ddPlan.SelectedValue);

            if (FormMode == FormModes.Alta) UsuarioActual.Clave = Hashing.HashPassword(txtPass.Text);

        }
        private void SaveEntity()
        {
            UserLogic.Save(UsuarioActual);
        }
        private void ButtonState()
        {

            if (SelectedID == 0) {
                btnEditar.CssClass = "btn btn-outline-secondary btn-sm";
                btnEditar.Enabled = false;
                btnEliminar.CssClass = "btn btn-outline-secondary btn-sm";
                btnEliminar.Enabled = false;
                btnCambiaPass.CssClass = "btn btn-outline-secondary btn-sm";
                btnCambiaPass.Enabled = false;
                btnDeseleccionar.Visible = false;
            }
            else {
                btnEditar.CssClass = "btn btn-outline-success btn-sm";
                btnEditar.Enabled = true;
                btnEliminar.CssClass = "btn btn-outline-success btn-sm";
                btnEliminar.Enabled = true;
                btnCambiaPass.CssClass = "btn btn-outline-success btn-sm";
                btnCambiaPass.Enabled = true;
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
            SelectedID = 0;
            SetFormControlCSS();
            divPass.Visible = true;
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

 
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            FormMode = FormModes.Baja;
            SetFormControlCSS();
            LoadForm();
            EnableForm(false);
            UpdatePanelModal.Update();
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#ModalUsuarios').modal('show');", true);
        }

       protected void btnDeseleccionar_Click(object sender, EventArgs e)
        {
            gvUsuarios.SelectedIndex = -1;
            gvUsuarios_SelectedIndexChanged(sender, e);
            UpdatePanelGrid.Update();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar() == true) {
                switch (FormMode) {
                    case FormModes.Baja:
                        UsuarioActual = new Usuario {
                            ID = SelectedID,
                            State = BusinessEntity.States.Deleted
                        };
                        break;
                    case FormModes.Modificacion:
                        UsuarioActual = new Usuario {
                            ID = SelectedID,
                            Habilitado = true,
                            State = BusinessEntity.States.Modified
                        };
                        break;
                    case FormModes.Alta:
                        UsuarioActual = new Usuario {
                            Habilitado = true,
                            State = BusinessEntity.States.New
                        };
                        break;
                }
                LoadEntity();
                SaveEntity();
                SelectedID = 0;
                Listar();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#ModalUsuarios').modal('hide');", true);
                UpdatePanelGrid.Update();
            }
            else {
                UpdatePanelModal.Update();
            }
        }
        private bool Validar() {
            bool isvalid = true;
            UsuarioActual = UserLogic.GetOne(SelectedID);

            if (!Validaciones.ValTexto(txtNombre.Text)) {
                txtNombre.CssClass = "form-control is-invalid";
                isvalid = false;
            }
            else txtNombre.CssClass = "form-control";

            if (!Validaciones.ValTexto(txtApellido.Text)) {
                txtApellido.CssClass = "form-control is-invalid";
                isvalid = false;
            }
            else txtApellido.CssClass = "form-control";

            if (!Validaciones.ValFecha(txtFechaNac.Text)) {
                txtFechaNac.CssClass = "form-control is-invalid";
                isvalid = false;
            }
            else txtFechaNac.CssClass = "form-control";

            if (!Validaciones.ValTexto(txtDirec.Text)) {
                txtDirec.CssClass = "form-control is-invalid";
                isvalid = false;
            }
            else txtDirec.CssClass = "form-control";

            if (!Validaciones.ValTexto(txtTel.Text)) {
                txtTel.CssClass = "form-control is-invalid";
                isvalid = false;
            }
            else txtTel.CssClass = "form-control";

            if (!Validaciones.ValEmail(txtEmail.Text)) {
                txtEmail.CssClass = "form-control is-invalid";
                isvalid = false;
            }
            else txtEmail.CssClass = "form-control";

            if (Validaciones.ValTexto(txtUser.Text) && Validaciones.ValUsername(txtUser.Text)) {
                if (FormMode == FormModes.Alta && Validaciones.ValUsernameExists(txtUser.Text)) {
                    txtUser.CssClass = "form-control";
                }
                else if (FormMode == FormModes.Modificacion) {
                    Usuario aux = UserLogic.GetOne(int.Parse(lblID.Text));
                    if (aux.NombreUsuario.Equals(txtUser.Text) || !Validaciones.ValUsernameExists(txtUser.Text)) txtUser.CssClass = "form-control";
                    else {
                        txtUser.CssClass = "form-control is-invalid";
                        isvalid = false;
                    }
                }
                else {
                    txtUser.CssClass = "form-control is-invalid";
                    isvalid = false;
                }
            }
            else {
                txtUser.CssClass = "form-control is-invalid";
                isvalid = false;
            }



            if (int.Parse(ddTipo.SelectedValue)==0) {
                ddTipo.CssClass = "form-control is-invalid";
                isvalid = false;
            }
            else ddTipo.CssClass = "form-control";

            if (int.Parse(ddEsp.SelectedValue) == 0) {
                ddEsp.CssClass = "form-control is-invalid";
                isvalid = false;
            }
            else ddEsp.CssClass = "form-control";

            if (ddPlan.SelectedValue == string.Empty || int.Parse(ddPlan.SelectedValue) == 0) {
                ddPlan.CssClass = "form-control is-invalid";
                isvalid = false;
            }
            else ddPlan.CssClass = "form-control";

            return isvalid;
        }

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

        protected void ddEsp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FormMode == FormModes.Alta) GenerarPlanes(int.Parse(ddEsp.SelectedValue), 0);
            else GenerarPlanes(int.Parse(ddEsp.SelectedValue), UsuarioActual.IDPlan);
        }

        protected void GenerarPlanes(int idEsp, int idPlanActual)
        {
            ddPlan.DataValueField = "id_plan";
            ddPlan.DataTextField = "desc_plan";
            ddPlan.DataSource = GenerarComboBox.getPlanes(idEsp, idPlanActual);
            ddPlan.DataBind();
            ddPlan.SelectedValue = 0.ToString();
            UpdatePanelPlan.Update();
        }
        protected void GenerarEsp(int idEspActual)
        {
            ddEsp.DataValueField = "id_esp";
            ddEsp.DataTextField = "desc_esp";
            ddEsp.DataSource = GenerarComboBox.getEspecialidades(idEspActual);
            ddEsp.DataBind();
        }
        protected void GenerarTipos()
        {
            ddTipo.DataValueField = "tipo_persona";
            ddTipo.DataTextField = "desc_tipo";
            ddTipo.DataSource = GenerarComboBox.getTiposPersona();
            ddTipo.DataBind();
            ddTipo.SelectedValue = 0.ToString();
        }

        protected void btnCambiaPass_Click(object sender, EventArgs e)
        {
            txtNuevaPass1.Text = string.Empty;
            txtNuevaPass2.Text = string.Empty;
            txtNuevaPass1.CssClass = "form-control";
            txtNuevaPass2.CssClass = "form-control";
            UpdatePanelCambiaPass.Update();
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#ModalPass').modal('show');", true);
        }

        protected void btnGuardarPass_Click(object sender, EventArgs e)
        {
            if (txtNuevaPass1.Text.Equals(txtNuevaPass2.Text) && Validaciones.ValClave(txtNuevaPass1.Text)) {
                UsuarioActual = UserLogic.GetOne(SelectedID);
                UsuarioActual.Clave = Hashing.HashPassword(txtNuevaPass1.Text);
                UserLogic.SavePassword(UsuarioActual);
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#ModalPass').modal('hide');", true);
            }
            else {
                txtNuevaPass1.CssClass = "form-control is-invalid";
                txtNuevaPass2.CssClass = "form-control is-invalid";
            }
            UpdatePanelCambiaPass.Update();
        }
    }
}