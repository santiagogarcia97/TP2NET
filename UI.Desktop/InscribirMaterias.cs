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
using Util;

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

            MateriaLogic ml = new MateriaLogic();
            List<Materia> materias = ml.GetAll();
            ComisionLogic coml = new ComisionLogic();
            List<Comision> comisiones = coml.GetAll();

            //Cargo las materias en la que ya esta inscripto en una nueva lista
            AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
            List<AlumnoInscripcion> inscripciones = ail.GetAllFromUser(UsuarioActual.ID); //Obtengo todas las insc del alumno
            List<Materia> matInscripto = new List<Materia>();

            foreach (AlumnoInscripcion ai in inscripciones) {
                Curso cur = cursos.First(x => x.ID == ai.IDCurso);
                Materia mat = materias.First(x => x.ID == cur.IDMateria);
                if (ai.Condicion != AlumnoInscripcion.Condiciones.Libre) matInscripto.Add(mat);// Creo una list con las materias a las que se puede inscribir, sin contar las inscripciones "libres"
            }

            List<Curso> cursosHabilitado = new List<Curso>(); //creo la lista de cursos que se van a mostrar

            foreach (Curso cur in cursos) {
                // Valido que no este inscripto a la materia
                Materia mat = materias.FirstOrDefault(x => x.ID == cur.IDMateria);
                if (!matInscripto.Exists(x => x.ID == mat.ID) &&    //Para poder inscribirme a un curso no puedo estar inscripto a otro de la misma materia a menos que esté "libre"
                    !inscripciones.Exists(x => x.IDCurso == cur.ID && x.Condicion == AlumnoInscripcion.Condiciones.Libre)) {//Si estoy libre no puedo inscribirme a ese mismo curso

                    //Solo se muestran los cursos correspondientes al mismo plan del usuario
                    if (mat.IDPlan == UsuarioActual.IDPlan) {
                        if (cur.Cupo > ail.GetCantCupo(cur.ID))
                            cursosHabilitado.Add(cur);
                    }
                }
            }

            cursos = null; materias = null; comisiones = null; //para liberar memoria

            if (cursosHabilitado.Count == 0) {
                MessageBox.Show("No existen cursos disponibles.");
            }
            else {
                dgvCursos.DataSource = Listado.Generar(cursosHabilitado); // paso la lista de cursos para que me devuelva el datatable 
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
                InscripcionActual.Condicion = AlumnoInscripcion.Condiciones.Cursando;
                InscripcionActual.Habilitado = true;
                InscripcionActual.Nota = 0;
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
