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
                if (Session["tipo"] == null || (int)Session["tipo"] != 1) {
                    Response.Redirect("/login.aspx");
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
        }


        private void Listar() {

            AlumnoInscripcionLogic insl = new AlumnoInscripcionLogic();
            UsuarioLogic ul = new UsuarioLogic();
            Usuario user = ul.GetOne(Session["username"].ToString());

            List<AlumnoInscripcion> inscripciones =  insl.GetAll().Where(x => x.IDAlumno == user.ID).ToList();

            if (inscripciones.Count == 0) {
                divSinIns.Visible = true;
            }
            else {
            this.gvMisIns.DataSource = Listado.Generar(inscripciones);
            gvMisIns.DataBind();
            }


        }

    }
}