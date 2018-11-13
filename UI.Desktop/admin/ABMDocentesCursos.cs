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

namespace UI.Desktop.admin
{
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

            DocenteCursoLogic dcl = new DocenteCursoLogic();
            List<DocenteCurso> dclist = dcl.GetAll().Where(x => x.Habilitado == true).ToList(); ;
           
            if (dclist.Count() == 0) {
                MessageBox.Show("No hay Docentes-Cursos cargados!");
            }
            else {
                this.dgvDocenteCurso.DataSource = Listado.Generar(dclist);
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
