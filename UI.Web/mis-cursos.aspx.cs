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
    public partial class mis_cursos : System.Web.UI.Page {
        private Usuario _UsuarioActual;
        private UsuarioLogic _UserLogic;

        public Usuario UsuarioActual { get => _UsuarioActual; set => _UsuarioActual = value; }
        public UsuarioLogic UserLogic { get => _UserLogic; set => _UserLogic = value; }

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                UserLogic = new UsuarioLogic();
                UsuarioActual = UserLogic.GetOne(Session["username"].ToString());
                Listar();
            }
        }

        private void Listar() {
            CursoLogic cl = new CursoLogic();
            gvCursos.DataSource = cl.GetListado(UsuarioActual);
            gvCursos.DataBind();
        }
    }
}