using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop {
    public partial class Menu : Form {

        private Usuario _UsuarioActual;
        public Usuario UsuarioActual { get => _UsuarioActual; set => _UsuarioActual = value; }

        public Menu(Usuario user) {
            InitializeComponent();

            UsuarioActual = user;
            switch (UsuarioActual.TipoPersona) {
                case 1:
                    MenuAlumno();
                    break;
                case 2:
                    MenuDocente();
                    break;
                case 3:
                    MenuAdmin();
                    break;
            }
        }

        private void MenuAlumno(){
            panelAD.Visible = true;
            tlpAlumno.Visible = true;
            MapearDeDatos();
            GenerarEstadisticas();
        }
        private void MenuDocente() {
            panelAD.Visible = true;
            tlpDocente.Visible = true;
            MapearDeDatos();
        }
        private void MenuAdmin() {
            panelAdmin.Visible = true;

        }

        private void MapearDeDatos() {
            lblNombre.Text = UsuarioActual.Nombre;
            lblApellido.Text = UsuarioActual.Apellido;
            lblUsuario.Text = UsuarioActual.NombreUsuario;
            lblFechaNac.Text = UsuarioActual.FechaNacimiento.ToString("dd/MM/yyyy");
            txtDireccion.Text = UsuarioActual.Direccion;
            txtTelefono.Text = UsuarioActual.Telefono;
            txtEmail.Text = UsuarioActual.Email;
        }
        public void MapearADatos() {
                UsuarioActual.Direccion = txtDireccion.Text;
                UsuarioActual.Telefono = txtTelefono.Text;
                UsuarioActual.Email = txtEmail.Text;
                UsuarioActual.State = BusinessEntity.States.Modified;
        }
        private bool Validar() {
            lblRedDirec.Visible = (string.IsNullOrWhiteSpace(txtDireccion.Text)) ? true : false;
            lblRedTel.Visible = (string.IsNullOrWhiteSpace(txtTelefono.Text)) ? true : false;
            lblRedEmail.Visible = (new EmailAddressAttribute().IsValid(txtEmail.Text)) ? false : true;

            if (lblRedDirec.Visible == true ||
                lblRedEmail.Visible == true ||
                lblRedTel.Visible == true) {
                return false;
            }
            else {
                return true;
            }

        }
        public void GuardarCambios() {
            MapearADatos();
            UsuarioLogic ul = new UsuarioLogic();
            ul.Save(UsuarioActual);
        }
        private void btnSalir_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void Menu_Load(object sender, EventArgs e) {
            lblBienvenido.Text = "Bienvenido " + UsuarioActual.Nombre + "!";
            lblLegajo.Text = "Legajo: " + UsuarioActual.Legajo;
        }
        private void GenerarEstadisticas() {
            AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
            List<AlumnoInscripcion> inscripciones = ail.GetAllFromUser(UsuarioActual.ID);
            lblAprobadas.Text = inscripciones.Count(x => x.Condicion == AlumnoInscripcion.Condiciones.Aprobado).ToString();
            lblCursando.Text = inscripciones.Count(x => x.Condicion == AlumnoInscripcion.Condiciones.Cursando).ToString();
            lblRegularizadas.Text = inscripciones.Count(x => x.Condicion == AlumnoInscripcion.Condiciones.Regular).ToString();
            lblLibres.Text = inscripciones.Count(x => x.Condicion == AlumnoInscripcion.Condiciones.Libre).ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e) {
            if (txtDireccion.Text != UsuarioActual.Direccion ||
                txtEmail.Text != UsuarioActual.Email ||
                txtTelefono.Text != UsuarioActual.Telefono) {

                if (this.Validar() == true) {
                    GuardarCambios();
                    MessageBox.Show("Los cambios se han guardado correctamente");

                }
                else {
                    MessageBox.Show("Verifique los datos ingresados");
                }
            }
            else {
                MessageBox.Show("No se ha modificado ningun dato");
            }
        }

        private void btnUsuarios_Click(object sender, EventArgs e) {
            ABMUsuarios formUsuarios = new ABMUsuarios();
            formUsuarios.ShowDialog();
        }

        private void btnPlanes_Click(object sender, EventArgs e) {
            ABMPlanes formPlanes = new ABMPlanes();
            formPlanes.ShowDialog();
        }

        private void btnEspecialidades_Click(object sender, EventArgs e) {
            ABMEspecialidades formEspecialidades = new ABMEspecialidades();
            formEspecialidades.ShowDialog();
        }

        private void btnMaterias_Click(object sender, EventArgs e) {
            ABMMaterias formMaterias = new ABMMaterias();
            formMaterias.ShowDialog();
        }

        private void btnComisiones_Click(object sender, EventArgs e) {
            Comisiones formComisiones = new Comisiones();
            formComisiones.ShowDialog();
        }

        private void btnInscripciones_Click(object sender, EventArgs e) {
            AlumnoInscripciones ai = new AlumnoInscripciones(UsuarioActual);
            ai.ShowDialog();
        }

        private void btnCursos_Click(object sender, EventArgs e) {
            Cursos formCursos = new Cursos(UsuarioActual);
            formCursos.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e) {
            AlumnoInscripciones ai = new AlumnoInscripciones(UsuarioActual);
            ai.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e) {
            AlumnoInscripcionDesktop aid = new AlumnoInscripcionDesktop(ApplicationForm.ModoForm.Alta, UsuarioActual);
            aid.ShowDialog();
        }

        private void btnCambiarPass_Click(object sender, EventArgs e) {
            MessageBox.Show("Falta implementar");
        }

        private void btnDocenteCurso_Click(object sender, EventArgs e) {
            DocentesCurso formDC = new DocentesCurso();
            formDC.ShowDialog();
        }
    }
}
