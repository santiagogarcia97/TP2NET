using System;
using System.Collections.Generic;
using System.Data;

using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

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
        }

        private void SaveEntity(Usuario usuario) {
            Logic.Save(usuario);
        }

        protected void aceptarLinkButton_Click(object sender,EventArgs e) {
            Entity = new Usuario();
            Entity.ID = SelectedID;
            Entity.State = BusinessEntity.States.Modified;
            LoadEntity(Entity);
            SaveEntity(Entity);
            LoadGrid();
            formPanel.Visible = false;
        }

        protected void especialidadDDL_SelectedIndexChanged(object sender,EventArgs e) {
            GenerarPlanes(Int32.Parse(especialidadDDL.SelectedValue.ToString()));
        }
    }
}