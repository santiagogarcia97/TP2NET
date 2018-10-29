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
            List<Materia> materias = ml.GetAll();

            if (materias.Count() == 0) {
                MessageBox.Show("No hay materias cargadas!");
            }
            else {
                //Se crea el DataTable que va a ser el DataSource del dgv
                DataTable Listado = new DataTable();
                Listado.Columns.Add("ID", typeof(int));
                Listado.Columns.Add("Descripcion", typeof(string));
                Listado.Columns.Add("HSSemanales", typeof(int));
                Listado.Columns.Add("HSTotales", typeof(int));
                Listado.Columns.Add("Plan", typeof(string));

                //Se obtienen las especialidades y los planes para mostrar en la columna Plan = esp.Descripcion + plan.Descripcion
                PlanLogic pl = new PlanLogic();
                List<Plan> planes = pl.GetAll();
                EspecialidadLogic el = new EspecialidadLogic();
                List<Especialidad> especialidades = el.GetAll();

                foreach (Materia mat in materias) {
                    DataRow Linea = Listado.NewRow();

                    Linea["ID"] = mat.ID;
                    Linea["Descripcion"] = mat.Descripcion;
                    Linea["HSSemanales"] = mat.HSSemanales;
                    Linea["HSTotales"] = mat.HSTotales;
                    //Dos foreach anidados cargan la columna Plan
                    foreach (Plan plan in planes) {
                        if (plan.ID == mat.IDPlan) {
                            foreach (Especialidad esp in especialidades) {
                                if (esp.ID == plan.IDEspecialidad) {
                                    Linea["Plan"] = esp.Descripcion + " - " + plan.Descripcion;
                                    break;
                                }
                            }
                            break;
                        }
                    }
                    Listado.Rows.Add(Linea);
                }
                this.dgvMaterias.DataSource = Listado;
            }
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
