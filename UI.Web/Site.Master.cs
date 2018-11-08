using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web {
    public partial class Site : System.Web.UI.MasterPage {
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["username"] == null || Session["tipo"] == null) {
                Response.Redirect("/login.aspx");
            }
            else {
                lblUser.Text = Session["username"].ToString();
                if ((int)Session["tipo"] == 3) {
                    ddABM.Visible = true;
                    ddCursos.Visible = false;
                    MisCursos.Visible = false;
                }
                else if((int)Session["tipo"] == 2) {
                    ddABM.Visible = false;
                    ddCursos.Visible = false;
                    MisCursos.Visible = true;
                }
                else if ((int)Session["tipo"] == 1) {
                    ddABM.Visible = false;
                    ddCursos.Visible = true;
                    MisCursos.Visible = false;
                }
            }
        }

        protected void btnLogOut_Click(object sender, EventArgs e) {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("/login.aspx");
        }
    }
}