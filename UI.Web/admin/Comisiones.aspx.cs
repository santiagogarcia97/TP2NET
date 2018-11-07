﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using Util;

namespace UI.Web.admin {
    public partial class Comisiones : System.Web.UI.Page {
        public enum FormModes { Alta, Baja, Modificacion }
        private Comision _ComisionActual;
        private ComisionLogic _ComisionLogic;
        public FormModes FormMode {
            get { return (FormModes)ViewState["FormMode"]; }
            set { ViewState["FormMode"] = value; }
        }
        public Comision ComisionActual { get => _ComisionActual; set => _ComisionActual = value; }
        private int SelectedID {
            get {
                if (ViewState["SelectedID"] != null) return (int)ViewState["SelectedID"];
                else return 0;
            }
            set {
                ViewState["SelectedID"] = value;
            }
        }
        public ComisionLogic ComisionLogic {
            get {
                if (_ComisionLogic == null) { _ComisionLogic = new ComisionLogic(); }
                return _ComisionLogic;
            }
        }

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                Listar();
                gvCom.HeaderRow.TableSection = TableRowSection.TableHeader;
                ddEsp.DataValueField = "id_esp";
                ddEsp.DataTextField = "desc_esp";
                ddEsp.DataSource = GenerarComboBox.getEspecialidades();
                ddEsp.DataBind();
            }
        }
        private void Listar() {
            gvCom.DataSource = ComisionLogic.GetListado();
            gvCom.DataBind();
            gvCom.SelectedIndex = -1;
            ButtonState();
        }
        private void ClearForm() {
            txtID.Text = "";
            txtDescripcion.Text = string.Empty;
            txtAnio.Text = DateTime.Today.Year.ToString();
            ddPlan.SelectedValue = 0.ToString();
            ddEsp.SelectedValue = 0.ToString();
            modalHeader.Text = "Nueva Comision";
            btnAceptar.Text = "Crear";
            UpdatePanelModal.Update();
        }
        private void EnableForm(bool enable) {
            txtDescripcion.Enabled = enable;
            txtAnio.Enabled = enable;
            ddPlan.Enabled = enable;
            ddEsp.Enabled = enable;
        }
        private void LoadForm(int id) {
            ComisionActual = ComisionLogic.GetOne(id);
            PlanLogic pl = new PlanLogic();
            Plan plan = pl.GetOne(ComisionActual.IDPlan);

            txtID.Text = ComisionActual.ID.ToString();
            txtDescripcion.Text = ComisionActual.Descripcion;
            txtAnio.Text = ComisionActual.AnioEspecialidad.ToString();
            ddEsp.SelectedValue = plan.IDEspecialidad.ToString();
            GenerarPlanes(plan.IDEspecialidad);
            ddPlan.SelectedValue = ComisionActual.IDPlan.ToString();

            if (this.FormMode == FormModes.Baja) {
                modalHeader.Text = "Eliminar Comision";
                btnAceptar.Text = "Eliminar";
            }
            else if (this.FormMode == FormModes.Modificacion) {
                modalHeader.Text = "Editar Comision";
                btnAceptar.Text = "Guardar";
            }
            UpdatePanelModal.Update();
        }

        private void LoadEntity() {
            ComisionActual.Descripcion = txtDescripcion.Text;
            ComisionActual.AnioEspecialidad = int.Parse(txtAnio.Text);
            ComisionActual.IDPlan = Int32.Parse(ddPlan.SelectedValue);
        }
        private void SaveEntity() {
            ComisionLogic.Save(ComisionActual);
        }
        private void ButtonState() {

            if (SelectedID == 0) {
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
            }
            UpdatePanelButtons.Update();
        }
        protected void gvCom_SelectedIndexChanged(object sender, EventArgs e) {
            SelectedID = (gvCom.SelectedValue != null) ? (int)gvCom.SelectedValue : 0;
            ButtonState();
        }

        protected void btnNuevo_Click(object sender, EventArgs e) {
            this.FormMode = FormModes.Alta;
            SetFormControlCSS();
            ClearForm();
            EnableForm(true);
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#ModalComisiones').modal('show');", true);
        }

        protected void btnEditar_Click(object sender, EventArgs e) {
            SetFormControlCSS();
            EnableForm(true);
            FormMode = FormModes.Modificacion;
            LoadForm(this.SelectedID);
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#ModalComisiones').modal('show');", true);
        }


        protected void btnEliminar_Click(object sender, EventArgs e) {
            FormMode = FormModes.Baja;
            SetFormControlCSS();
            EnableForm(false);
            LoadForm(this.SelectedID);
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#ModalComisiones').modal('show');", true);
        }

        protected void btnDeseleccionar_Click(object sender, EventArgs e) {
            gvCom.SelectedIndex = -1;
            gvCom_SelectedIndexChanged(sender, e);
            UpdatePanelGrid.Update();
        }

        protected void btnAceptar_Click(object sender, EventArgs e) {
            if (Validar() == true) {
                switch (FormMode) {
                    case FormModes.Baja:
                        ComisionActual = new Comision {
                            ID = SelectedID,
                            State = BusinessEntity.States.Deleted
                        };
                        break;
                    case FormModes.Modificacion:
                        ComisionActual = new Comision {
                            ID = SelectedID,
                            Habilitado = true,
                            State = BusinessEntity.States.Modified
                        };
                        LoadEntity();
                        break;
                    case FormModes.Alta:
                        ComisionActual = new Comision {
                            Habilitado = true,
                            State = BusinessEntity.States.New
                        };
                        LoadEntity();
                        break;
                }
                SaveEntity();
                SelectedID = 0;
                Listar();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#ModalComisiones').modal('hide');", true);
                UpdatePanelGrid.Update();
            }
            UpdatePanelModal.Update();
        }
        private bool Validar() {
            bool isvalid = true;

            if (string.IsNullOrEmpty(txtDescripcion.Text) ||
                 string.IsNullOrWhiteSpace(txtDescripcion.Text)) {
                txtDescripcion.CssClass = "form-control is-invalid";
                isvalid = false;
            }
            else {
                txtDescripcion.CssClass = "form-control";
            }
            if (string.IsNullOrEmpty(txtAnio.Text) ||
                string.IsNullOrWhiteSpace(txtAnio.Text)) {
                txtAnio.CssClass = "form-control is-invalid";
                isvalid = false;
            }
            else {
                txtAnio.CssClass = "form-control";
            }
            if (ddEsp.SelectedValue == null || int.Parse(ddEsp.SelectedValue) == 0) {
                ddEsp.CssClass = "form-control is-invalid";
                ddPlan.CssClass = "form-control is-invalid";
                isvalid = false;
            }
            else {
                ddEsp.CssClass = "form-control";
                if (ddPlan.SelectedValue == null || int.Parse(ddPlan.SelectedValue) == 0) {
                    ddPlan.CssClass = "form-control is-invalid";
                    isvalid = false;
                }
                else {
                    ddPlan.CssClass = "form-control";
                }
            }

            return isvalid;
        }

        private void SetFormControlCSS() {
            txtDescripcion.CssClass = "form-control";
            txtAnio.CssClass = "form-control";
            ddEsp.CssClass = "form-control";
            ddPlan.CssClass = "form-control";
        }

        protected void ddEsp_SelectedIndexChanged(object sender, EventArgs e) {
            GenerarPlanes(int.Parse(ddEsp.SelectedValue));
        }
        protected void GenerarPlanes(int idEsp) {
            ddPlan.DataValueField = "id_plan";
            ddPlan.DataTextField = "desc_plan";
            ddPlan.DataSource = GenerarComboBox.getPlanes(idEsp);
            ddPlan.DataBind();
            ddPlan.SelectedValue = 0.ToString();
            UpdatePanelModal.Update();
        }
    }
}