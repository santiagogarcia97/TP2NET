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
        private Usuario _UsuarioActual;
        public Usuario UsuarioActual { get => _UsuarioActual; set => _UsuarioActual = value; }

        public Cursos(){
            InitializeComponent();
            this.dgvCursos.AutoGenerateColumns = false;
        }
        public Cursos(Usuario user) : this() {
            UsuarioActual = user;
            if (UsuarioActual.TipoPersona == 2) {
                tsbEliminar.Visible = false;
                tsbNuevo.Visible = false;
            }
        }

        public void Listar() {
            //Se limpia el dgv
            this.dgvCursos.DataSource = null;
            this.dgvCursos.Refresh();

            CursoLogic cl = new CursoLogic();
            List<Curso> cursos = new List<Curso>();
            if (UsuarioActual.TipoPersona == 2) {
                DocenteCursoLogic dcl = new DocenteCursoLogic();
                List<DocenteCurso> dclist = dcl.GetAllFromUser(UsuarioActual.ID);

                foreach (DocenteCurso dc in dclist) {
                    cursos.Add(cl.GetOne(dc.IDCurso));
                }
            }
            else {
                cursos = cl.GetAll();
            }

            if (cursos.Count() == 0) {
                MessageBox.Show("No hay cursos cargados!");
            }
            else {
                //Se crea el DataTable que va a ser el DataSource del dgv
                DataTable Listado = new DataTable();
                Listado.Columns.Add("ID", typeof(int));
                Listado.Columns.Add("AnioCalendario", typeof(int));
                Listado.Columns.Add("Cupo", typeof(int));
                Listado.Columns.Add("Materia", typeof(string));
                Listado.Columns.Add("Comision", typeof(string));
                Listado.Columns.Add("Plan", typeof(string));

                //La columna materia mostrara materia.Descripcion 
                //La columna comision mostrara comision.Descripcion
                //La columna plan mostrara especialidad.Descripcion + plan.Descripcion
                //En vez de mostrar los ID's que aportan poca informacion
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
                    //3 foreach anidados cargan las columnas materia y plan
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
                int ID = (int)this.dgvCursos.SelectedRows[0].Cells["id"].Value;
                if (UsuarioActual.TipoPersona == 3) {
                    CursoDesktop cursoDesktop = new CursoDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                    cursoDesktop.ShowDialog();
                }
                else if(UsuarioActual.TipoPersona == 2) {
                    AlumnoInscripciones ai = new AlumnoInscripciones(UsuarioActual, ID);
                    ai.ShowDialog();                   
                }
                this.Listar();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvCursos.SelectedRows.Count != 0)
            {
                int ID = (int)this.dgvCursos.SelectedRows[0].Cells["id"].Value;
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
