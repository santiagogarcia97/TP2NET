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
    public partial class Cursos : ApplicationForm
    {
        public Cursos(){
            InitializeComponent();
            this.dgvCursos.AutoGenerateColumns = false;
        }

        public void Listar() {
            this.dgvCursos.DataSource = null;
            this.dgvCursos.Refresh();
            CursoLogic cl = new CursoLogic();
            List<Curso> cursos = cl.GetAll();
            if (cursos.Count() == 0) {
                MessageBox.Show("No hay cursos cargados!");
            }
            else {
                DataTable Listado = new DataTable();
                Listado.Columns.Add("ID", typeof(int));
                Listado.Columns.Add("AnioCalendario", typeof(int));
                Listado.Columns.Add("Cupo", typeof(int));
                Listado.Columns.Add("Materia", typeof(string));
                Listado.Columns.Add("Comision", typeof(string));
                Listado.Columns.Add("Plan", typeof(string));

                PlanLogic pl = new PlanLogic();
                List<Plan> planes = pl.GetAll();

                EspecialidadLogic el = new EspecialidadLogic();
                List<Especialidad> especialidades = el.GetAll();

                MateriaLogic ml = new MateriaLogic();
                List<Materia> materias = ml.GetAll();

                ComisionLogic coml = new ComisionLogic();
                List<Comision> comisiones = coml.GetAll();

                foreach (Curso cur in cursos) {
                    DataRow Linea = Listado.NewRow();

                    Linea["ID"] = cur.ID;
                    Linea["AnioCalendario"] = cur.AnioCalendario.ToString();
                    Linea["Cupo"] = cur.Cupo;
                    foreach(Comision com in comisiones) {
                        if(com.ID == cur.IDComision) {
                            Linea["Comision"] = com.Descripcion;
                            break;
                        }
                    }
                    foreach(Materia mat in materias) {
                        if(mat.ID == cur.IDMateria) {
                            Linea["Materia"] = mat.Descripcion;
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
                            break;
                        }
                    }

                    Listado.Rows.Add(Linea);
                }
                this.dgvCursos.DataSource = Listado;
            }
        }

        private void Cursos_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            CursoDesktop cursoDesktop = new CursoDesktop(ApplicationForm.ModoForm.Alta);
            cursoDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvCursos.SelectedRows.Count != 0)
            {
                int ID = Int32.Parse(this.dgvCursos.SelectedRows[0].Cells["id"].Value.ToString());
                CursoDesktop cursoDesktop = new CursoDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                cursoDesktop.ShowDialog();
                this.Listar();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvCursos.SelectedRows.Count != 0)
            {
                int ID = Int32.Parse(this.dgvCursos.SelectedRows[0].Cells["id"].Value.ToString());
                CursoDesktop cursoDesktop = new CursoDesktop(ID, ApplicationForm.ModoForm.Baja);
                cursoDesktop.ShowDialog();
                this.Listar();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
