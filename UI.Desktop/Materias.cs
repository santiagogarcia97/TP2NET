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
    public partial class Materias : Form {
        public Materias() {
            InitializeComponent();
            this.dgvMaterias.AutoGenerateColumns = false;
        }

        public void Listar() {
            MateriaLogic ml = new MateriaLogic();
            this.dgvMaterias.DataSource = ml.GetAll();
        }

        private void Materias_Load(object sender, EventArgs e) {
            Listar();
        }


        private void btnSalir_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e) {
            MateriaDesktop materiaDesktop = new MateriaDesktop(ApplicationForm.ModoForm.Alta);
            materiaDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e) {
            if (this.dgvMaterias.SelectedRows.Count != 0) {
                int ID = ((Business.Entities.Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
                MateriaDesktop materiaDesktop = new MateriaDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                materiaDesktop.ShowDialog();
                this.Listar();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e) {
            if (this.dgvMaterias.SelectedRows.Count != 0) {
                int ID = ((Business.Entities.Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
                MateriaDesktop materiaDesktop = new MateriaDesktop(ID, ApplicationForm.ModoForm.Baja);
                materiaDesktop.ShowDialog();
                this.Listar();
            }
        }

        private void tsbConsultar_Click(object sender, EventArgs e) {
            if (this.dgvMaterias.SelectedRows.Count != 0) {
                int ID = ((Business.Entities.Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
                MateriaDesktop materiaDesktop = new MateriaDesktop(ID, ApplicationForm.ModoForm.Consulta);
                materiaDesktop.ShowDialog();
                this.Listar();
            }
        }

    }
}
