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

        public FormModes FormMode {
            get { return (FormModes)ViewState["FormMode"]; }
            set { ViewState["FormMode"] = value; }
        }

        private Usuario Entity {
            get;
            set;
        }

        private int SelectedID {
            get {
                if (ViewState["SelectedID"] != null) return (int)ViewState["SelectedID"];
                else return 0;
            }
            set {
                ViewState["SelectedID"] = value;
            }
        }


        private bool IsEntitySelected {
            get { return (SelectedID != 0); }
        }

        private UsuarioLogic _logic;
        private UsuarioLogic Logic {
            get {
                if (_logic == null) _logic = new UsuarioLogic();
                return _logic;
            }
        }

        private void LoadGrid() {

            gridView.DataSource = Logic.GetAll();
            gridView.DataBind();
        }


        protected void Page_Load(object sender, EventArgs e) {
            LoadGrid();

        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e) {
            SelectedID = (int)gridView.SelectedValue;
        }

        private void LoadForm(int id) {
            Entity = Logic.GetOne(id);
            IDLabel.Text = "ID: " + id.ToString();
            nombreTextBox.Text = Entity.Nombre;
            apellidoTextBox.Text = Entity.Apellido;
            emailTextBox.Text = Entity.Email;
            habilitadoCheckBox.Checked = Entity.Habilitado;
            nombreUsuarioTextBox.Text = Entity.NombreUsuario;
            fechaTextBox.Text = Entity.FechaNacimiento.ToString("dd/MM/yyyy");
            LegajoTextBox.Text = Entity.Legajo.ToString();
            direccionTextBox.Text = Entity.Direccion;
            telefonoTextBox.Text = Entity.Telefono;
            GenerarEsp();

            PlanLogic pl = new PlanLogic();
            Plan plan = pl.GetOne(Entity.IDPlan);
            GenerarPlanes(plan.IDEspecialidad);
        }

        private void GenerarEsp() {
            DataTable dtEspecialidades = GenerarComboBox.getEspecialidades();
            especialidadDDL.DataValueField = "id_esp";
            especialidadDDL.DataTextField = "desc_esp";
            especialidadDDL.DataSource = dtEspecialidades;
            especialidadDDL.DataBind();
        }
        private void GenerarPlanes(int idEsp) {
            DataTable dtPlanes = GenerarComboBox.getPlanes(idEsp);
            planDDL.DataValueField = "id_plan";
            planDDL.DataTextField = "desc_plan";
            planDDL.DataSource = dtPlanes;
            planDDL.DataBind();
        }


        protected void editarLinkButton_Click(object sender, EventArgs e) {
            if (IsEntitySelected) {
                EnableForm(true);
                formPanel.Visible = true;
                FormMode = FormModes.Modificacion;
                LoadForm(SelectedID);
                GenerarEsp();
            }
        }
        private void LoadEntity(Usuario usuario) {
            usuario.Nombre = nombreTextBox.Text;
            usuario.Apellido = apellidoTextBox.Text;
            usuario.Email = emailTextBox.Text;
            usuario.NombreUsuario = nombreUsuarioTextBox.Text;
            usuario.Clave = claveTextBox.Text;
            usuario.Habilitado = habilitadoCheckBox.Checked;
            usuario.Direccion = direccionLabel.Text;
            DateTime dt;
            DateTime.TryParseExact(fechaTextBox.Text, Util.Validar.FormatosFecha, null, DateTimeStyles.None, out dt);
            usuario.FechaNacimiento = dt;
            usuario.Legajo = int.Parse(LegajoTextBox.Text);
            usuario.Telefono = telefonoTextBox.Text;
            usuario.TipoPersona = int.Parse(tipoDDL.SelectedValue);
            usuario.IDPlan = int.Parse(planDDL.SelectedValue);
        }

        private void SaveEntity(Usuario usuario) {
            Logic.Save(usuario);
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e) {
            if (Validar()) {
                switch (FormMode) {
                    case FormModes.Baja:
                        Entity.State = BusinessEntity.States.Deleted;
                        SaveEntity(Entity);
                        LoadGrid();
                        break;
                    case FormModes.Modificacion:
                        Entity = new Usuario();
                        Entity.ID = SelectedID;
                        Entity.State = BusinessEntity.States.Modified;
                        LoadEntity(Entity);
                        SaveEntity(Entity);
                        LoadGrid();
                        break;
                    case FormModes.Alta:
                        Entity = new Usuario();
                        Entity.State = BusinessEntity.States.New;
                        LoadEntity(Entity);
                        SaveEntity(Entity);
                        LoadGrid();
                        break;
                    default:
                        break;
                }
                formPanel.Visible = false;
            }
        }

        protected bool Validar() {
            lblRedAp.Visible = (string.IsNullOrWhiteSpace(apellidoTextBox.Text)) ? true : false;
            lblRedClave.Visible = (string.IsNullOrWhiteSpace(claveTextBox.Text)) ? true : false;
            lblRedDirec.Visible = (string.IsNullOrWhiteSpace(direccionTextBox.Text)) ? true : false;
            lblRedNom.Visible = (string.IsNullOrWhiteSpace(nombreTextBox.Text)) ? true : false;
            lblRedTel.Visible = (string.IsNullOrWhiteSpace(telefonoTextBox.Text)) ? true : false;
            lblRedUser.Visible = (string.IsNullOrWhiteSpace(nombreUsuarioTextBox.Text)) ? true : false;
            lblRedTipo.Visible = (tipoDDL.SelectedValue == null) ? true : false;
            lblRedPlan.Visible = (especialidadDDL.SelectedValue == null || planDDL.SelectedValue == null) ? true : false;
            lblRedEmail.Visible = (new EmailAddressAttribute().IsValid(emailTextBox.Text)) ? false : true;
            DateTime dt;
            lblRedNac.Visible = (DateTime.TryParseExact(fechaTextBox.Text, Util.Validar.FormatosFecha, null, DateTimeStyles.None, out dt) == true) ? false : true;
            legajoValidator.Validate();
            telefonoValidator.Validate();

            return !(lblRedAp.Visible ||
                     lblRedClave.Visible ||
                     lblRedDirec.Visible ||
                     lblRedEmail.Visible ||
                     lblRedNac.Visible ||
                     lblRedNom.Visible ||
                     lblRedPlan.Visible ||
                     lblRedTel.Visible ||
                     lblRedTipo.Visible ||
                     lblRedUser.Visible ||
                     !legajoValidator.IsValid ||
                     !telefonoValidator.IsValid);
        }

        protected void especialidadDDL_SelectedIndexChanged(object sender, EventArgs e) {
            GenerarPlanes(Int32.Parse(especialidadDDL.SelectedValue.ToString()));
        }

        private void EnableForm(bool enable) {
            nombreTextBox.Enabled = enable;
            apellidoTextBox.Enabled = enable;
            emailTextBox.Enabled = enable;
            nombreUsuarioTextBox.Enabled = enable;
            claveTextBox.Enabled = enable;
            LegajoTextBox.Enabled = enable;
            habilitadoCheckBox.Enabled = enable;
            fechaTextBox.Enabled = enable;
            direccionTextBox.Enabled = enable;
            telefonoTextBox.Enabled = enable;
            tipoDDL.Enabled = enable;
            especialidadDDL.Enabled = enable;
            planDDL.Enabled = enable;
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e) {
            if (this.IsEntitySelected) {
                formPanel.Visible = true;
                FormMode = FormModes.Baja;
                EnableForm(false);
                LoadForm(this.SelectedID);
            }
        }


        protected void nuevoLinkButton_Click(object sender, EventArgs e) {
            formPanel.Visible = true;
            FormMode = FormModes.Alta;
            ClearForm();
            EnableForm(true);
        }

        private void ClearForm() {
            IDLabel.Text = "ID: -";
            nombreTextBox.Text = string.Empty;
            apellidoTextBox.Text = string.Empty;
            emailTextBox.Text = string.Empty;
            nombreUsuarioTextBox.Text = string.Empty;
            claveTextBox.Text = string.Empty;
            habilitadoCheckBox.Text = string.Empty;
            fechaTextBox.Text = string.Empty;
            direccionTextBox.Text = string.Empty;
            telefonoTextBox.Text = string.Empty;
            LegajoTextBox.Text = string.Empty;
            GenerarEsp();
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e) {
            formPanel.Visible = false;
        }
    }
}