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
    public partial class Comisiones : Form {
        public Comisiones() {
            InitializeComponent();
            this.dgvComisiones.AutoGenerateColumns = false;
        }

        public void Listar() {
            ComisionLogic cml = new ComisionLogic();
            List<Comision> comisiones = cml.GetAll();
            if (comisiones.Count() == 0)
            {
                MessageBox.Show("No hay comisiones cargadas!");
            }
            this.dgvComisiones.DataSource = comisiones;
        }

        private void Comisiones_Load(object sender, EventArgs e) {
            Listar();
        }

        private void tsbNuevo_Click(object sender, EventArgs e) {
            ComisionDesktop comisionDesktop = new ComisionDesktop(ApplicationForm.ModoForm.Alta);
            comisionDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e) {
            if (this.dgvComisiones.SelectedRows.Count != 0) {
                int ID = ((Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
                ComisionDesktop comisionDesktop = new ComisionDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                comisionDesktop.ShowDialog();
                this.Listar();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e) {
            if (this.dgvComisiones.SelectedRows.Count != 0) {
                int ID = ((Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
                ComisionDesktop comisionDesktop = new ComisionDesktop(ID, ApplicationForm.ModoForm.Baja);
                comisionDesktop.ShowDialog();
                this.Listar();
            }
        }

        private void tsbConsultar_Click(object sender, EventArgs e) {
            if (this.dgvComisiones.SelectedRows.Count != 0) {
                int ID = ((Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
                ComisionDesktop comisionDesktop = new ComisionDesktop(ID, ApplicationForm.ModoForm.Consulta);
                comisionDesktop.ShowDialog();
                this.Listar();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e) {
            this.Close();
        }

    }
}
