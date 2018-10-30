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

            AlumnoInscripcionLogic ins = new AlumnoInscripcionLogic();
            this.dgvAlumnoInscripciones.DataSource = ins.GetListado();
        }

        private void tsbEliminar_Click(object sender, EventArgs e){
          //      InscribirMaterias alumnoInscripcionDesktop = new InscribirMaterias(ApplicationForm.ModoForm.Baja, UsuarioActual);
     //           alumnoInscripcionDesktop.ShowDialog();
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
