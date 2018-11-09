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
            if (!IsPostBack) {
                SelectedID = 0;
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
        private void ButtonState() {

            if (SelectedID == 0) {
                btnCarga.CssClass = "btn btn-outline-secondary btn-sm";
                btnCarga.Enabled = false;
                btnDeseleccionar.Visible = false;
            }
            else {
                btnCarga.CssClass = "btn btn-outline-success btn-sm";
                btnCarga.Enabled = true;
                btnDeseleccionar.Visible = true;
            }
            UpdatePanelButtons.Update();
        }
        protected void gvCursos_SelectedIndexChanged(object sender, EventArgs e) {
            SelectedID = (gvCursos.SelectedValue != null) ? (int)gvCursos.SelectedValue : 0;
            ButtonState();
        }

        protected void btnCarga_Click(object sender, EventArgs e) {
            Response.Redirect(String.Format("/main/cargaNotas.aspx?curso={0}", SelectedID));
        }
    }
}