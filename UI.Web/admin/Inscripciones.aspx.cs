using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using Util;

namespace UI.Web.admin
{
    public partial class Inscripciones : System.Web.UI.Page
    {
        public enum FormModes { Alta, Baja, Modificacion }
        private AlumnoInscripcion _AlumnoInscripcionActual;
        private AlumnoInscripcionLogic _AlumnoInscripcionLogic;
        public FormModes FormMode {
            get { return (FormModes)ViewState["FormMode"]; }
            set { ViewState["FormMode"] = value; }
        }
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["tipo"] == null || (int)Session["tipo"] != 3) {
                Response.Clear();
                Response.StatusCode = 404;
                Response.End();
            }
            else {
                if (!IsPostBack) {
                    Listar();
                    gvIns.HeaderRow.TableSection = TableRowSection.TableHeader;
                    GenerarCondiciones();
                }
            }
        }
        private void Listar()
        {
            List<AlumnoInscripcion> ais = AlumnoInscripcionLogic.GetAll().Where(x => x.Habilitado == true).ToList();

            if (ais.Count == 0) {
                divSinIns.Visible = true;
            }
            else {
                gvIns.DataSource = Listado.Generar(ais);
                gvIns.DataBind();
                gvIns.SelectedIndex = -1;
                ButtonState();
            }
        }

        private void EnableForm(bool enable)
        {
            txtNota.Enabled = enable;        
            ddCondicion.Enabled = enable;
            txtAlumno.Enabled = false;
            txtCurso.Enabled = false;
        }
        private void LoadForm()
        {
            AlumnoInscripcionActual = AlumnoInscripcionLogic.GetOne(SelectedID);
            UsuarioLogic ul = new UsuarioLogic();
            Usuario user = ul.GetOne(AlumnoInscripcionActual.IDAlumno);
            CursoLogic cl = new CursoLogic();
            Curso cur = cl.GetOne(AlumnoInscripcionActual.IDCurso);
            MateriaLogic matl = new MateriaLogic();
            Materia mat = matl.GetOne(cur.IDMateria);
            ComisionLogic coml = new ComisionLogic();
            Comision com = coml.GetOne(cur.IDComision);


            txtID.Text = AlumnoInscripcionActual.ID.ToString();
            txtNota.Text = AlumnoInscripcionActual.Nota.ToString();
            txtAlumno.Text = user.Legajo + " - " + user.Apellido + ", " + user.Nombre;
            txtCurso.Text = com.Descripcion + " - " + mat.Descripcion;
            ddCondicion.SelectedValue = ((int)AlumnoInscripcionActual.Condicion).ToString();

            if (this.FormMode == FormModes.Baja)
            {
                modalHeader.Text = "Eliminar Inscripcion";
                btnAceptar.Text = "Eliminar";
            }
            else if (this.FormMode == FormModes.Modificacion)
            {
                modalHeader.Text = "Editar Inscripcion";
                btnAceptar.Text = "Guardar";
            }
            UpdatePanelModal.Update();
        }

        private void LoadEntity()
        {
            AlumnoInscripcion aux = AlumnoInscripcionLogic.GetOne(SelectedID);
            AlumnoInscripcionActual.IDAlumno = aux.IDAlumno;
            AlumnoInscripcionActual.IDCurso = aux.IDCurso;
            AlumnoInscripcionActual.Condicion = (AlumnoInscripcion.Condiciones)int.Parse(ddCondicion.SelectedValue);
            AlumnoInscripcionActual.Nota = int.Parse(txtNota.Text);
        }
        private void SaveEntity()
        {
            AlumnoInscripcionLogic.Save(AlumnoInscripcionActual);
        }
        private void ButtonState()
        {

            if (SelectedID == 0)
            {
                btnEditar.CssClass = "btn btn-outline-secondary btn-sm";
                btnEditar.Enabled = false;
                btnEliminar.CssClass = "btn btn-outline-secondary btn-sm";
                btnEliminar.Enabled = false;
                btnDeseleccionar.Visible = false;
            }
            else
            {
                btnEditar.CssClass = "btn btn-outline-success btn-sm";
                btnEditar.Enabled = true;
                btnEliminar.CssClass = "btn btn-outline-success btn-sm";
                btnEliminar.Enabled = true;
                btnDeseleccionar.Visible = true;
            }
            UpdatePanelButtons.Update();
        }
        protected void gvIns_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedID = (gvIns.SelectedValue != null) ? (int)gvIns.SelectedValue : 0;
            ButtonState();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            SetFormControlCSS();
            EnableForm(true);
            FormMode = FormModes.Modificacion;
            LoadForm();
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#ModalInscripciones').modal('show');", true);
        }


        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            FormMode = FormModes.Baja;
            SetFormControlCSS();
            EnableForm(false);
            LoadForm();
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#ModalInscripciones').modal('show');", true);
        }

        protected void btnDeseleccionar_Click(object sender, EventArgs e)
        {
            gvIns.SelectedIndex = -1;
            gvIns_SelectedIndexChanged(sender, e);
            UpdatePanelGrid.Update();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar() == true)
            {
                switch (FormMode)
                {
                    case FormModes.Baja:
                        AlumnoInscripcionActual = new AlumnoInscripcion
                        {
                            ID = SelectedID,
                            State = BusinessEntity.States.Deleted
                        };
                        break;
                    case FormModes.Modificacion:
                        AlumnoInscripcionActual = new AlumnoInscripcion
                        {
                            ID = SelectedID,
                            Habilitado = true,
                            State = BusinessEntity.States.Modified
                        };
                        break;
                    case FormModes.Alta:
                        AlumnoInscripcionActual = new AlumnoInscripcion
                        {
                            Habilitado = true,
                            State = BusinessEntity.States.New
                        };
                        LoadEntity();
                        break;
                }
                LoadEntity();
                SaveEntity();
                SelectedID = 0;
                Listar();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#ModalInscripciones').modal('hide');", true);
                UpdatePanelGrid.Update();
            }
            UpdatePanelModal.Update();
        }
        private bool Validar()
        {
            bool isvalid = true;

            if (Validaciones.ValTexto(txtNota.Text) && int.Parse(txtNota.Text) != 0) txtNota.CssClass = "form-control";
                else{
                    txtNota.CssClass = "form-control is-invalid";
                    isvalid = false;
                }

            if (ddCondicion.SelectedValue == string.Empty || int.Parse(ddCondicion.SelectedValue) == 0)
            {
                ddCondicion.CssClass = "form-control is-invalid";
                isvalid = false;
            }
            else
            {
                ddCondicion.CssClass = "form-control";
            }

            return isvalid;
        }

        private void SetFormControlCSS()
        {
            txtNota.CssClass = "form-control";
            ddCondicion.CssClass = "form-control";
        }
        protected void GenerarCondiciones()
        {
            ddCondicion.DataValueField = "id_cond";
            ddCondicion.DataTextField = "desc_cond";
            ddCondicion.DataSource = GenerarComboBox.getCondiciones();
            ddCondicion.DataBind();
            ddCondicion.SelectedValue = 0.ToString();
            UpdatePanelModal.Update();
        }
    }
}