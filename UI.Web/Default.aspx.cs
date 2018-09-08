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

        }

        protected void aceptarLinkButton_Click(object sender,EventArgs e) {
            UsuarioLogic ul = new UsuarioLogic();
            Usuario user = ul.GetOne(userTextBox.Text);
            if(userTextBox.Text.Equals(user.NombreUsuario) && passwordTextBox.Text.Equals(user.Clave)) {
                Response.Redirect("Usuarios.aspx");
            }
            else if(userTextBox.Text.Equals(user.NombreUsuario) && !passwordTextBox.Text.Equals(user.Clave)) {
                MsgBox("La contraseña es incorrecta.",this.Page,this);

            }
            else {
                MsgBox("El usuario no existe.",this.Page,this);
            }
        }

        public void MsgBox(String ex,Page pg,Object obj) {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n","\\n").Replace("'","") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype,s,s.ToString());
        }
    }
}