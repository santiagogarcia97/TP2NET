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
using Util;

namespace UI.Desktop {
    public partial class CambiarClave : Form {

        private Usuario _UsuarioActual;
        public CambiarClave(Usuario user) {
            UsuarioActual = user;
            InitializeComponent();
        }


        public Usuario UsuarioActual { get => _UsuarioActual; set => _UsuarioActual = value; }

        private void btnCerrar_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e) {
            if (txtPass1.Text.Equals(txtPass2.Text) && !string.IsNullOrWhiteSpace(txtPass1.Text)) {
                UsuarioActual.Clave = Hashing.HashPassword(txtPass1.Text);
                UsuarioLogic ul = new UsuarioLogic();
                ul.SavePassword(UsuarioActual);
                MessageBox.Show("La contraseña se guardó con exito!");
                this.Close();
            }
            else {
                MessageBox.Show("Las contraseñas no coinciden");
            }
        }
    }
}
