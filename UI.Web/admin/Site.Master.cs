using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web {
    public partial class Site : System.Web.UI.MasterPage {
        protected void Page_Load(object sender, EventArgs e) {
    /*        if (Session["username"] == null || Session["tipo"] == null) {
                Response.Redirect("../Default.aspx");
            }
            else {
                lblUser.Text = Session["username"].ToString();
                if ((int)Session["tipo"] == 3) {
                    ddABM.Visible = true;
                }
                else {
                    ddABM.Visible = false;
                }
            }*/
        }
    }
}