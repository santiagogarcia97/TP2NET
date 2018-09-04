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
    public partial class AlumnoInscripciones : ApplicationForm{

        private Usuario _UsuarioActual;
        public Usuario UsuarioActual { get => UsuarioActual; set => UsuarioActual = value; }

        public AlumnoInscripciones(){
            InitializeComponent();
            this.dgvAlumnoInscripciones.AutoGenerateColumns = false;
        }
        public AlumnoInscripciones(Usuario user) : this() {
            UsuarioActual = user;
            if(UsuarioActual.TipoPersona == 1) {
                tcUsuarios.TopToolStripPanel.Visible = false;
            }
            else if (UsuarioActual.TipoPersona == 3) {
                tcUsuarios.TopToolStripPanel.Visible = true;
            }
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
         //   CursoMatComLogic cmcl = new CursoMatComLogic();
         //   List<CursoMatCom> cursos = cmcl.GetAll();

            foreach(AlumnoInscripcion ai in inscripciones) {
                DataRow Linea = Listado.NewRow();

                Linea["ID"] = ai.ID;
                Linea["Nota"] = (ai.Nota.Equals("")) ? "-" : ai.Nota;
                Linea["Condicion"] = ai.Condicion.ToString();
                foreach(Usuario user in usuarios) {
                    if(user.ID == ai.IDAlumno) {
                        Linea["Alumno"] = user.Legajo + " - " + user.Apellido + ", " + user.Nombre;
                        break;
                    }
                }
              //  foreach(CursoMatCom cmc in cursos) {
                //    if(cmc.ID == ai.IDCurso) {
                  //      Linea["Curso"] = cmc.DescComision + " - " + cmc.DescMateria;
                   //}
                //}
                Listado.Rows.Add(Linea);
            }


            this.dgvAlumnoInscripciones.DataSource = Listado;
        }

        private void tsbNuevo_Click(object sender, EventArgs e){
            AlumnoInscripcionDesktop alumnoInscripcionDesktop = new AlumnoInscripcionDesktop(ApplicationForm.ModoForm.Alta, UsuarioActual);
            alumnoInscripcionDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e){
            if (this.dgvAlumnoInscripciones.SelectedRows.Count != 0){
                int ID = ((Business.Entities.AlumnoInscripcion)this.dgvAlumnoInscripciones.SelectedRows[0].DataBoundItem).ID;
                AlumnoInscripcionDesktop alumnoInscripcionDesktop = new AlumnoInscripcionDesktop(ApplicationForm.ModoForm.Baja, UsuarioActual);
                alumnoInscripcionDesktop.ShowDialog();
                this.Listar();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e){
            this.Close();
        }
    }
}
