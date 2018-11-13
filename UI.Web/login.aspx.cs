using System;
using System.Collections.Generic;
using System.Data;
using Util;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using System.Globalization;


namespace UI.Web {
    public partial class Default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack)
            {
                lblError.Visible = false;
                lblBadLogin.Visible = false;
                if (Session["username"] != null && Session["tipo"] != null)
                {
                    Response.Redirect("/main/inicio.aspx");
                }
            }
        }

        protected void aceptarLinkButton_Click(object sender,EventArgs e) {
            try {
                UsuarioLogic ul = new UsuarioLogic();
                Usuario user = ul.GetOne(txtUser.Text);
                if (txtUser.Text.Equals(user.NombreUsuario) && Hashing.ValidatePassword(txtPassword.Text, user.Clave)) {
                    Session["username"] = user.NombreUsuario;
                    Session["tipo"] = user.TipoPersona;
                    Response.Redirect("/main/inicio.aspx");
                }
                else {
                    lblError.Visible = false;
                    lblBadLogin.Visible = true;
                    UpdatePanelBtn.Update();
                }
            }
            catch (Exception ex){
                lblError.Visible = true;
                lblBadLogin.Visible = false;
                UpdatePanelBtn.Update();
            }
        }
    }
}