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
            this.dgvComisiones.DataSource = null;
            this.dgvComisiones.Refresh();
            ComisionLogic cl = new ComisionLogic();
            List<Comision> comisiones = cl.GetAll();
            if (comisiones.Count() == 0) {
                MessageBox.Show("No hay comisiones cargadas!");
            }
            else {
                DataTable Listado = new DataTable();
                Listado.Columns.Add("ID", typeof(int));
                Listado.Columns.Add("Descripcion", typeof(string));
                Listado.Columns.Add("AnioEspecialidad", typeof(int));
                Listado.Columns.Add("Plan", typeof(string));

                PlanLogic pl = new PlanLogic();
                List<Plan> planes = pl.GetAll();

                EspecialidadLogic el = new EspecialidadLogic();
                List<Especialidad> especialidades = el.GetAll();

                foreach (Comision com in comisiones) {
                    DataRow Linea = Listado.NewRow();

                    Linea["ID"] = com.ID;
                    Linea["Descripcion"] = com.Descripcion;
                    Linea["AnioEspecialidad"] = com.AnioEspecialidad;
                    foreach (Plan plan in planes) {
                        if (plan.ID == com.IDPlan) {
                            foreach(Especialidad esp in especialidades) {
                                if(esp.ID == plan.IDEspecialidad) {
                                    Linea["Plan"] = esp.Descripcion + " - " + plan.Descripcion;
                                    break;
                                }
                            }
                            break;
                        }
                    }
                    Listado.Rows.Add(Linea);
                }
                this.dgvComisiones.DataSource = Listado;
            }
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
                int ID = Int32.Parse(this.dgvComisiones.SelectedRows[0].Cells["id"].Value.ToString());
                ComisionDesktop comisionDesktop = new ComisionDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                comisionDesktop.ShowDialog();
                this.Listar();
            }
        }
        private void tsbEliminar_Click(object sender, EventArgs e) {
            if (this.dgvComisiones.SelectedRows.Count != 0) {
                int ID = Int32.Parse(this.dgvComisiones.SelectedRows[0].Cells["id"].Value.ToString());
                ComisionDesktop comisionDesktop = new ComisionDesktop(ID, ApplicationForm.ModoForm.Baja);
                comisionDesktop.ShowDialog();
                this.Listar();
            }
        }
        private void btnSalir_Click(object sender, EventArgs e) {
            this.Close();
        }

    }
}
