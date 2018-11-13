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
    public partial class ABMPlanes : Form {
        public ABMPlanes() {
            InitializeComponent();
            this.dgvPlanes.AutoGenerateColumns = false;
        }

        public void Listar() {
            this.dgvPlanes.DataSource = null; //Se  limpia el DataGridView
            this.dgvPlanes.Refresh();

            PlanLogic pl = new PlanLogic();
            List<Plan> planes = pl.GetAll();
            this.dgvPlanes.DataSource = Listado.Generar(planes);
            
        }

        private void Planes_Load(object sender, EventArgs e) {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e) {
            ABMPlanesDesktop planDesktop = new ABMPlanesDesktop(ApplicationForm.ModoForm.Alta);
            planDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e) {
            if (this.dgvPlanes.SelectedRows.Count != 0) {
                int ID = (int)this.dgvPlanes.SelectedRows[0].Cells["id"].Value;
                ABMPlanesDesktop planDesktop = new ABMPlanesDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                planDesktop.ShowDialog();
                this.Listar();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e) {
            if (this.dgvPlanes.SelectedRows.Count != 0) {
                int ID = (int)this.dgvPlanes.SelectedRows[0].Cells["id"].Value;
                ABMPlanesDesktop planDesktop = new ABMPlanesDesktop(ID, ApplicationForm.ModoForm.Baja);
                planDesktop.ShowDialog();
                this.Listar();
            }
        }
    }
}