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
    public partial class ABMUsuariosDesktop : ApplicationForm {

        private Usuario _UsuarioActual;
        public Usuario UsuarioActual { get => _UsuarioActual; set => _UsuarioActual = value; }

        public ABMUsuariosDesktop() {
            InitializeComponent();
            GenerarTipoPersona();
        }

        public ABMUsuariosDesktop(ModoForm modo):this() {
            Modo = modo;
            btnAceptar.Text = "Crear";
            labelID.Text = "-";
            txtClave.Visible = true;
            btnCambiarClave.Visible = false;

            UsuarioLogic ul = new UsuarioLogic();
            labelLegajo.Text = ul.getNewLegajo().ToString();
            //chkHabilitado.Checked = true;
            GenerarEsp(0);
        }

        public ABMUsuariosDesktop(int ID, ModoForm modo) : this() {
            Modo = modo;

            UsuarioLogic ul = new UsuarioLogic();
            UsuarioActual = ul.GetOne(ID);

            PlanLogic pl = new PlanLogic();
            Plan plan = pl.GetOne(UsuarioActual.IDPlan);

            GenerarPlanes(plan.IDEspecialidad, plan.ID);

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
            //chkHabilitado.Checked = UsuarioActual.Habilitado;
            labelID.Text = UsuarioActual.ID.ToString();
            labelLegajo.Text = UsuarioActual.Legajo.ToString();
            txtNombre.Text = UsuarioActual.Nombre;
            txtApellido.Text = UsuarioActual.Apellido;
            txtFechaNac.Text = UsuarioActual.FechaNacimiento.ToString("dd/MM/yyyy");
            txtDirec.Text = UsuarioActual.Direccion;
            txtTel.Text = UsuarioActual.Telefono;
            txtEmail.Text = UsuarioActual.Email;
            txtNombreUsuario.Text = UsuarioActual.NombreUsuario;
            cbxTipo.SelectedValue = UsuarioActual.TipoPersona;
            cbEsp.SelectedValue = plan.IDEspecialidad;
            cbxPlan.SelectedValue = UsuarioActual.IDPlan;


            if (Modo == ApplicationForm.ModoForm.Baja) {
                btnAceptar.Text = "Eliminar";
                //chkHabilitado.Enabled = false;
                txtNombre.ReadOnly = true;
                txtApellido.ReadOnly = true;
                txtFechaNac.ReadOnly = true;
                txtDirec.ReadOnly = true;
                txtTel.ReadOnly = true;
                txtEmail.ReadOnly = true;
                txtNombreUsuario.ReadOnly = true;
                cbxTipo.Enabled = false;
                cbEsp.Enabled = false;
                cbxPlan.Enabled = false;
                txtClave.Visible = false;
                btnCambiarClave.Visible = false;
            }
            else if(Modo == ModoForm.Modificacion) {
                btnAceptar.Text = "Guardar";
                txtClave.Visible = false;
                btnCambiarClave.Visible = true;
            }
            else {
                btnAceptar.Text = "Guardar";
            }
        }

        public override void MapearADatos() {
            if(Modo == ModoForm.Alta || Modo == ModoForm.Modificacion) {
                UsuarioActual = new Usuario();
                UsuarioActual.Habilitado = true;
                UsuarioActual.Legajo = Int32.Parse(labelLegajo.Text);
                UsuarioActual.Nombre = txtNombre.Text;
                UsuarioActual.Apellido = txtApellido.Text;
                DateTime dt;
                DateTime.TryParseExact(txtFechaNac.Text, Util.Validaciones.FormatosFecha, null, DateTimeStyles.None, out dt);
                UsuarioActual.FechaNacimiento = dt;
                UsuarioActual.Direccion = txtDirec.Text;
                UsuarioActual.Telefono = txtTel.Text;
                UsuarioActual.Email = txtEmail.Text;
                UsuarioActual.NombreUsuario = txtNombreUsuario.Text;
                UsuarioActual.TipoPersona = (Usuario.TiposPersona)cbxTipo.SelectedValue;
                UsuarioActual.IDPlan = (int)cbxPlan.SelectedValue;

                if (Modo == ModoForm.Alta) {
                    UsuarioActual.State = BusinessEntity.States.New;
                    UsuarioActual.Clave = Hashing.HashPassword(txtClave.Text);
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
            cbxTipo.SelectedValue = 0;
        }
        private void GenerarPlanes(int idEsp, int idPlanActual) {
            //Se genera el comobox de planes el funcionamiento es igual al de especialidades solo que se pasa
            //el id de la esp para filtrar los planes de dicha esp
            cbxPlan.ValueMember = "id_plan";
            cbxPlan.DisplayMember = "desc_plan";
            cbxPlan.DataSource = GenerarComboBox.getPlanes(idEsp, idPlanActual);
        }
        private void btnAceptar_Click(object sender, EventArgs e) {
            if (Validar() == true) {
                GuardarCambios();
                this.Close();
            }
            else {
                MessageBox.Show("Compruebe los datos ingresados.");
            }
        }
        private void GenerarEsp(int idEspActual) {
            cbEsp.ValueMember = "id_esp";
            cbEsp.DisplayMember = "desc_esp";
            cbEsp.DataSource = GenerarComboBox.getEspecialidades(idEspActual);
            cbEsp.SelectedValue = 0;
        }

        public override void GuardarCambios() {
            MapearADatos();
            UsuarioLogic ul = new UsuarioLogic();
            ul.Save(UsuarioActual);
        }
        public override bool Validar() {
            lblRedAp.Visible = Validaciones.ValTexto(txtApellido.Text) ? false : true;
            lblRedNom.Visible = Validaciones.ValTexto(txtNombre.Text) ? false : true;
            lblRedDirec.Visible = Validaciones.ValTexto(txtDirec.Text) ? false : true;
            lblRedTel.Visible = Validaciones.ValTexto(txtTel.Text) ? false : true;
            lblRedEmail.Visible = Validaciones.ValEmail(txtEmail.Text) ? false : true;
            lblRedUser.Visible = Validaciones.ValUsername(txtNombreUsuario.Text) ? false : true;

            if (Validaciones.ValTexto(txtNombreUsuario.Text) && Validaciones.ValUsername(txtNombreUsuario.Text)) {
                if (Modo == ModoForm.Alta && !Validaciones.ValUsernameExists(txtNombreUsuario.Text)) {
                    lblRedUser.Visible = false;
                }
                else if (Modo == ModoForm.Modificacion) {
                    UsuarioLogic UserLogic = new UsuarioLogic();
                    Usuario aux = UserLogic.GetOne(int.Parse(labelID.Text));
                    if (aux.NombreUsuario.Equals(txtNombreUsuario.Text)) lblRedUser.Visible = false;
                    else {
                        lblRedUser.Visible = true;
                    }
                }
                else {
                    lblRedUser.Visible = true;
                }
            }
            else {
                lblRedUser.Visible = true;
            }

            lblRedTipo.Visible = (cbxTipo.SelectedValue == null || (int)cbxTipo.SelectedValue == 0) ? true : false;
            lblRedPlan.Visible = (cbEsp.SelectedValue == null || cbxPlan.SelectedValue == null ||
                                  (int)cbEsp.SelectedValue == 0 || (int)cbxPlan.SelectedValue == 0) ? true : false;
            
            lblRedNac.Visible = Validaciones.ValFecha(txtFechaNac.Text)? false : true;

            if(Modo == ModoForm.Modificacion) { lblRedClave.Visible = (Validaciones.ValClave(txtClave.Text)) ? true : false; }

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
            if (cbEsp.SelectedValue != null) {
                //Si el valor del combobox de especialidades cambia, se vuelven a generar los planes
                //pasando como argumento el id de la especialidad para mostrar solo los planes que
                //corresponden a dicha especialidad
                if (Modo == ModoForm.Alta) {
                    GenerarPlanes((int)cbEsp.SelectedValue, 0);
                }
                else { 
                    PlanLogic pl = new PlanLogic();
                    Plan plan = pl.GetOne(UsuarioActual.IDPlan);
                    GenerarPlanes((int)cbEsp.SelectedValue, plan.ID);
                }
            }
        }

        private void btnCambiarClave_Click(object sender, EventArgs e) {
            CambiarClave aux = new CambiarClave(UsuarioActual);
            aux.ShowDialog();
        }
    }
}
