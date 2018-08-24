using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;
using Business.Logic;
using Business.Entities;
using System.Globalization;
using Util;

namespace UI.Desktop {
    public partial class UsuarioDesktop : ApplicationForm {

        private Business.Entities.Usuario _usuarioActual;
        public Usuario UsuarioActual { get => _usuarioActual; set => _usuarioActual = value; }

        public UsuarioDesktop() {
            InitializeComponent();

            lblRedAp.Visible = false;
            lblRedClave.Visible = false;
            lblRedDirec.Visible = false;
            lblRedEmail.Visible = false;
            lblRedNac.Visible = false;
            lblRedNom.Visible = false;
            lblRedPlan.Visible = false;
            lblRedTel.Visible = false;
            lblRedTipo.Visible = false;
            lblRedUser.Visible = false;

            GenerarTipoPersona();
            GenerarEsp();
        }

        public UsuarioDesktop(ModoForm modo):this() {
            Modo = modo;
            btnAceptar.Text = "Crear";
            labelID.Text = "-";
            labelLegajo.Text = "-";
            chkHabilitado.Checked = true;
        }

        public UsuarioDesktop(int ID, ModoForm modo) : this() {
            Modo = modo;
            UsuarioLogic ul = new UsuarioLogic();
            UsuarioActual = ul.GetOne(ID);

            PlanLogic pl = new PlanLogic();
            Plan plan = pl.GetOne(UsuarioActual.IDPlan);

            GenerarPlanes(plan.IDEspecialidad);

            MapearDeDatos(plan);
        }

        public void MapearDeDatos(Plan plan) {
            chkHabilitado.Checked = UsuarioActual.Habilitado;
            labelID.Text = UsuarioActual.ID.ToString();
            labelLegajo.Text = UsuarioActual.Legajo.ToString();
            txtNombre.Text = UsuarioActual.Nombre.ToString();
            txtApellido.Text = UsuarioActual.Apellido.ToString();
            txtFechaNac.Text = UsuarioActual.FechaNacimiento.ToString("dd/MM/yyyy");
            txtDirec.Text = UsuarioActual.Direccion.ToString();
            txtTel.Text = UsuarioActual.Telefono.ToString();
            txtEmail.Text = UsuarioActual.Email.ToString();
            txtNombreUsuario.Text = UsuarioActual.NombreUsuario.ToString();
            txtClave.Text = UsuarioActual.Clave.ToString();
            cbxTipo.SelectedValue = UsuarioActual.TipoPersona;
            cbxEsp.SelectedValue = plan.IDEspecialidad;
            cbxPlan.SelectedValue = UsuarioActual.IDPlan;


            if (Modo == ApplicationForm.ModoForm.Baja) {
                btnAceptar.Text = "Eliminar";
                chkHabilitado.Enabled = false;
                txtNombre.ReadOnly = true;
                txtApellido.ReadOnly = true;
                txtFechaNac.ReadOnly = true;
                txtDirec.ReadOnly = true;
                txtTel.ReadOnly = true;
                txtEmail.ReadOnly = true;
                txtNombreUsuario.ReadOnly = true;
                txtClave.ReadOnly = true;
                cbxTipo.Enabled = false;
                cbxEsp.Enabled = false;
                cbxPlan.Enabled = false;
            }
            else {
                btnAceptar.Text = "Guardar";
            }
        }

        public override void MapearADatos() {
            if(Modo == ModoForm.Alta || Modo == ModoForm.Modificacion) {
                UsuarioActual = new Usuario();
                UsuarioActual.Habilitado = chkHabilitado.Checked;
                UsuarioActual.Nombre = txtNombre.Text;
                UsuarioActual.Apellido = txtApellido.Text;
                DateTime dt;
                DateTime.TryParseExact(txtFechaNac.Text, Util.Validar.FormatosFecha, null, DateTimeStyles.None, out dt);
                UsuarioActual.FechaNacimiento = dt;
                UsuarioActual.Direccion = txtDirec.Text;
                UsuarioActual.Telefono = txtTel.Text;
                UsuarioActual.Email = txtEmail.Text;
                UsuarioActual.NombreUsuario = txtNombreUsuario.Text;
                UsuarioActual.Clave = txtClave.Text;
                UsuarioActual.TipoPersona = Int32.Parse(cbxTipo.SelectedValue.ToString());
                UsuarioActual.IDPlan = Int32.Parse(cbxPlan.SelectedValue.ToString());

                if (Modo == ModoForm.Alta) {
                    UsuarioActual.State = BusinessEntity.States.New;
                }
                else if (Modo == ModoForm.Modificacion) {
                    UsuarioActual.State = BusinessEntity.States.Modified;
                    UsuarioActual.ID = Int32.Parse(labelID.Text);
                    UsuarioActual.Legajo = Int32.Parse(labelLegajo.Text);
                }
            }
            else {
                UsuarioActual.State = BusinessEntity.States.Deleted;
            }
        }
        private void GenerarTipoPersona() {
            DataTable dtTiposPersona = new DataTable();

            dtTiposPersona.Columns.Add("tipo_persona", typeof(int));
            dtTiposPersona.Columns.Add("desc_tipo", typeof(string));

            dtTiposPersona.Rows.Add(new object[] { 1, "Alumno" });
            dtTiposPersona.Rows.Add(new object[] { 2, "Docente" });
            dtTiposPersona.Rows.Add(new object[] { 3, "Administrativo" });

            cbxTipo.ValueMember = "tipo_persona";
            cbxTipo.DisplayMember = "desc_tipo";
            cbxTipo.DataSource = dtTiposPersona;
        }
        private void GenerarEsp() {
            DataTable dtEspecialidades = new DataTable();
            dtEspecialidades.Columns.Add("id_esp", typeof(int));
            dtEspecialidades.Columns.Add("desc_esp", typeof(string));
            EspecialidadLogic el = new EspecialidadLogic();
            List<Especialidad> especialidades = el.GetAll();
            foreach (Especialidad esp in especialidades) {
                dtEspecialidades.Rows.Add(new object[] { esp.ID, esp.Descripcion });
            }

            cbxEsp.ValueMember = "id_esp";
            cbxEsp.DisplayMember = "desc_esp";
            cbxEsp.DataSource = dtEspecialidades;
        }
        private void GenerarPlanes(int idEsp) {
            DataTable dtPlanes = new DataTable();
            dtPlanes.Columns.Add("id_plan", typeof(int));
            dtPlanes.Columns.Add("desc_plan", typeof(string));
            PlanLogic pl = new PlanLogic();
            List<Plan> planes = pl.GetAll();
            foreach(Plan plan in planes) {
                if(plan.IDEspecialidad == idEsp) {
                    dtPlanes.Rows.Add(new object[] { plan.ID, plan.Descripcion });
                }
            }
            cbxPlan.ValueMember = "id_plan";
            cbxPlan.DisplayMember = "desc_plan";
            cbxPlan.DataSource = dtPlanes;
        }
        private void btnAceptar_Click(object sender, EventArgs e) {
            if (this.Validar() == true) {
                GuardarCambios();
                this.Close();
            }
            else {
                MessageBox.Show("Verifique los datos ingresados");
            }
        }
        public override void GuardarCambios() {
            MapearADatos();
            UsuarioLogic ul = new UsuarioLogic();
            ul.Save(UsuarioActual);
        }
        public override bool Validar() {
            lblRedAp.Visible = (string.IsNullOrWhiteSpace(txtApellido.Text)) ? true : false;
            lblRedClave.Visible = (string.IsNullOrWhiteSpace(txtClave.Text)) ? true : false;
            lblRedDirec.Visible = (string.IsNullOrWhiteSpace(txtDirec.Text)) ? true : false;
            lblRedNom.Visible = (string.IsNullOrWhiteSpace(txtNombre.Text)) ? true : false;
            lblRedTel.Visible = (string.IsNullOrWhiteSpace(txtTel.Text)) ? true : false;
            lblRedUser.Visible = (string.IsNullOrWhiteSpace(txtNombreUsuario.Text)) ? true : false;
            lblRedTipo.Visible = (cbxTipo.SelectedValue == null) ? true : false;
            lblRedPlan.Visible = (cbxEsp.SelectedValue == null || cbxPlan.SelectedValue == null) ? true : false;
            lblRedEmail.Visible = (new EmailAddressAttribute().IsValid(txtEmail.Text)) ? false : true;
            DateTime dt;
            lblRedNac.Visible = (DateTime.TryParseExact(txtFechaNac.Text, Util.Validar.FormatosFecha , null, DateTimeStyles.None, out dt) == true) ? false : true;

            if (lblRedAp.Visible == true ||
            lblRedClave.Visible == true ||
            lblRedDirec.Visible == true ||
            lblRedEmail.Visible == true ||
            lblRedNac.Visible == true ||
            lblRedNom.Visible == true ||
            lblRedPlan.Visible == true ||
            lblRedTel.Visible == true ||
            lblRedTipo.Visible == true ||
            lblRedUser.Visible == true) {
                return false;
            }
            else {
                return true;
            }
        }

        private void cbxEsp_SelectedValueChanged(object sender, EventArgs e) {
            if (cbxEsp.SelectedValue != null) {
                GenerarPlanes(Int32.Parse(cbxEsp.SelectedValue.ToString()));
            }
        }

    }
}
