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
    public partial class Planes : Form {
        public Planes() {
            InitializeComponent();
            this.dgvPlanes.AutoGenerateColumns = false;
            this.Listar();
            
        }

        public void Listar() {
            PlanLogic pl = new PlanLogic();
            List<Plan> planes = pl.GetAll();
            if (planes.Count() == 0)
            {
                MessageBox.Show("No hay planes cargados!");
            }
            this.dgvPlanes.DataSource = planes;
        }

        private void Planes_Load(object sender, EventArgs e) {
            Listar();
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e) {
            PlanDesktop planDesktop = new PlanDesktop(ApplicationForm.ModoForm.Alta);
            planDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e) {
            if (this.dgvPlanes.SelectedRows.Count != 0) {
                int ID = ((Business.Entities.Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID;
                PlanDesktop planDesktop = new PlanDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                planDesktop.ShowDialog();
                this.Listar();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e) {
            if (this.dgvPlanes.SelectedRows.Count != 0) {
                int ID = ((Business.Entities.Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID;
                PlanDesktop planDesktop = new PlanDesktop(ID, ApplicationForm.ModoForm.Baja);
                planDesktop.ShowDialog();
                this.Listar();
            }
        }

        private void tsbConsultar_Click(object sender, EventArgs e) {
            if (this.dgvPlanes.SelectedRows.Count != 0) {
                int ID = ((Business.Entities.Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID;
                PlanDesktop planDesktop = new PlanDesktop(ID, ApplicationForm.ModoForm.Consulta);
                planDesktop.ShowDialog();
                this.Listar();
            }
        }
    }
}
