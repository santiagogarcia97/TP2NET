using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using Util;

namespace UI.Web {
    public partial class misCursos : System.Web.UI.Page {
        private Usuario _UsuarioActual;
        private UsuarioLogic _UserLogic;

        public Usuario UsuarioActual { get => _UsuarioActual; set => _UsuarioActual = value; }
        public UsuarioLogic UserLogic { get => _UserLogic; set => _UserLogic = value; }
        private int SelectedID {
            get {
                if (ViewState["SelectedID"] != null) return (int)ViewState["SelectedID"];
                else return 0;
            }
            set {
                ViewState["SelectedID"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e) {
            if(Session["username"] == null || Session["tipo"] == null || (int)Session["tipo"] != 2) {
                Response.Redirect("/login.aspx");
            }
            else { 
                SelectedID = 0;
                UserLogic = new UsuarioLogic();
                UsuarioActual = UserLogic.GetOne(Session["username"].ToString());
                lblCurso.Text = "Cursos de " + UsuarioActual.Apellido + ", " + UsuarioActual.Nombre + " al día " + DateTime.Now.ToString();
                Listar();
            }
        }

        private void Listar() {
            CursoLogic cl = new CursoLogic();
            gvCursos.DataSource = cl.GetListado(UsuarioActual);
            gvCursos.DataBind();
        }
        protected void gvCursos_SelectedIndexChanged(object sender, EventArgs e) {
            SelectedID = (gvCursos.SelectedValue != null) ? (int)gvCursos.SelectedValue : 0;
            Response.Redirect(String.Format("/main/cargaNotas.aspx?curso={0}", SelectedID));
        }
    }
}