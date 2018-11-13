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
using Util;

namespace UI.Desktop.admin
{
    public partial class ABMComisiones : Form {
        public ABMComisiones() {
            InitializeComponent();
            this.dgvComisiones.AutoGenerateColumns = false;
        }

        public void Listar() {
            //Limpio el dgv
            this.dgvComisiones.DataSource = null;
            this.dgvComisiones.Refresh();

            ComisionLogic cl = new ComisionLogic();
            List<Comision> comisiones = cl.GetAll().Where(x => x.Habilitado == true).ToList();
            if (comisiones.Count() == 0) {
                MessageBox.Show("No hay comisiones cargadas!");
            }
            else {
                this.dgvComisiones.DataSource = Listado.Generar(comisiones);
            }
            
            
        }

        private void Comisiones_Load(object sender, EventArgs e) {
            Listar();
        }

        private void tsbNuevo_Click(object sender, EventArgs e) {
            ABMComisionesDesktop comisionDesktop = new ABMComisionesDesktop(ApplicationForm.ModoForm.Alta);
            comisionDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e) {
            if (this.dgvComisiones.SelectedRows.Count != 0) {
                int ID = (int)this.dgvComisiones.SelectedRows[0].Cells["id"].Value;
                ABMComisionesDesktop comisionDesktop = new ABMComisionesDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                comisionDesktop.ShowDialog();
                this.Listar();
            }
        }
        private void tsbEliminar_Click(object sender, EventArgs e) {
            if (this.dgvComisiones.SelectedRows.Count != 0) {
                int ID = (int)this.dgvComisiones.SelectedRows[0].Cells["id"].Value;
                ABMComisionesDesktop comisionDesktop = new ABMComisionesDesktop(ID, ApplicationForm.ModoForm.Baja);
                comisionDesktop.ShowDialog();
                this.Listar();
            }
        }
        private void btnSalir_Click(object sender, EventArgs e) {
            this.Close();
        }

    }
}
