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
            this.GenerarTipoPersona();

            //Se genera el comobox de especialidades
            //getEspecialidades devuelve un DataTable con un columna de ID y otra de Descripcion
            //La de ID se usa como valor interno al seleccionar una opcion y la Desc es la que se muestra al usuario
            cbxEsp.ValueMember = "id_esp";
            cbxEsp.DisplayMember = "desc_esp";
            cbxEsp.DataSource = GenerarComboBox.getEspecialidades();
        }

        public UsuarioDesktop(ModoForm modo):this() {
            Modo = modo;
            btnAceptar.Text = "Crear";
            labelID.Text = "-";
            UsuarioLogic ul = new UsuarioLogic();
            labelLegajo.Text = ul.getNewLegajo().ToString();
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
            //El plan se pasa como argumento para tener el id de la especilidad y seleccionarlo en el combobox
        }

        private void UsuarioDesktop_Load(object sender, EventArgs e) {
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
                UsuarioActual.Legajo = Int32.Parse(labelLegajo.Text);
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
                UsuarioActual.TipoPersona = (int)cbxTipo.SelectedValue;
                UsuarioActual.IDPlan = (int)cbxPlan.SelectedValue;

                if (Modo == ModoForm.Alta) {
                    UsuarioActual.State = BusinessEntity.States.New;
                }
                else if (Modo == ModoForm.Modificacion) {
                    UsuarioActual.State = BusinessEntity.States.Modified;
                    UsuarioActual.ID = Int32.Parse(labelID.Text);
                }
            }
            else {
                UsuarioActual.State = BusinessEntity.States.Deleted;
            }
        }
        private void GenerarTipoPersona() {
            //Se genera el comobox de personas el funcionamiento es igual al de especialidades
            cbxTipo.ValueMember = "tipo_persona";
            cbxTipo.DisplayMember = "desc_tipo";
            cbxTipo.DataSource = GenerarComboBox.getTiposPersona();
        }
        private void GenerarPlanes(int idEsp) {
            //Se genera el comobox de planes el funcionamiento es igual al de especialidades solo que se pasa
            //el id de la esp para filtrar los planes de dicha esp
            cbxPlan.ValueMember = "id_plan";
            cbxPlan.DisplayMember = "desc_plan";
            cbxPlan.DataSource = GenerarComboBox.getPlanes(idEsp);
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

            return !(lblRedAp.Visible ||
                     lblRedClave.Visible ||
                     lblRedDirec.Visible ||
                     lblRedEmail.Visible ||
                     lblRedNac.Visible ||
                     lblRedNom.Visible ||
                     lblRedPlan.Visible ||
                     lblRedTel.Visible ||
                     lblRedTipo.Visible ||
                     lblRedUser.Visible);
        }

        private void cbxEsp_SelectedValueChanged(object sender, EventArgs e) {
            cbxPlan.Text = "";
            if (cbxEsp.SelectedValue != null) {
                //Si el valor del combobox de especialidades cambia, se vuelven a generar los planes
                //pasando como argumento el id de la especialidad para mostrar solo los planes que
                //corresponden a dicha especialidad
                GenerarPlanes((int)cbxEsp.SelectedValue);
            }
        }
    }
}
