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
            this.dgvPlanes.DataSource = null; //Se  limpia el DataGridView
            this.dgvPlanes.Refresh();

            PlanLogic pl = new PlanLogic();
            List<Plan> planes = pl.GetAll();
            if (planes.Count() == 0) {
                MessageBox.Show("No hay planes cargados!");
            }
            else {
                DataTable Listado = new DataTable(); //Este DataTable se va a utilizar como source del dgv
                Listado.Columns.Add("ID", typeof(int));
                Listado.Columns.Add("Descripcion", typeof(string));
                Listado.Columns.Add("Especialidad", typeof(string));

                //Seobtiene la lista de especialidades para mostrar su descripcion en la columna conrrespondiente
                //en vez de ver el id que aporta poca informacion
                EspecialidadLogic el = new EspecialidadLogic();
                List<Especialidad> especialidades = el.GetAll();

                foreach (Plan plan in planes) {
                    DataRow Linea = Listado.NewRow();

                    Linea["ID"] = plan.ID;
                    Linea["Descripcion"] = plan.Descripcion;
                    foreach (Especialidad esp in especialidades) {
                        if (esp.ID == plan.IDEspecialidad) {
                            //Se busca la especialidad del plan, se carga la columna con la descripcion y se sale del bucle
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
            this.Listar();
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