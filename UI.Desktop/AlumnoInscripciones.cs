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

        private int _AlumnoID;
        public int AlumnoID { get => _AlumnoID; set => _AlumnoID = value; }

        public AlumnoInscripciones(int aID){
            InitializeComponent();
            AlumnoID = aID;
            this.dgvAlumnoInscripciones.AutoGenerateColumns = false;
        }
        private void AlumnoInscripciones_Load(object sender, EventArgs e) {
            Listar();
        }

        public void Listar(){
            AlumnoInscripcionLogic ins = new AlumnoInscripcionLogic();
            List<AlumnoInscripcion> inscripciones = ins.GetAll().Where(x => x.ID == AlumnoID).ToList();
            if (inscripciones.Count() == 0){
                MessageBox.Show("No hay inscripciones cargadas!");
            }
            this.dgvAlumnoInscripciones.DataSource = inscripciones;
        }

        private void tsbNuevo_Click(object sender, EventArgs e){
            InscripcionDesktop alumnoInscripcionDesktop = new InscripcionDesktop(ApplicationForm.ModoForm.Alta, AlumnoID);
            alumnoInscripcionDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e){
            if (this.dgvAlumnoInscripciones.SelectedRows.Count != 0){
                int ID = ((Business.Entities.AlumnoInscripcion)this.dgvAlumnoInscripciones.SelectedRows[0].DataBoundItem).ID;
                AlumnoInscripcionDesktop alumnoInscripcionDesktop = new AlumnoInscripcionDesktop(ApplicationForm.ModoForm.Baja, AlumnoID, ID);
                alumnoInscripcionDesktop.ShowDialog();
                this.Listar();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e){
            this.Close();
        }
    }
}
