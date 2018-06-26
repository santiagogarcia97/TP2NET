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

        public Business.Entities.Usuario _usuarioActual;
        public Business.Entities.Usuario UsuarioActual {
            get { return _usuarioActual; }
            set { _usuarioActual = value; }
        }

        public UsuarioDesktop() {
            InitializeComponent();
        }

        public UsuarioDesktop(ModoForm modo):this() {
            Modo = modo;
        }

        public UsuarioDesktop(int ID, ModoForm modo) : this() {
            Modo = modo;
            UsuarioLogic auxUsuario = new UsuarioLogic();
            UsuarioActual = auxUsuario.GetOne(ID);
            MapearDeDatos();
        }

        public override void MapearDeDatos() {
            txtID.Text = UsuarioActual.ID.ToString();
            txtNombre.Text = UsuarioActual.Nombre;
            txtApellido.Text = UsuarioActual.Apellido;
            txtEmail.Text = UsuarioActual.Email;
            txtUsuario.Text = UsuarioActual.NombreUsuario;
            txtClave.Text = UsuarioActual.Clave;
            chkHabilitado.Checked = UsuarioActual.Habilitado;

            switch (Modo) {
                case ModoForm.Alta:                                 
                case ModoForm.Modificacion:                     //Equivalente a if(Modo == ModoForm.Alta || Modo == Modoform.Modificacion){...}
                    btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    btnAceptar.Text = "Eliminar";
                    txtNombre.ReadOnly = true;
                    txtApellido.ReadOnly = true;
                    txtEmail.ReadOnly = true;
                    txtUsuario.ReadOnly = true;
                    txtClave.ReadOnly = true;
                    chkHabilitado.Enabled = false;
                    txtConfirmarClave.Text = UsuarioActual.Clave;
                    txtConfirmarClave.ReadOnly = true;
                    break;
                case ModoForm.Consulta:
                    btnAceptar.Text = "Aceptar";
                    txtNombre.ReadOnly = true;
                    txtApellido.ReadOnly = true;
                    txtEmail.ReadOnly = true;
                    txtUsuario.ReadOnly = true;
                    txtClave.ReadOnly = true;
                    chkHabilitado.Enabled = false;
                    txtConfirmarClave.Text = UsuarioActual.Clave;
                    txtConfirmarClave.ReadOnly = true;
                    break;
            }
        }

        public override void MapearADatos() {
            switch (Modo) {                                      //Emprolijar: Evitar repetición de asignaciones
                case ModoForm.Alta:
                    UsuarioActual = new Usuario();
                    UsuarioActual.Apellido = txtApellido.Text;
                    UsuarioActual.Nombre = txtNombre.Text;
                    UsuarioActual.Email = txtEmail.Text;
                    UsuarioActual.Clave = txtClave.Text;
                    UsuarioActual.Habilitado = chkHabilitado.Checked;
                    UsuarioActual.NombreUsuario = txtUsuario.Text;
                    UsuarioActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    UsuarioActual.Apellido = txtApellido.Text;
                    UsuarioActual.Nombre = txtNombre.Text;
                    UsuarioActual.Email = txtEmail.Text;
                    UsuarioActual.Clave = txtClave.Text;
                    UsuarioActual.NombreUsuario = txtUsuario.Text;
                    UsuarioActual.Habilitado = chkHabilitado.Checked;
                    UsuarioActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Baja:
                    UsuarioActual.State = BusinessEntity.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    UsuarioActual.State = BusinessEntity.States.Unmodified;
                    break;
            }
        }

        public override void GuardarCambios() {
            MapearADatos();
            UsuarioLogic auxUsuario = new UsuarioLogic();
            auxUsuario.Save(UsuarioActual);
        }

        public override bool Validar() {
            return !(                                              //Si cualquiera de estas condiciones es verdadera, retorna false
            string.IsNullOrEmpty(txtNombre.Text) ||
            string.IsNullOrEmpty(txtApellido.Text) ||
            string.IsNullOrEmpty(txtEmail.Text) ||
            string.IsNullOrEmpty(txtUsuario.Text) ||
            string.IsNullOrEmpty(txtClave.Text) ||
            (txtClave.Text != txtConfirmarClave.Text));
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
    }
}
