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
                UsuarioLogic ul = new UsuarioLogic();
                Usuario user = ul.GetOne(Session["username"].ToString());
                DocenteCursoLogic dcl = new DocenteCursoLogic();
                DocenteCurso dc = dcl.GetOne(user.ID, int.Parse(Request.QueryString["curso"]));

                if (dc.ID != 0) {
                    if (!IsPostBack) {
                        Listar();
                        gvIns.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                }
                else {
                    Response.Redirect("/login.aspx");
                }
            }
        }
        private void Listar() {
            gvIns.DataSource = AlumnoInscripcionLogic.GetListado();
            gvIns.DataBind();
            gvIns.SelectedIndex = -1;
            ButtonState();
        }

        private void LoadForm(int id) {
            AlumnoInscripcionActual = AlumnoInscripcionLogic.GetOne(id);

            txtID.Text = AlumnoInscripcionActual.ID.ToString();
            txtNota.Text = AlumnoInscripcionActual.Nota.ToString();
            ddAlumno.SelectedValue = AlumnoInscripcionActual.IDAlumno.ToString();
            ddCurso.SelectedValue = AlumnoInscripcionActual.IDCurso.ToString();
            ddCondicion.SelectedValue = ((int)AlumnoInscripcionActual.Condicion).ToString();

            UpdatePanelModal.Update();
        }

        private void LoadEntity() {
            AlumnoInscripcionActual.IDAlumno = int.Parse(ddAlumno.SelectedValue);
            AlumnoInscripcionActual.IDCurso = int.Parse(ddCurso.SelectedValue);
            AlumnoInscripcionActual.Condicion = (AlumnoInscripcion.Condiciones)int.Parse(ddCondicion.SelectedValue);
            AlumnoInscripcionActual.Nota = int.Parse(txtNota.Text);
        }
        private void SaveEntity() {
            AlumnoInscripcionLogic.Save(AlumnoInscripcionActual);
        }
        private void ButtonState() {

 /*           if (SelectedID == 0) {
                btnEditar.CssClass = "btn btn-outline-secondary btn-sm";
                btnEditar.Enabled = false;
                btnEliminar.CssClass = "btn btn-outline-secondary btn-sm";
                btnEliminar.Enabled = false;
                btnDeseleccionar.Visible = false;
            }
            else {
                btnEditar.CssClass = "btn btn-outline-success btn-sm";
                btnEditar.Enabled = true;
                btnEliminar.CssClass = "btn btn-outline-success btn-sm";
                btnEliminar.Enabled = true;
                btnDeseleccionar.Visible = true;
            }*/
            UpdatePanelButtons.Update();
        }
        protected void gvIns_SelectedIndexChanged(object sender, EventArgs e) {
            SelectedID = (gvIns.SelectedValue != null) ? (int)gvIns.SelectedValue : 0;
            ButtonState();
        }

        protected void btnEditar_Click(object sender, EventArgs e) {
            SetFormControlCSS();
     //       EnableForm(true);
        
            LoadForm(this.SelectedID);
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#ModalInscripciones').modal('show');", true);
        }


        protected void btnEliminar_Click(object sender, EventArgs e) {
          
            SetFormControlCSS();
   //         EnableForm(false);
            LoadForm(this.SelectedID);
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#ModalInscripciones').modal('show');", true);
        }

        protected void btnDeseleccionar_Click(object sender, EventArgs e) {
            gvIns.SelectedIndex = -1;
            gvIns_SelectedIndexChanged(sender, e);
            UpdatePanelGrid.Update();
        }

        protected void btnAceptar_Click(object sender, EventArgs e) {
    /*        if (Validar() == true) {
              switch (FormMode) {
                   case FormModes.Baja:
                        AlumnoInscripcionActual = new AlumnoInscripcion {
                            ID = SelectedID,
                            State = BusinessEntity.States.Deleted
                        };
                        break;
                    case FormModes.Modificacion:
                        AlumnoInscripcionActual = new AlumnoInscripcion {
                            ID = SelectedID,
                            Habilitado = true,
                            State = BusinessEntity.States.Modified
                        };
                        LoadEntity();
                        break;
                    case FormModes.Alta:
                        AlumnoInscripcionActual = new AlumnoInscripcion {
                            Habilitado = true,
                            State = BusinessEntity.States.New
                        };
                        LoadEntity();
                        break;
                }
                SaveEntity();
                SelectedID = 0;
                Listar();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#ModalInscripciones').modal('hide');", true);
                UpdatePanelGrid.Update();
            }
            UpdatePanelModal.Update();*/
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
            if (ddAlumno.SelectedValue == string.Empty || int.Parse(ddAlumno.SelectedValue) == 0) {
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

            return isvalid;
        }

        private void SetFormControlCSS() {
            txtNota.CssClass = "form-control";
            ddCurso.CssClass = "form-control";
            ddCondicion.CssClass = "form-control";
            ddAlumno.CssClass = "form-control";
        }
        protected void GenerarCondiciones() {
            ddCondicion.DataValueField = "id_cond";
            ddCondicion.DataTextField = "desc_cond";
            ddCondicion.DataSource = GenerarComboBox.getCondiciones();
            ddCondicion.DataBind();
            ddCondicion.SelectedValue = 0.ToString();
            UpdatePanelModal.Update();
        }

        
    }
}