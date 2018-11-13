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

namespace UI.Desktop.admin
{
    public partial class ABMUsuarios : Form
    {
        public ABMUsuarios(){
            InitializeComponent();
            this.dgvUsuarios.AutoGenerateColumns = false;
        }

        public void Listar() {
            UsuarioLogic ul = new UsuarioLogic();
            List<Usuario> usuarios = ul.GetAll().Where(x => x.Habilitado == true).ToList();
            if (usuarios.Count() == 0) {
                MessageBox.Show("No hay usuarios cargados!");
            }
            else {
                this.dgvUsuarios.DataSource = Listado.Generar(usuarios);
            }
        }

        private void Usuarios_Load(object sender, EventArgs e) {
            Listar();
        }


        private void btnSalir_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e) {
            ABMUsuariosDesktop usuarioDesktop = new ABMUsuariosDesktop(ApplicationForm.ModoForm.Alta);
            usuarioDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e) {
            if (this.dgvUsuarios.SelectedRows.Count != 0) {
                int ID = ((Business.Entities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                ABMUsuariosDesktop usuarioDesktop = new ABMUsuariosDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                usuarioDesktop.ShowDialog();
                this.Listar();
            }
            else {
                MessageBox.Show("Seleccione una fila a editar");
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e) {
            if (this.dgvUsuarios.SelectedRows.Count != 0) {
                int ID = ((Business.Entities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                ABMUsuariosDesktop usuarioDesktop = new ABMUsuariosDesktop(ID, ApplicationForm.ModoForm.Baja);
                usuarioDesktop.ShowDialog();
                this.Listar();
            }
            else {
                MessageBox.Show("Seleccione una fila a eliminar");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }
    }
}
