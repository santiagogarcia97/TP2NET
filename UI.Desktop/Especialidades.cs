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
    public partial class Especialidades : ApplicationForm {
        public Especialidades() {
            InitializeComponent();
            this.dgvEspecialidades.AutoGenerateColumns = false;
        }

        public void Listar() {
            EspecialidadLogic esp = new EspecialidadLogic();
            List<Especialidad> especialidades = esp.GetAll();
            if (especialidades.Count() == 0)
            {
                MessageBox.Show("No hay especialidades cargadas!");
            }
            this.dgvEspecialidades.DataSource = especialidades;
        }

        private void Especialidades_Load(object sender, EventArgs e) {
            Listar();
        }

        private void tsbNuevo_Click(object sender, EventArgs e) {
            EspecialidadDesktop especialidadDesktop = new EspecialidadDesktop(ApplicationForm.ModoForm.Alta);
            especialidadDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e) {
            if (this.dgvEspecialidades.SelectedRows.Count != 0) {
                int ID = ((Business.Entities.Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
                EspecialidadDesktop especialidadDesktop = new EspecialidadDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                especialidadDesktop.ShowDialog();
                this.Listar();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e) {
            if (this.dgvEspecialidades.SelectedRows.Count != 0) {
                int ID = ((Business.Entities.Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
                EspecialidadDesktop especialidadDesktop = new EspecialidadDesktop(ID, ApplicationForm.ModoForm.Baja);
                especialidadDesktop.ShowDialog();
                this.Listar();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
