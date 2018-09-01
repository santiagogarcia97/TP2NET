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
        }

        public void Listar() {

            PlanLogic pl = new PlanLogic();
            List<Plan> planes = pl.GetAll();
            if (planes.Count() == 0) {
                MessageBox.Show("No hay planes cargados!");
            }
            else {
                DataTable Listado = new DataTable();
                Listado.Columns.Add("ID", typeof(int));
                Listado.Columns.Add("Descripcion", typeof(string));
                Listado.Columns.Add("Especialidad", typeof(string));

                EspecialidadLogic el = new EspecialidadLogic();
                List<Especialidad> especialidades = el.GetAll();

                foreach (Plan plan in planes) {
                    DataRow Linea = Listado.NewRow();

                    Linea["ID"] = plan.ID;
                    Linea["Descripcion"] = plan.Descripcion;
                    foreach (Especialidad esp in especialidades) {
                        if (esp.ID == plan.IDEspecialidad) {
                            Linea["Especialidad"] = esp.Descripcion;
                            break;
                        }
                    }
                    Listado.Rows.Add(Linea);
                }
                this.dgvPlanes.DataSource = Listado;
            }
        }

        private void Planes_Load(object sender, EventArgs e) {
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
                int ID = Int32.Parse(this.dgvPlanes.SelectedRows[0].Cells["id"].Value.ToString());
                PlanDesktop planDesktop = new PlanDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                planDesktop.ShowDialog();
                this.Listar();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e) {
            if (this.dgvPlanes.SelectedRows.Count != 0) {
                int ID = Int32.Parse(this.dgvPlanes.SelectedRows[0].Cells["id"].Value.ToString());
                PlanDesktop planDesktop = new PlanDesktop(ID, ApplicationForm.ModoForm.Baja);
                planDesktop.ShowDialog();
                this.Listar();
            }
        }
    }
}