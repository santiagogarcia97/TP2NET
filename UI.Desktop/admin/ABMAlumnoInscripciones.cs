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

namespace UI.Desktop.admin{
    public partial class ABMAlumnoInscripciones : ApplicationForm{

        public ABMAlumnoInscripciones(){
            InitializeComponent();
            this.dgvAlumnoInscripciones.AutoGenerateColumns = false;
        }
       
        private void AlumnoInscripciones_Load(object sender, EventArgs e) {
            Listar();
        }

        public void Listar(){
            this.dgvAlumnoInscripciones.DataSource = null;
            this.dgvAlumnoInscripciones.Refresh();

            AlumnoInscripcionLogic insl = new AlumnoInscripcionLogic();
            List<AlumnoInscripcion> inscripciones = insl.GetAll().Where(x => x.Habilitado == true).ToList();

            if (inscripciones.Count() == 0) {
                MessageBox.Show("No hay inscripciones cargadas!");
            }
            else {
                this.dgvAlumnoInscripciones.DataSource = Listado.Generar(inscripciones);
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e){
 /*           if (this.dgvAlumnoInscripciones.SelectedRows.Count != 0) {
                int ID = (int)this.dgvAlumnoInscripciones.SelectedRows[0].Cells["id"].Value;
                AlumnoInscripcionLogic ins = new AlumnoInscripcionLogic();
                AlumnoInscripcion inscripcion = ins.GetOne(ID);
                CargaNotas cn = new CargaNotas(inscripcion);
                cn.ShowDialog();
            }*/
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
