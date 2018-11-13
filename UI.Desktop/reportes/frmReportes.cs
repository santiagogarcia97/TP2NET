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
    }
}
