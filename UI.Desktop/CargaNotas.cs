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

namespace UI.Desktop
{
    public partial class CargaNotas : ApplicationForm
    {
        private AlumnoInscripcion _AlumnoInscripcionActual;
        public AlumnoInscripcion AlumnoInscripcionActual { get => _AlumnoInscripcionActual; set => _AlumnoInscripcionActual = value; }

        public CargaNotas(){
            InitializeComponent();

            cbCondicion.DataSource = Enum.GetValues(typeof(AlumnoInscripcion.Condiciones));
            cbNota.Items.Clear();
            cbNota.Items.Add(string.Empty);
            for (int i = 0; i <= 10; i++) {
                cbNota.Items.Add(i.ToString());
            }
        }
        public CargaNotas(AlumnoInscripcion ai) : this(){
            AlumnoInscripcionActual = ai;
            MapearDeDatos();
        }
        private void CargaNotas_Load(object sender, EventArgs e) {
            lblRedCond.Visible = false;
            lblRedNota.Visible = false;
        }
        public override void MapearDeDatos()
        {
            labelID.Text = AlumnoInscripcionActual.ID.ToString();
            UsuarioLogic ul = new UsuarioLogic();
            Usuario alumno = ul.GetOne(AlumnoInscripcionActual.IDAlumno);
            lblAlumno.Text = alumno.Apellido + ", " + alumno.Nombre;
            lblLegajo.Text = alumno.Legajo.ToString();
            cbCondicion.SelectedItem = AlumnoInscripcionActual.Condicion;
            cbNota.SelectedItem = AlumnoInscripcionActual.Nota;

        }

        public override void MapearADatos(){
            AlumnoInscripcionActual.Condicion = (AlumnoInscripcion.Condiciones)cbCondicion.SelectedItem;
            AlumnoInscripcionActual.Nota = (string)cbNota.SelectedItem;
            AlumnoInscripcionActual.State = BusinessEntity.States.Modified;
        }
        public override void GuardarCambios()
        {
            MapearADatos();
            AlumnoInscripcionLogic auxAI = new AlumnoInscripcionLogic();
            auxAI.Save(AlumnoInscripcionActual);
        }

        public override bool Validar()
        {

            lblRedCond.Visible = (cbCondicion.SelectedItem == null) ? true : false;
            lblRedNota.Visible = (cbNota.SelectedItem == null) ? true : false;

            if (lblRedNota.Visible == true ||
                lblRedCond.Visible == true) {
                return false;
            }
            else {
                return true;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar()){
                GuardarCambios();
                this.Close();
            }
            else{
                MessageBox.Show("Complete todos los campos.");
            }
        }
        
    }
}
