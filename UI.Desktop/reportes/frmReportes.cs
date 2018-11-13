using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;
using Microsoft.Reporting.WinForms;
using Util;

namespace UI.Desktop.reportes {
    public partial class frmReportes : Form {

        public frmReportes(Usuario user) {
            InitializeComponent();
            switch (user.TipoPersona) {
                case Usuario.TiposPersona.Administrador:
                    ReportePlanes();
                    msAdmin.Visible = true;
                    break;
                case Usuario.TiposPersona.Alumno:
                    ReporteIns(user.ID);
                    msAdmin.Visible = false;
                    break;
                case Usuario.TiposPersona.Docente:
                    ReporteCursos(user.ID);
                    msAdmin.Visible = false;
                    break;
            }
        }


        private void ReportePlanes() {

            PlanLogic pl = new PlanLogic();
            List<Plan> planes = pl.GetAll();                                
            DataTable dt = Listado.Generar(planes);

            this.rvReportes.LocalReport.ReportEmbeddedResource = "UI.Desktop.reportes.repPlanes.rdlc";
            ReportDataSource DataSet1 = new ReportDataSource("Planes", dt);
            this.rvReportes.LocalReport.DataSources.Clear();
            this.rvReportes.LocalReport.DataSources.Add(DataSet1);
            this.rvReportes.LocalReport.Refresh();

            this.rvReportes.RefreshReport();

        }
        private void ReporteIns(int idAlumno) {
            AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
            List<AlumnoInscripcion> inscripciones = ail.GetAllFromUser(idAlumno);
            DataTable dt = Listado.Generar(inscripciones);

            this.rvReportes.LocalReport.ReportEmbeddedResource = "UI.Desktop.reportes.repInscripciones.rdlc";
            ReportDataSource DataSet1 = new ReportDataSource("Inscripciones", dt);
            this.rvReportes.LocalReport.DataSources.Clear();
            this.rvReportes.LocalReport.DataSources.Add(DataSet1);
            this.rvReportes.LocalReport.Refresh();

            this.rvReportes.RefreshReport();

        }
        private void ReporteUsuarios() {
            UsuarioLogic ul = new UsuarioLogic();
            List<Usuario> usuarios = ul.GetAll();
            DataTable dt = Listado.Generar(usuarios);

            this.rvReportes.LocalReport.ReportEmbeddedResource = "UI.Desktop.reportes.repUsuarios.rdlc";
            ReportDataSource DataSet1 = new ReportDataSource("Usuarios", dt);
            this.rvReportes.LocalReport.DataSources.Clear();
            this.rvReportes.LocalReport.DataSources.Add(DataSet1);
            this.rvReportes.LocalReport.Refresh();

            this.rvReportes.RefreshReport();

        }
        private void ReporteCursos(int idDoc) {
            List<Curso> cursos = new List<Curso>();

            DocenteCursoLogic dcl = new DocenteCursoLogic();
            List<DocenteCurso> dclist = dcl.GetAllFromUser(idDoc);
            CursoLogic cl = new CursoLogic();

            foreach (DocenteCurso dc in dclist) {
                cursos.Add(cl.GetOne(dc.IDCurso));
            }

            DataTable dt = Listado.Generar(cursos);

            this.rvReportes.LocalReport.ReportEmbeddedResource = "UI.Desktop.reportes.repCursos.rdlc";
            ReportDataSource DataSet1 = new ReportDataSource("Cursos", dt);
            this.rvReportes.LocalReport.DataSources.Clear();
            this.rvReportes.LocalReport.DataSources.Add(DataSet1);
            this.rvReportes.LocalReport.Refresh();

            this.rvReportes.RefreshReport();

        }

        private void planesToolStripMenuItem_Click(object sender, EventArgs e) {
            ReportePlanes();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e) {
            ReporteUsuarios();
        }
    }
}
