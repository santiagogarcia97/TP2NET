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


namespace UI.Web {
    public partial class misInscripciones : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["tipo"] == null || (int)Session["tipo"] == 3 || (int)Session["tipo"] == 2) {
                Response.Redirect("/inicio.aspx");
            }
            else {
                if (!IsPostBack) {
                    UsuarioLogic ul = new UsuarioLogic();
                    Usuario usuario = ul.GetOne(Session["username"].ToString());
                    lblAlumno.Text = "Estado de inscripciones de " + usuario.Apellido + ", " + usuario.Nombre + " al día " + DateTime.Now.ToString();
                    Listar();
                }
            }
        }


        private void Listar() {

            AlumnoInscripcionLogic ins = new AlumnoInscripcionLogic();
            List<AlumnoInscripcion> inscripciones = new List<AlumnoInscripcion>();
            UsuarioLogic ul = new UsuarioLogic();
            Usuario user = ul.GetOne(Session["username"].ToString());

            inscripciones = ins.GetAll().Where(x => x.IDAlumno == user.ID).ToList();
            
            DataTable Listado = new DataTable();
            Listado.Columns.Add("ID", typeof(int));
            Listado.Columns.Add("Curso", typeof(string));
            Listado.Columns.Add("Nota", typeof(string));
            Listado.Columns.Add("Condicion", typeof(string));

            List<Usuario> usuarios = ul.GetAll();
            CursoLogic curl = new CursoLogic();
            List<Curso> cursos = curl.GetAll();
            MateriaLogic matl = new MateriaLogic();
            List<Materia> materias = matl.GetAll();
            ComisionLogic coml = new ComisionLogic();
            List<Comision> comisiones = coml.GetAll();

            foreach (AlumnoInscripcion ai in inscripciones) {
                DataRow Linea = Listado.NewRow();

                Linea["ID"] = ai.ID;
                Linea["Nota"] = (ai.Nota == 0) ? "-" : ai.Nota.ToString();
                Linea["Condicion"] = ai.Condicion.ToString();

                Curso curso = cursos.FirstOrDefault(x => x.ID == ai.IDCurso);
                Materia materia = materias.FirstOrDefault(x => x.ID == curso.IDMateria);
                Comision comision = comisiones.FirstOrDefault(x => x.ID == curso.IDComision);
                Linea["Curso"] = comision.Descripcion + " - " + materia.Descripcion;

                Listado.Rows.Add(Linea);
            }


            this.gvMisIns.DataSource = Listado;
            gvMisIns.DataBind();

        }

    }
}