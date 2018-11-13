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

        public frmReportes() {
            InitializeComponent();
            ReportePlanes();
        }
        public frmReportes(int idAlumno){
            InitializeComponent();
            ReporteIns(idAlumno);
        }
        public frmReportes(Usuario user) {
            InitializeComponent();
            ReporteCursos(user);
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
        private void ReporteCursos(Usuario Docente) {
            List<Curso> cursos = new List<Curso>();

            DocenteCursoLogic dcl = new DocenteCursoLogic();
            List<DocenteCurso> dclist = dcl.GetAllFromUser(Docente.ID);
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
    }
}
