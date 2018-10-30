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

namespace UI.Desktop {
    public partial class ABMMaterias : Form {
        public ABMMaterias() {
            InitializeComponent();
            this.dgvMaterias.AutoGenerateColumns = false;
        }

        public void Listar() {
            //Se limpia el DataGridView
            this.dgvMaterias.DataSource = null;
            this.dgvMaterias.Refresh();

            MateriaLogic ml = new MateriaLogic();
            this.dgvMaterias.DataSource = ml.GetListado();
        }

        private void Materias_Load(object sender, EventArgs e) {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e) {
            ABMMateriasDesktop materiaDesktop = new ABMMateriasDesktop(ApplicationForm.ModoForm.Alta);
            materiaDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e) {
            if (this.dgvMaterias.SelectedRows.Count != 0) {
                int ID = (int)this.dgvMaterias.SelectedRows[0].Cells["id"].Value;
                ABMMateriasDesktop materiaDesktop = new ABMMateriasDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                materiaDesktop.ShowDialog();
                this.Listar();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e) {
            if (this.dgvMaterias.SelectedRows.Count != 0) {
                int ID = (int)this.dgvMaterias.SelectedRows[0].Cells["id"].Value;
                ABMMateriasDesktop materiaDesktop = new ABMMateriasDesktop(ID, ApplicationForm.ModoForm.Baja);
                materiaDesktop.ShowDialog();
                this.Listar();
            }
        }

    }
}
