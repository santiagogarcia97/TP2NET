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
    public partial class ABMComisiones : Form {
        public ABMComisiones() {
            InitializeComponent();
            this.dgvComisiones.AutoGenerateColumns = false;
        }

        public void Listar() {
            //Limpio el dgv
            this.dgvComisiones.DataSource = null;
            this.dgvComisiones.Refresh();

            ComisionLogic cl = new ComisionLogic();
            List<Comision> comisiones = cl.GetAll();
            if (comisiones.Count() == 0) {
                MessageBox.Show("No hay comisiones cargadas!");
            }
            else {
                //creo el DataTable que va a ser el DataSource del dgv
                DataTable Listado = new DataTable();
                Listado.Columns.Add("ID", typeof(int));
                Listado.Columns.Add("Descripcion", typeof(string));
                Listado.Columns.Add("AnioEspecialidad", typeof(int));
                Listado.Columns.Add("Plan", typeof(string));

                //La columna plan mostrara especialidad.Descripcion + plan.Descripcion
                //En vez de mostrar los ID's que aportan poca informacion
                PlanLogic pl = new PlanLogic();
                List<Plan> planes = pl.GetAll();
                EspecialidadLogic el = new EspecialidadLogic();
                List<Especialidad> especialidades = el.GetAll();

                foreach (Comision com in comisiones) {
                    DataRow Linea = Listado.NewRow();

                    Linea["ID"] = com.ID;
                    Linea["Descripcion"] = com.Descripcion;
                    Linea["AnioEspecialidad"] = com.AnioEspecialidad;

                    //2 foreach anidados cargan la columna plan
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
            ABMComisionDesktop comisionDesktop = new ABMComisionDesktop(ApplicationForm.ModoForm.Alta);
            comisionDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e) {
            if (this.dgvComisiones.SelectedRows.Count != 0) {
                int ID = (int)this.dgvComisiones.SelectedRows[0].Cells["id"].Value;
                ABMComisionDesktop comisionDesktop = new ABMComisionDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                comisionDesktop.ShowDialog();
                this.Listar();
            }
        }
        private void tsbEliminar_Click(object sender, EventArgs e) {
            if (this.dgvComisiones.SelectedRows.Count != 0) {
                int ID = (int)this.dgvComisiones.SelectedRows[0].Cells["id"].Value;
                ABMComisionDesktop comisionDesktop = new ABMComisionDesktop(ID, ApplicationForm.ModoForm.Baja);
                comisionDesktop.ShowDialog();
                this.Listar();
            }
        }
        private void btnSalir_Click(object sender, EventArgs e) {
            this.Close();
        }

    }
}
