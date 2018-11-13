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
using Util;
using UI.Desktop.admin;
using UI.Desktop.reportes;

namespace UI.Desktop {
    public partial class Menu : Form {

        private Usuario _UsuarioActual;
        public Usuario UsuarioActual { get => _UsuarioActual; set => _UsuarioActual = value; }

        public Menu(Usuario user) {
            InitializeComponent();

            UsuarioActual = user;
            switch (UsuarioActual.TipoPersona) {
                case Usuario.TiposPersona.Alumno:
                    MenuAlumno();
                    break;
                case Usuario.TiposPersona.Docente:
                    MenuDocente();
                    break;
                case Usuario.TiposPersona.Administrador:
                    MenuAdmin();
                    break;
            }
            MapearDeDatos();
        }

        private void MenuAlumno(){
            gbAdmin.Visible = false;
            TSMIabms.Visible = false;
            TSMIMisCursos.Visible = false;
            GenerarEstadisticas();
            gbAcademico.Visible = true;
            planesToolStripMenuItem.Visible = false;
        }
        private void MenuDocente() {
            TSMIabms.Visible = false;
            TSMIMisInscripciones.Visible = false;
            gbAdmin.Visible = false;
            gbAcademico.Visible = true;
            planesToolStripMenuItem.Visible = false;
        }
        private void MenuAdmin() {
            TSMIMisInscripciones.Visible = false;
            TSMIMisCursos.Visible = false;
            gbAdmin.Visible = true;
            gbAcademico.Visible = false;
            inscripcionesToolStripMenuItem.Visible = false;
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
            lblRedDirec.Visible = (Validaciones.ValTexto(txtDireccion.Text)) ? true : false;
            lblRedTel.Visible = (Validaciones.ValTexto(txtTelefono.Text)) ? true : false;
            lblRedEmail.Visible = (Validaciones.ValTexto(txtEmail.Text)) ? true : false;

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

   /*     private void btnInscripciones_Click(object sender, EventArgs e) {
            MisInscripciones ai = new MisInscripciones(UsuarioActual);
            ai.ShowDialog();
        }
*/
        private void btnCambiarPass_Click(object sender, EventArgs e) {
            CambiarClave aux = new CambiarClave(UsuarioActual);
            aux.ShowDialog();
        }

        private void TSMIusuario_Click(object sender, EventArgs e) {
            ABMUsuarios formUsuarios = new ABMUsuarios();
            formUsuarios.ShowDialog();
        }

        private void TSMIespecialidades_Click(object sender, EventArgs e) {
            ABMEspecialidades formEspecialidades = new ABMEspecialidades();
            formEspecialidades.ShowDialog();
        }

        private void TSMIplanes_Click(object sender, EventArgs e) {
            ABMPlanes formPlanes = new ABMPlanes();
            formPlanes.ShowDialog();
        }

        private void TSMImaterias_Click(object sender, EventArgs e) {
            ABMMaterias formMaterias = new ABMMaterias();
            formMaterias.ShowDialog();
        }

        private void TSMIcomisiones_Click(object sender, EventArgs e) {
            ABMComisiones formComisiones = new ABMComisiones();
            formComisiones.ShowDialog();
        }

        private void TSMIcursos_Click(object sender, EventArgs e) {
            ABMCursos formCursos = new ABMCursos();
            formCursos.ShowDialog();
        }

        private void TSMIdocentes_Click(object sender, EventArgs e) {
            ABMDocentesCursos formDC = new ABMDocentesCursos();
            formDC.ShowDialog();
        }

        private void TSMImateriasInscripto_Click(object sender, EventArgs e) {
            MisInscripciones ai = new MisInscripciones(UsuarioActual);
            ai.ShowDialog();
        }

        private void TSMIinscribirseACursado_Click(object sender, EventArgs e) {
            InscribirMaterias aid = new InscribirMaterias(ApplicationForm.ModoForm.Alta, UsuarioActual);
            aid.ShowDialog();
        }

        private void TSMIinscripciones_Click(object sender, EventArgs e) {
            ABMAlumnoInscripciones formAI = new ABMAlumnoInscripciones();
            formAI.ShowDialog();
        }


        private void planesToolStripMenuItem_Click(object sender, EventArgs e) {
            frmReportes reps = new frmReportes();
            reps.ShowDialog();
        }

        private void inscripcionesToolStripMenuItem_Click(object sender, EventArgs e) {
            frmReportes reps = new frmReportes(UsuarioActual.ID);
            reps.ShowDialog();
        }
    }
}
