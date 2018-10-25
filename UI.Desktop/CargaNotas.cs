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

            cbCondicion.ValueMember = "id_cond";
            cbCondicion.DisplayMember = "desc_cond";
            cbCondicion.DataSource = GenerarComboBox.getCondiciones();
            cbCondicion.SelectedValue = 4;
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
            cbCondicion.SelectedValue = AlumnoInscripcionActual.Condicion;
            nudNota.Value = AlumnoInscripcionActual.Nota;

        }

        public override void MapearADatos(){
            AlumnoInscripcionActual.Condicion = (AlumnoInscripcion.Condiciones)cbCondicion.SelectedValue;
            AlumnoInscripcionActual.Nota = (int)nudNota.Value;
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

            lblRedCond.Visible = (cbCondicion.SelectedItem == null || (int)cbCondicion.SelectedValue == 0) ? true : false;
            lblRedNota.Visible = ((int)nudNota.Value == 0 && (int)cbCondicion.SelectedValue == 1) ? true : false;

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
