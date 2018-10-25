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

namespace UI.Desktop{
    public partial class MisInscripciones : ApplicationForm{

        private Usuario _UsuarioActual;
        private int _IDCurso;
        public Usuario UsuarioActual { get => _UsuarioActual; set => _UsuarioActual = value; }
        public int IDCurso { get => _IDCurso; set => _IDCurso = value; }

        public MisInscripciones(){
            InitializeComponent();
            this.dgvAlumnoInscripciones.AutoGenerateColumns = false;
        }
        public MisInscripciones(Usuario user) : this() {
            UsuarioActual = user;
            if(UsuarioActual.TipoPersona == 1) {
                tcAlumnoInscripciones.TopToolStripPanel.Visible = false;
            }
        }
        public MisInscripciones(Usuario user, int id) : this() {
            UsuarioActual = user;
            IDCurso = id;
            tsbNuevo.Visible = false;
            tsbEliminar.Visible = false;
        }
        private void AlumnoInscripciones_Load(object sender, EventArgs e) {
            Listar();
        }

        public void Listar(){
            this.dgvAlumnoInscripciones.DataSource = null;
            this.dgvAlumnoInscripciones.Refresh();

            AlumnoInscripcionLogic ins = new AlumnoInscripcionLogic();
            List<AlumnoInscripcion> inscripciones = new List<AlumnoInscripcion>();
            if (UsuarioActual.TipoPersona == 1) {
                inscripciones = ins.GetAll().Where(x => x.IDAlumno == UsuarioActual.ID).ToList();
            }
            else if (UsuarioActual.TipoPersona == 2) {
                inscripciones = ins.GetAllFromCurso(IDCurso);
            }
            else if (UsuarioActual.TipoPersona == 3) {
                inscripciones = ins.GetAll();
            }
            if (inscripciones.Count() == 0){
                MessageBox.Show("No hay inscripciones cargadas!");
            }

            DataTable Listado = new DataTable();
            Listado.Columns.Add("ID", typeof(int));
            Listado.Columns.Add("Alumno", typeof(string));
            Listado.Columns.Add("Curso", typeof(string));
            Listado.Columns.Add("Nota", typeof(string));
            Listado.Columns.Add("Condicion", typeof(string));

            UsuarioLogic ul = new UsuarioLogic();
            List<Usuario> usuarios = ul.GetAll();
            CursoLogic curl = new CursoLogic();
            List<Curso> cursos = curl.GetAll();
            MateriaLogic matl = new MateriaLogic();
            List<Materia> materias = matl.GetAll();
            ComisionLogic coml = new ComisionLogic();
            List<Comision> comisiones = coml.GetAll();

            foreach(AlumnoInscripcion ai in inscripciones) {
                DataRow Linea = Listado.NewRow();

                Linea["ID"] = ai.ID;
                Linea["Nota"] = (ai.Nota == 0) ? "-" : ai.Nota.ToString();
                Linea["Condicion"] = ai.Condicion.ToString();

                Usuario user = usuarios.FirstOrDefault(x => x.ID == ai.IDAlumno);
                Linea["Alumno"] = user.Legajo + " - " + user.Apellido + ", " + user.Nombre;

                Curso curso = cursos.FirstOrDefault(x => x.ID == ai.IDCurso);
                Materia materia = materias.FirstOrDefault(x => x.ID == curso.IDMateria);
                Comision comision = comisiones.FirstOrDefault(x => x.ID == curso.IDComision);
                Linea["Curso"] = comision.Descripcion + " - " + materia.Descripcion;
                
                Listado.Rows.Add(Linea);
            }


            this.dgvAlumnoInscripciones.DataSource = Listado;
        }

        private void tsbNuevo_Click(object sender, EventArgs e){
            InscribirMaterias alumnoInscripcionDesktop = new InscribirMaterias(ApplicationForm.ModoForm.Alta, UsuarioActual);
            alumnoInscripcionDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e){
                InscribirMaterias alumnoInscripcionDesktop = new InscribirMaterias(ApplicationForm.ModoForm.Baja, UsuarioActual);
                alumnoInscripcionDesktop.ShowDialog();
                this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e){
            this.Close();
        }

        private void tsbEditar_Click(object sender, EventArgs e) {
            if (this.dgvAlumnoInscripciones.SelectedRows.Count != 0) {
                int ID = (int)this.dgvAlumnoInscripciones.SelectedRows[0].Cells["id"].Value;
                AlumnoInscripcionLogic ins = new AlumnoInscripcionLogic();
                AlumnoInscripcion inscripcion = ins.GetOne(ID);
                CargaNotas cn = new CargaNotas(inscripcion);
                cn.ShowDialog();
            }
        }
    }
}
