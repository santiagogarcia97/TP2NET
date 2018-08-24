using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop {
    public partial class UsuarioDesktop : ApplicationForm {

        private Business.Entities.Usuario _usuarioActual;
        public Usuario UsuarioActual { get => _usuarioActual; set => _usuarioActual = value; }

        public UsuarioDesktop() {
            InitializeComponent();
            GenerarTipoPersona();
            GenerarEsp();
        }

        public UsuarioDesktop(ModoForm modo):this() {
            Modo = modo;
        }

        public UsuarioDesktop(int ID, ModoForm modo) : this() {
            Modo = modo;
            UsuarioLogic ul = new UsuarioLogic();
            UsuarioActual = ul.GetOne(ID);
            MapearDeDatos();
        }

        public override void MapearDeDatos() {
            chkHabilitado.Checked = UsuarioActual.Habilitado;
            labelID.Text = UsuarioActual.ID.ToString();
            labelLegajo.Text = UsuarioActual.Legajo.ToString();
            txtNombre.Text = UsuarioActual.Nombre.ToString();
            txtApellido.Text = UsuarioActual.Apellido.ToString();
            txtFechaNac.Text = UsuarioActual.FechaNacimiento.ToString();
            txtDirec.Text = UsuarioActual.Direccion.ToString();
            txtTel.Text = UsuarioActual.Telefono.ToString();
            txtEmail.Text = UsuarioActual.Email.ToString();
            txtNombreUsuario.Text = UsuarioActual.NombreUsuario.ToString();
            txtClave.Text = UsuarioActual.Clave.ToString();
            cbxTipo.SelectedValue = UsuarioActual.TipoPersona;

            PlanLogic pl = new PlanLogic();
            Plan plan = pl.GetOne(UsuarioActual.IDPlan);
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
            }
            else {
                btnAceptar.Text = "Guardar";
            }
        }

        public override void MapearADatos() {
            if(Modo == ModoForm.Alta || Modo == ModoForm.Modificacion) {
                UsuarioActual = new Usuario();
                UsuarioActual.Habilitado = chkHabilitado.Checked;
                UsuarioActual.ID = Int32.Parse(labelID.Text);
                UsuarioActual.Legajo = Int32.Parse(labelLegajo.Text);
                UsuarioActual.Nombre = txtNombre.Text;
                UsuarioActual.Apellido = txtApellido.Text;
                UsuarioActual.FechaNacimiento = DateTime.Parse(txtFechaNac.Text);
                UsuarioActual.Direccion = txtDirec.Text;
                UsuarioActual.Telefono = txtTel.Text;
                UsuarioActual.Email = txtEmail.Text;
                UsuarioActual.NombreUsuario = txtNombreUsuario.Text;
                UsuarioActual.Clave = txtClave.Text;

                UsuarioActual.State = (Modo == ModoForm.Alta) ? BusinessEntity.States.New : BusinessEntity.States.Modified;
            }
            else {
                UsuarioActual.State = BusinessEntity.States.Deleted;
            }
        }

        public override void GuardarCambios() {
            MapearADatos();
            UsuarioLogic ul = new UsuarioLogic();
            ul.Save(UsuarioActual);
        }

        public override bool Validar() {
            return !(                                     //Si cualquiera de estas condiciones es verdadera, retorna false
            string.IsNullOrEmpty(txtNombreUsuario.Text) ||
            string.IsNullOrEmpty(txtClave.Text) ||
            (txtClave.Text != txtClave.Text));
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
            if (Validar()) {
                GuardarCambios();
                this.Close();
            }
            else {
                MessageBox.Show("Complete todos los campos y compruebe que las claves sean iguales.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void cbxEsp_SelectedValueChanged(object sender, EventArgs e) {
            GenerarPlanes(Int32.Parse(cbxEsp.SelectedValue.ToString()));
        }
    }
}
