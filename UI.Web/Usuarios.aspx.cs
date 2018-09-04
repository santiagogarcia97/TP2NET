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


namespace UI.Web {
    public partial class Usuarios : System.Web.UI.Page {

        public enum FormModes { Alta, Baja, Modificacion}

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
                if(_logic == null) _logic = new UsuarioLogic();
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
            DataTable dtEspecialidades = new DataTable();
            dtEspecialidades.Columns.Add("id_esp",typeof(int));
            dtEspecialidades.Columns.Add("desc_esp",typeof(string));
            EspecialidadLogic el = new EspecialidadLogic();
            List<Especialidad> especialidades = el.GetAll();
            foreach(Especialidad esp in especialidades) {
                dtEspecialidades.Rows.Add(new object[] { esp.ID,esp.Descripcion });
            }

            especialidadDDL.DataValueField = "id_esp";
            especialidadDDL.DataTextField = "desc_esp";
            especialidadDDL.DataSource = dtEspecialidades;
            especialidadDDL.DataBind();
        }
        private void GenerarPlanes(int idEsp) {
            DataTable dtPlanes = new DataTable();
            dtPlanes.Columns.Add("id_plan",typeof(int));
            dtPlanes.Columns.Add("desc_plan",typeof(string));
            PlanLogic pl = new PlanLogic();
            List<Plan> planes = pl.GetAll();
            foreach(Plan plan in planes) {
                if(plan.IDEspecialidad == idEsp) {
                    dtPlanes.Rows.Add(new object[] { plan.ID,plan.Descripcion });
                }
            }
            planDDL.DataValueField = "id_plan";
            planDDL.DataTextField = "desc_plan";
            planDDL.DataSource = dtPlanes;
            planDDL.DataBind();
        }


        protected void editarLinkButton_Click(object sender, EventArgs e) {
            if(IsEntitySelected) {
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
            DateTime.TryParseExact(fechaTextBox.Text,Util.Validar.FormatosFecha,null,DateTimeStyles.None,out dt);
            usuario.FechaNacimiento = dt;
            usuario.Legajo = int.Parse(LegajoTextBox.Text);
            usuario.Telefono = telefonoTextBox.Text;
            usuario.TipoPersona = int.Parse(tipoDDL.SelectedValue);
            usuario.IDPlan = int.Parse(planDDL.SelectedValue);

        }

        private void SaveEntity(Usuario usuario) {
            Logic.Save(usuario);
        }

        protected void aceptarLinkButton_Click(object sender,EventArgs e) {
            switch(FormMode) {
                case FormModes.Baja:
                    Entity.State = BusinessEntity.States.Deleted;
                    DeleteEntity(SelectedID);
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

        protected void especialidadDDL_SelectedIndexChanged(object sender,EventArgs e) {
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
            repetirClaveTextBox.Enabled = enable;
            fechaTextBox.Enabled = enable;
            direccionTextBox.Enabled = enable;
            telefonoTextBox.Enabled = enable;
            tipoDDL.Enabled = enable;
            especialidadDDL.Enabled = enable;
            planDDL.Enabled = enable;
        }

        protected void eliminarLinkButton_Click(object sender,EventArgs e) {
            if(this.IsEntitySelected) {
                formPanel.Visible = true;
                FormMode = FormModes.Baja;
                EnableForm(false);
                LoadForm(this.SelectedID);
            }
        }

        private void DeleteEntity(int id) {
            Logic.Delete(id);
        }

        protected void nuevoLinkButton_Click(object sender,EventArgs e) {
            formPanel.Visible = true;
            FormMode = FormModes.Alta;
            ClearForm();
            EnableForm(true);
        }

        private void ClearForm() {
            nombreTextBox.Text = string.Empty;
            apellidoTextBox.Text = string.Empty;
            emailTextBox.Text = string.Empty;
            nombreUsuarioTextBox.Text = string.Empty;
            claveTextBox.Text = string.Empty;
            habilitadoCheckBox.Text = string.Empty;
            repetirClaveTextBox.Text = string.Empty;
            fechaTextBox.Text = string.Empty;
            direccionTextBox.Text = string.Empty;
            telefonoTextBox.Text = string.Empty;
            LegajoTextBox.Text = string.Empty;
            GenerarEsp();
        }
    }
}