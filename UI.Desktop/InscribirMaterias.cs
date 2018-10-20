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
using static Business.Entities.AlumnoInscripcion;

namespace UI.Desktop {
    public partial class InscribirMaterias : ApplicationForm {
        private AlumnoInscripcion _InscripcionActual;
        private Usuario _UsuarioActual;

        public AlumnoInscripcion InscripcionActual { get => _InscripcionActual; set => _InscripcionActual = value; }
        public Usuario UsuarioActual { get => _UsuarioActual; set => _UsuarioActual = value; }

        public InscribirMaterias() {
            InitializeComponent();
            this.dgvCursos.AutoGenerateColumns = false;
        }

        public InscribirMaterias(ModoForm modo, Usuario user) : this() {
            UsuarioActual = user;
            Modo = modo;
        }

        private void AlumnoInscripcionDesktop_Load(object sender, EventArgs e) {
            this.ListarCursos();
        }

        private void ListarCursos() {
            //Se limpia el dgv
            this.dgvCursos.DataSource = null;
            this.dgvCursos.Refresh();

            CursoLogic cl = new CursoLogic();
            List<Curso> cursos = cl.GetAll();
            if (cursos.Count() == 0) {
                MessageBox.Show("No hay cursos cargados para inscribirse!");
            }
            else {
                //Se crea el DataTable que va a ser el DataSource del dgv
                DataTable Listado = new DataTable();
                Listado.Columns.Add("ID", typeof(int));
                Listado.Columns.Add("AnioCalendario", typeof(int));
                Listado.Columns.Add("Cupo", typeof(string));
                Listado.Columns.Add("Curso", typeof(string));

                MateriaLogic ml = new MateriaLogic();
                List<Materia> materias = ml.GetAll();
                ComisionLogic coml = new ComisionLogic();
                List<Comision> comisiones = coml.GetAll();

                //Cargo las materias en la que ya esta inscripto en una nueva lista
                AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
                List<AlumnoInscripcion> inscripciones = ail.GetAllFromUser(UsuarioActual.ID);
                List<Materia> matInscripto = new List<Materia>();
                foreach(AlumnoInscripcion ai in inscripciones) {
                    Curso cur = cursos.First(x => x.ID == ai.IDCurso);
                    Materia mat = materias.First(x => x.ID == cur.IDMateria);
                    matInscripto.Add(mat);
                }

                foreach (Curso cur in cursos) {
                   
                    // Valido que no este inscripto a la materia
                    Materia mat = materias.FirstOrDefault(x => x.ID == cur.IDMateria);
                    if (!matInscripto.Exists(x => x.ID == mat.ID)) {
                        
                        //Solo se muestran los cursos correspondientes al mismo plan del usuario
                        if (mat.IDPlan == UsuarioActual.IDPlan) {

                            DataRow Linea = Listado.NewRow();

                            Linea["ID"] = cur.ID;
                            Linea["AnioCalendario"] = cur.AnioCalendario.ToString();
                            Linea["Cupo"] = ail.GetCantCupo(cur.ID) + "/" + cur.Cupo;

                            Comision com = comisiones.FirstOrDefault(x => x.ID == cur.IDComision);
                            Linea["Curso"] = com.Descripcion + " - " + mat.Descripcion;
                            Listado.Rows.Add(Linea);
                        }
                    }
                }
                if (Listado.Rows.Count == 0) {
                    MessageBox.Show("No hay cursos disponibles");
                    this.Close();
                }
                else {
                    this.dgvCursos.DataSource = Listado;
                }
                
            }

        }

        private void btnSalir_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnInscribir_Click(object sender, EventArgs e) {
            var confirmResult =
                MessageBox.Show(this.dgvCursos.SelectedRows[0].Cells["Curso"].Value.ToString(),
                                "Confirmar inscripcion", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes) {
                InscripcionActual = new AlumnoInscripcion();
                InscripcionActual.IDCurso = (int)this.dgvCursos.SelectedRows[0].Cells["ID"].Value;
                InscripcionActual.IDAlumno = UsuarioActual.ID;
                InscripcionActual.Condicion = Condiciones.Cursando;
                InscripcionActual.Habilitado = true;
                InscripcionActual.Nota = "";
                InscripcionActual.State = BusinessEntity.States.New;

                AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
                CursoLogic cursoLogic = new CursoLogic();
                Curso curso = cursoLogic.GetOne(InscripcionActual.IDCurso);
                if (ail.GetCantCupo(InscripcionActual.IDCurso) < curso.Cupo) {
                    ail.Save(InscripcionActual);
                }
                else {
                    MessageBox.Show("El curso no tiene cupo disponible");
                }
                this.ListarCursos();
            }
        }
    }
}
