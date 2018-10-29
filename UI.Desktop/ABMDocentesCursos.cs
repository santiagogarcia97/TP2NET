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
    public partial class ABMDocentesCursos : ApplicationForm{

        public ABMDocentesCursos(){
            InitializeComponent();
            this.dgvDocenteCurso.AutoGenerateColumns = false;
        }
        private void DocenteCurso_Load(object sender, EventArgs e) {
            Listar();
        }

        public void Listar(){
            this.dgvDocenteCurso.DataSource = null;
            this.dgvDocenteCurso.Refresh();

            UsuarioLogic ul = new UsuarioLogic();
            List<Usuario> usuarios = ul.GetAll();
            CursoLogic cursol = new CursoLogic();
            List<Curso> cursos = cursol.GetAll();
            ComisionLogic comisionl = new ComisionLogic();
            List<Comision> comisiones = comisionl.GetAll();
            MateriaLogic matl = new MateriaLogic();
            List<Materia> materias = matl.GetAll();

            DocenteCursoLogic dcl = new DocenteCursoLogic();
            List<DocenteCurso> dclist = new List<DocenteCurso>();
            dclist = dcl.GetAll().Where(x => x.Habilitado == true).ToList();

            if (dclist.Count() == 0) {
                MessageBox.Show("No existen docentes asignados a cursos");
            }
            else {

                DataTable Listado = new DataTable();
                Listado.Columns.Add("ID", typeof(int));
                Listado.Columns.Add("Curso", typeof(string));
                Listado.Columns.Add("Docente", typeof(string));
                Listado.Columns.Add("Cargo", typeof(string));

                foreach (DocenteCurso dc in dclist) {
                    DataRow Linea = Listado.NewRow();
                    Linea["ID"] = dc.ID;
                    Linea["Cargo"] = dc.Cargo.ToString();

                    Curso curso = cursos.FirstOrDefault(x => x.ID == dc.IDCurso);
                    Materia materia = materias.FirstOrDefault(x => x.ID == curso.IDMateria);
                    Comision comision = comisiones.FirstOrDefault(x => x.ID == curso.IDComision);
                    Usuario docente = usuarios.FirstOrDefault(x => x.ID == dc.IDDocente);
                    Linea["Curso"] = comision.Descripcion + " - " + materia.Descripcion;
                    Linea["Docente"] = docente.Legajo.ToString() + " - " + docente.Apellido + " "+ docente.Nombre;

                    Listado.Rows.Add(Linea);
                }

                this.dgvDocenteCurso.DataSource = Listado;
            }
        }

        private void tsbNuevo_Click(object sender, EventArgs e){
            ABMDocentesCursosDesktop docentesCursosDesktop = new ABMDocentesCursosDesktop(ApplicationForm.ModoForm.Alta);
            docentesCursosDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e){
            if (this.dgvDocenteCurso.SelectedRows.Count != 0) {
                int ID = (int)this.dgvDocenteCurso.SelectedRows[0].Cells["id"].Value;
                ABMDocentesCursosDesktop docentesCursosDesktop = new ABMDocentesCursosDesktop(ID, ApplicationForm.ModoForm.Baja);
                docentesCursosDesktop.ShowDialog();
                this.Listar();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e){
            this.Close();
        }
    }
}
