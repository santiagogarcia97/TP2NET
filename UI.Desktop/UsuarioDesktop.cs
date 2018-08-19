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
                    txtUsuario.ReadOnly = true;
                    txtClave.ReadOnly = true;
                    chkHabilitado.Enabled = false;
                    txtConfirmarClave.Text = UsuarioActual.Clave;
                    txtConfirmarClave.ReadOnly = true;
                    cbPersona.Enabled = false;
                    break;
                case ModoForm.Consulta:
                    btnAceptar.Text = "Aceptar";
                    txtUsuario.ReadOnly = true;
                    txtClave.ReadOnly = true;
                    chkHabilitado.Enabled = false;
                    txtConfirmarClave.Text = UsuarioActual.Clave;
                    txtConfirmarClave.ReadOnly = true;
                    cbPersona.Enabled = false;
                    break;
            }
        }

        public override void MapearADatos() {
            switch (Modo) {                                      //Emprolijar: Evitar repetición de asignaciones  
                case ModoForm.Alta:
                    UsuarioActual = new Usuario();
                    UsuarioActual.Clave = txtClave.Text;
                    UsuarioActual.Habilitado = chkHabilitado.Checked;
                    UsuarioActual.NombreUsuario = txtUsuario.Text;
                    UsuarioActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
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
            return !(                                     //Si cualquiera de estas condiciones es verdadera, retorna false
            string.IsNullOrEmpty(txtUsuario.Text) ||
            string.IsNullOrEmpty(txtClave.Text) ||
            string.IsNullOrEmpty(cbPersona.Text) ||
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
