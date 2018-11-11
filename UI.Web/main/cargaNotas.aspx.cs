using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using Util;

namespace UI.Web.main {
    public partial class cargaNotas : System.Web.UI.Page {

        private AlumnoInscripcion _AlumnoInscripcionActual;
        private AlumnoInscripcionLogic _AlumnoInscripcionLogic;

        public AlumnoInscripcion AlumnoInscripcionActual { get => _AlumnoInscripcionActual; set => _AlumnoInscripcionActual = value; }
        private int _IDCurso;
        private int IDCurso { get => _IDCurso; set => _IDCurso = value; }

        private int SelectedID {
            get {
                if (ViewState["SelectedID"] != null) return (int)ViewState["SelectedID"];
                else return 0;
            }
            set {
                ViewState["SelectedID"] = value;
            }
        }
        public AlumnoInscripcionLogic AlumnoInscripcionLogic {
            get {
                if (_AlumnoInscripcionLogic == null) { _AlumnoInscripcionLogic = new AlumnoInscripcionLogic(); }
                return _AlumnoInscripcionLogic;
            }
        }


        protected void Page_Load(object sender, EventArgs e) {
            if (Session["tipo"] == null || (int)Session["tipo"] != 2) {
                Response.Redirect("/login.aspx");
            }
            else {
                IDCurso = int.Parse(Request.QueryString["curso"]);
                UsuarioLogic ul = new UsuarioLogic();
                Usuario user = ul.GetOne(Session["username"].ToString());
                DocenteCursoLogic dcl = new DocenteCursoLogic();
                DocenteCurso dc = dcl.GetOne(user.ID, IDCurso);

                if (dc.ID != 0) {
                    if (!IsPostBack) {
                        Listar();
                        GenerarCondiciones();
                        gvIns.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                }
                else {
                    Response.Redirect("/main/misCursos.aspx");
                }
            }
        }
        private void Listar() {
            List<AlumnoInscripcion> ins = new List<AlumnoInscripcion>();
            ins = AlumnoInscripcionLogic.GetAllFromCurso(IDCurso);

            gvIns.DataSource = Listado.Generar(ins);
            gvIns.DataBind();
            gvIns.SelectedIndex = -1;
        }

        private void LoadForm() {
            AlumnoInscripcionActual = AlumnoInscripcionLogic.GetOne(SelectedID);
            UsuarioLogic ul = new UsuarioLogic();
            Usuario user = ul.GetOne(AlumnoInscripcionActual.IDAlumno);

            lblID.Text = AlumnoInscripcionActual.ID.ToString();
            lblAlumno.Text = user.Legajo.ToString() + " - " + user.Apellido + ", " + user.Nombre; 
            txtNota.Text = AlumnoInscripcionActual.Nota.ToString();

            ddCondicion.SelectedValue = ((int)AlumnoInscripcionActual.Condicion).ToString();

            UpdatePanelModal.Update();
        }

        private void LoadEntity() {
            AlumnoInscripcionActual = AlumnoInscripcionLogic.GetOne(SelectedID);

            AlumnoInscripcionActual.Condicion = (AlumnoInscripcion.Condiciones)int.Parse(ddCondicion.SelectedValue);
            AlumnoInscripcionActual.Nota = int.Parse(txtNota.Text);
            AlumnoInscripcionActual.State = BusinessEntity.States.Modified;
        }
        private void SaveEntity() {
            AlumnoInscripcionLogic.Save(AlumnoInscripcionActual);
        }

        protected void gvIns_SelectedIndexChanged(object sender, EventArgs e) {
            SelectedID = (gvIns.SelectedValue != null) ? (int)gvIns.SelectedValue : 0;

            if (SelectedID != 0) {
                LoadForm();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#ModalInscripciones').modal('show');", true);
            }
        }


        protected void btnAceptar_Click(object sender, EventArgs e) {
            if (Validar() == true) {
                LoadEntity();
                SaveEntity();
                SelectedID = 0;
                Listar();
                UpdatePanelGrid.Update();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#ModalInscripciones').modal('hide');", true);
            }
            UpdatePanelModal.Update();
        }

        private bool Validar() {
            bool isvalid = true;

            if (string.IsNullOrEmpty(txtNota.Text) ||
                string.IsNullOrWhiteSpace(txtNota.Text) ||
                int.Parse(txtNota.Text) == 0) {
                txtNota.CssClass = "form-control is-invalid";
                isvalid = false;
            }
            else {
                txtNota.CssClass = "form-control";
            }
   /*         if (ddAlumno.SelectedValue == string.Empty || int.Parse(ddAlumno.SelectedValue) == 0) {
                ddAlumno.CssClass = "form-control is-invalid";
                isvalid = false;
            }
            else {
                ddAlumno.CssClass = "form-control";
            }
            if (ddCondicion.SelectedValue == string.Empty || int.Parse(ddCondicion.SelectedValue) == 0) {
                ddCondicion.CssClass = "form-control is-invalid";
                isvalid = false;
            }
            else {
                ddCondicion.CssClass = "form-control";
            }
            if (ddCurso.SelectedValue == string.Empty || int.Parse(ddCurso.SelectedValue) == 0) {
                ddCurso.CssClass = "form-control is-invalid";
                isvalid = false;
            }
            else {
                ddCurso.CssClass = "form-control";
            }
*/
            return isvalid;
        }

        private void SetFormControlCSS() {
            txtNota.CssClass = "form-control";
   //         d.CssClass = "form-control";
            ddCondicion.CssClass = "form-control";
   //         ddAlumno.CssClass = "form-control";
        }
        protected void GenerarCondiciones() {
            ddCondicion.DataValueField = "id_cond";
            ddCondicion.DataTextField = "desc_cond";
            ddCondicion.DataSource = GenerarComboBox.getCondiciones();
            ddCondicion.DataBind();
            ddCondicion.SelectedValue = 0.ToString();
        }

        
    }
}