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

namespace UI.Desktop
{
    public partial class Inscripciones : ApplicationForm
    {
        public Inscripciones()
        {
            InitializeComponent();
            this.dgvInscripciones.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            AlumnoInscripcionLogic ins = new AlumnoInscripcionLogic();
            List<AlumnoInscripcion> inscripciones = ins.GetAll();
            if (inscripciones.Count() == 0)
            {
                MessageBox.Show("No hay inscripciones cargadas!");
            }
            this.dgvInscripciones.DataSource = inscripciones;
        }

        private void Inscripciones_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            InscripcionDesktop alumnoInscripcionDesktop = new InscripcionDesktop(ApplicationForm.ModoForm.Alta, InscripcionDesktop.AccessForm.Abierto);
            alumnoInscripcionDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvInscripciones.SelectedRows.Count != 0)
            {
                int ID = ((Business.Entities.AlumnoInscripcion)this.dgvInscripciones.SelectedRows[0].DataBoundItem).ID;
                InscripcionDesktop alumnoInscripcionDesktop = new InscripcionDesktop(ApplicationForm.ModoForm.Modificacion, InscripcionDesktop.AccessForm.Abierto, ID);
                alumnoInscripcionDesktop.ShowDialog();
                this.Listar();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvInscripciones.SelectedRows.Count != 0)
            {
                int ID = ((Business.Entities.AlumnoInscripcion)this.dgvInscripciones.SelectedRows[0].DataBoundItem).ID;
                InscripcionDesktop alumnoInscripcionDesktop = new InscripcionDesktop(ApplicationForm.ModoForm.Baja, InscripcionDesktop.AccessForm.Abierto, ID);
                alumnoInscripcionDesktop.ShowDialog();
                this.Listar();
            }
        }

        private void tsbConsultar_Click(object sender, EventArgs e)
        {
            if (this.dgvInscripciones.SelectedRows.Count != 0)
            {
                int ID = ((Business.Entities.AlumnoInscripcion)this.dgvInscripciones.SelectedRows[0].DataBoundItem).ID;
                InscripcionDesktop alumnoInscripcionDesktop = new InscripcionDesktop(ApplicationForm.ModoForm.Consulta, InscripcionDesktop.AccessForm.Abierto, ID);
                alumnoInscripcionDesktop.ShowDialog();
                this.Listar();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
