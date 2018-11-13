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

        private void btnIngresar_Click(object sender, EventArgs e) {
            this.Enabled = false;
            try {
                UsuarioLogic ul = new UsuarioLogic();
                Usuario user = ul.GetOne(txtUsuario.Text);
                if (txtUsuario.Text.Equals(user.NombreUsuario) && Hashing.ValidatePassword(txtPassword.Text, user.Clave)) {
                    this.Visible = false;

                    Menu main = new Menu(user);
                    main.ShowDialog();

                    this.Visible = true;
                }
                else {
                    MessageBox.Show("Usuario o Contraseña incorrecto.");
                }
            }
            catch(Exception ex) {
                MessageBox.Show("Error de Servidor. \n" + ex.Message);
            }
            txtPassword.Text = string.Empty;
            this.Enabled = true;
                   
        }

        private void btnSalir_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
