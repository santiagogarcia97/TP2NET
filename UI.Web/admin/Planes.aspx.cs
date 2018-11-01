﻿using System;
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
using System.ComponentModel.DataAnnotations;


namespace UI.Web {
    public partial class Planes : System.Web.UI.Page {
        public enum FormModes { Alta, Baja, Modificacion }
        private Plan _PlanActual;
        private PlanLogic _PlanLogic;
        public FormModes FormMode {
            get { return (FormModes)ViewState["FormMode"]; }
            set { ViewState["FormMode"] = value; }
        }
        public Plan PlanActual { get => _PlanActual; set => _PlanActual = value; }
        private int SelectedID {
            get {
                if (ViewState["SelectedID"] != null) return (int)ViewState["SelectedID"];
                else return 0;
            }
            set {
                ViewState["SelectedID"] = value;
            }
        }
        public PlanLogic PlanLogic {
            get {
                if (_PlanLogic == null) { _PlanLogic = new PlanLogic(); }
                return _PlanLogic;
            }
        }

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                Listar();
                gvPlanes.HeaderRow.TableSection = TableRowSection.TableHeader;
                ddEsp.DataValueField = "id_esp";
                ddEsp.DataTextField = "desc_esp";
                ddEsp.DataSource = GenerarComboBox.getEspecialidades();
                ddEsp.DataBind();
            }
        }
        private void Listar() {
            PlanLogic el = new PlanLogic();
            gvPlanes.DataSource = el.GetListado();
            gvPlanes.DataBind();
            gvPlanes.SelectedIndex = -1;
            ButtonState();
        }
        private void ClearForm() {
            txtID.Text = "";
            txtDescripcion.Text = string.Empty;
            ddEsp.SelectedValue = 0.ToString();
            modalHeader.Text = "Nuevo Plan";
            btnAceptar.Text = "Crear";
            UpdatePanelModal.Update();
        }
        private void EnableForm(bool enable) {
            txtDescripcion.Enabled = enable;
            ddEsp.Enabled = enable;
        }
        private void LoadForm(int id) {
            PlanActual = PlanLogic.GetOne(id);
            txtID.Text = PlanActual.ID.ToString();
            txtDescripcion.Text = PlanActual.Descripcion;
            ddEsp.SelectedValue = PlanActual.IDEspecialidad.ToString();
            if (this.FormMode == FormModes.Baja) {
                modalHeader.Text = "Eliminar Plan";
                btnAceptar.Text = "Eliminar";
            }
            else if (this.FormMode == FormModes.Modificacion) {
                modalHeader.Text = "Editar Plan";
                btnAceptar.Text = "Guardar";
            }
            UpdatePanelModal.Update();
        }

        private void LoadEntity() {
            PlanActual.Descripcion = txtDescripcion.Text;
            PlanActual.IDEspecialidad = Int32.Parse(ddEsp.SelectedValue);
        }
        private void SaveEntity(Plan plan) {
            PlanLogic.Save(plan);
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
        private bool Validar() {
            lblRedDesc.Visible = (string.IsNullOrEmpty(txtDescripcion.Text) ||
                                    string.IsNullOrWhiteSpace(txtDescripcion.Text)) ? true : false;
            lblRedEsp.Visible = (ddEsp.SelectedValue == null) ? true : false;
            return !(lblRedDesc.Visible ||
                     lblRedEsp.Visible);
        }
        protected void gvPlanes_SelectedIndexChanged(object sender, EventArgs e) {
            SelectedID = (gvPlanes.SelectedValue != null) ? (int)gvPlanes.SelectedValue : 0;
            ButtonState();
        }

        protected void btnNuevo_Click(object sender, EventArgs e) {
            this.FormMode = FormModes.Alta;
            ClearForm();
            EnableForm(true);
            lblRedDesc.Visible = false;
            lblRedEsp.Visible = false;
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#ModalPlanes').modal('show');", true);
        }

        protected void btnEditar_Click(object sender, EventArgs e) {
            EnableForm(true);
            FormMode = FormModes.Modificacion;
            LoadForm(this.SelectedID);
            lblRedDesc.Visible = false;
            lblRedEsp.Visible = false;
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#ModalPlanes').modal('show');", true);
        }


        protected void btnEliminar_Click(object sender, EventArgs e) {
            FormMode = FormModes.Baja;
            EnableForm(false);
            LoadForm(this.SelectedID);
            lblRedDesc.Visible = false;
            lblRedEsp.Visible = false;
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#ModalPlanes').modal('show');", true);
        }

        protected void btnDeseleccionar_Click(object sender, EventArgs e) {
            gvPlanes.SelectedIndex = -1;
            gvPlanes_SelectedIndexChanged(sender, e);
            UpdatePanelGrid.Update();
        }

        protected void btnAceptar_Click(object sender, EventArgs e) {
            if (Validar() == true) {
                switch (FormMode) {
                    case FormModes.Baja:
                        PlanActual = new Plan();
                        PlanActual.ID = SelectedID;
                        PlanActual.State = BusinessEntity.States.Deleted;
                        break;
                    case FormModes.Modificacion:
                        PlanActual = new Plan {
                            ID = SelectedID,
                            Habilitado = true,
                            State = BusinessEntity.States.Modified
                        };
                        LoadEntity();
                        break;
                    case FormModes.Alta:
                        PlanActual = new Plan {
                            State = BusinessEntity.States.New,
                            Descripcion = txtDescripcion.Text,
                            IDEspecialidad = Int32.Parse(ddEsp.SelectedValue),
                            Habilitado = true
                        };
                        break;
                }
                SaveEntity(PlanActual);
                SelectedID = 0;
                Listar();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#ModalPlanes').modal('hide');", true);
            }
            {
                UpdatePanelGrid.Update();
                UpdatePanelModal.Update();
            }

        }

    }
}