using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Business.Entities;
using Business.Logic;

namespace UI.Web.admin {
    public partial class Especialidades : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            EspecialidadLogic el = new EspecialidadLogic();
            gvEspecialidades.DataSource = el.GetListado();
            gvEspecialidades.DataBind();
        }

    }
}