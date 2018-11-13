using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using Util;
using System.Data;
using Microsoft.Reporting.WebForms;

namespace UI.Web.main {
    public partial class reportes : System.Web.UI.Page {

        protected void Page_Load(object sender, EventArgs e) {
            UsuarioLogic ul = new UsuarioLogic();
            Usuario user = ul.GetOne(Session["username"].ToString());
            switch ((int)Session["tipo"]) {
                case 1:
                    GenerarIns(user.ID);
                    break;
                case 2:
                    GenerarCursos(user.ID);
                    break;
                case 3:
                    GenerarPlanes();
                    break;
            }

        }
        private void GenerarPlanes() {

            PlanLogic pl = new PlanLogic();
            List<Plan> planes = pl.GetAll();
            DataTable dt = Listado.Generar(planes);

            this.rvReportes.LocalReport.ReportEmbeddedResource = "UI.Web.reportes.repPlanes.rdlc";
            ReportDataSource DataSet1 = new ReportDataSource("Planes", dt);
            this.rvReportes.LocalReport.DataSources.Clear();
            this.rvReportes.LocalReport.DataSources.Add(DataSet1);
            this.rvReportes.LocalReport.Refresh();
        }
        private void GenerarIns(int idAlumno) {

            AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
            List<AlumnoInscripcion> inscripciones = ail.GetAllFromUser(idAlumno);
            DataTable dt = Listado.Generar(inscripciones);

            this.rvReportes.LocalReport.ReportEmbeddedResource = "UI.Web.reportes.repInscripciones.rdlc";
            ReportDataSource DataSet1 = new ReportDataSource("Inscripciones", dt);
            this.rvReportes.LocalReport.DataSources.Clear();
            this.rvReportes.LocalReport.DataSources.Add(DataSet1);
            this.rvReportes.LocalReport.Refresh();
        }
        private void GenerarCursos(int idDocente) {
            List<Curso> cursos = new List<Curso>();

            DocenteCursoLogic dcl = new DocenteCursoLogic();
            List<DocenteCurso> dclist = dcl.GetAllFromUser(idDocente);
            CursoLogic cl = new CursoLogic();

            foreach (DocenteCurso dc in dclist) {
                cursos.Add(cl.GetOne(dc.IDCurso));
            }

            DataTable dt = Listado.Generar(cursos);

            this.rvReportes.LocalReport.ReportEmbeddedResource = "UI.Web.reportes.repCursos.rdlc";
            ReportDataSource DataSet1 = new ReportDataSource("Cursos", dt);
            this.rvReportes.LocalReport.DataSources.Clear();
            this.rvReportes.LocalReport.DataSources.Add(DataSet1);
            this.rvReportes.LocalReport.Refresh();
        }
    }
}