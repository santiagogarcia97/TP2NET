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
            AlumnoInscripcionLogic esp = new AlumnoInscripcionLogic();
            List<AlumnoInscripcion> especialidades = esp.GetAll();
            if (especialidades.Count() == 0)
            {
                MessageBox.Show("No hay inscripciones cargadas!");
            }
            this.dgvInscripciones.DataSource = especialidades;
        }

        private void Inscripciones_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            AlumnoInscripcionDesktop especialidadDesktop = new AlumnoInscripcionDesktop(ApplicationForm.ModoForm.Alta, AlumnoInscripcionDesktop.AccessForm.Abierto);
            especialidadDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvInscripciones.SelectedRows.Count != 0)
            {
                int ID = ((Business.Entities.AlumnoInscripcion)this.dgvInscripciones.SelectedRows[0].DataBoundItem).ID;
                AlumnoInscripcionDesktop especialidadDesktop = new AlumnoInscripcionDesktop(ApplicationForm.ModoForm.Modificacion, AlumnoInscripcionDesktop.AccessForm.Abierto, ID);
                especialidadDesktop.ShowDialog();
                this.Listar();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvInscripciones.SelectedRows.Count != 0)
            {
                int ID = ((Business.Entities.AlumnoInscripcion)this.dgvInscripciones.SelectedRows[0].DataBoundItem).ID;
                AlumnoInscripcionDesktop especialidadDesktop = new AlumnoInscripcionDesktop(ApplicationForm.ModoForm.Baja, AlumnoInscripcionDesktop.AccessForm.Abierto, ID);
                especialidadDesktop.ShowDialog();
                this.Listar();
            }
        }

        private void tsbConsultar_Click(object sender, EventArgs e)
        {
            if (this.dgvInscripciones.SelectedRows.Count != 0)
            {
                int ID = ((Business.Entities.AlumnoInscripcion)this.dgvInscripciones.SelectedRows[0].DataBoundItem).ID;
                AlumnoInscripcionDesktop especialidadDesktop = new AlumnoInscripcionDesktop(ApplicationForm.ModoForm.Consulta, AlumnoInscripcionDesktop.AccessForm.Abierto, ID);
                especialidadDesktop.ShowDialog();
                this.Listar();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
