using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            UsuarioLogic ul = new UsuarioLogic();
            Usuario user = ul.GetOne(txtUsuario.Text);
            if(txtUsuario.Text.Equals(user.NombreUsuario) && txtPassword.Text.Equals(user.Clave)){
                this.Visible = false;
                switch (user.TipoPersona) {
                    case 1:
                        MenuAlumno menuAlumno = new MenuAlumno(user.ID);
                        menuAlumno.ShowDialog();
                        break;
                    case 2:
                        MenuDocente menuDocente = new MenuDocente();
                        menuDocente.ShowDialog();
                        break;
                    case 3:
                        MenuAdmin menuAdministrador = new MenuAdmin();
                        menuAdministrador.ShowDialog();
                        break;
                }
                this.Visible = true;
            }
            else if(txtUsuario.Text.Equals(user.NombreUsuario) && !txtPassword.Text.Equals(user.Clave)){
                MessageBox.Show("La contraseña es incorrecta.");
            }
            else {
                MessageBox.Show("El usuario no existe.");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
