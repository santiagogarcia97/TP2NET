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
using System.ComponentModel.DataAnnotations;


namespace UI.Web {
    public partial class Planes : System.Web.UI.Page {

        public enum FormModes { Alta, Baja, Modificacion }

        public FormModes FormMode {
            get { return (FormModes)ViewState["FormMode"]; }
            set { ViewState["FormMode"] = value; }
        }

        private Plan Entity {
            get;
            set;
        }

        private int SelectedID {
            get {
                if (ViewState["SelectedID"] != null) return (int)ViewState["SelectedID"];
                else return 0;
            }
            set {
                ViewState["SelectedID"] = value;
            }
        }


        private bool IsEntitySelected {
            get { return (SelectedID != 0); }
        }

        private PlanLogic _logic;
        private PlanLogic Logic {
            get {
                if (_logic == null) _logic = new PlanLogic();
                return _logic;
            }
        }

        private void LoadGrid() {

            PlanGridView.DataSource = Logic.GetAll();
            PlanGridView.DataBind();
        }


        protected void Page_Load(object sender, EventArgs e) {
            LoadGrid();

        }

        protected void PlanGridView_SelectedIndexChanged(object sender, EventArgs e) {
            SelectedID = (int)PlanGridView.SelectedValue;
        }

        private void LoadForm(int id) {
            Entity = Logic.GetOne(id);
            IDLabel.Text = "ID: " + id.ToString();
            descTextBox.Text = Entity.Descripcion;
            this.GenerarEsp();
        }

        private void GenerarEsp() {
            DataTable dtEspecialidades = GenerarComboBox.getEspecialidades();
            especialidadDDL.DataValueField = "id_esp";
            especialidadDDL.DataTextField = "desc_esp";
            especialidadDDL.DataSource = dtEspecialidades;
            especialidadDDL.DataBind();
        }


        protected void editarLinkButton_Click(object sender, EventArgs e) {
            if (IsEntitySelected) {
                EnableForm(true);
                formPanel.Visible = true;
                FormMode = FormModes.Modificacion;
                LoadForm(SelectedID);
                GenerarEsp();
            }
        }
        private void LoadEntity(Plan plan) {
            plan.Descripcion = descTextBox.Text;
            plan.IDEspecialidad = int.Parse(especialidadDDL.SelectedValue);
        }

        private void SaveEntity(Plan plan) {
            Logic.Save(plan);
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e) {
            if (Validar()) {
                switch (FormMode) {
                    case FormModes.Baja:
                        Entity.State = BusinessEntity.States.Deleted;
                        SaveEntity(Entity);
                        LoadGrid();
                        break;
                    case FormModes.Modificacion:
                        Entity = new Plan();
                        Entity.ID = SelectedID;
                        Entity.State = BusinessEntity.States.Modified;
                        LoadEntity(Entity);
                        SaveEntity(Entity);
                        LoadGrid();
                        break;
                    case FormModes.Alta:
                        Entity = new Plan();
                        Entity.State = BusinessEntity.States.New;
                        LoadEntity(Entity);
                        SaveEntity(Entity);
                        LoadGrid();
                        break;
                    default:
                        break;
                }
                formPanel.Visible = false;
            }
        }

        protected bool Validar() {
            lblRedDesc.Visible = (string.IsNullOrWhiteSpace(descTextBox.Text)) ? true : false;
            lblRedEsp.Visible = (especialidadDDL.SelectedValue == null) ? true : false;

            return !(lblRedDesc.Visible ||
                     lblRedEsp.Visible);
        }
        private void EnableForm(bool enable) {
            descTextBox.Enabled = enable;
            especialidadDDL.Enabled = enable;
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e) {
            if (this.IsEntitySelected) {
                formPanel.Visible = true;
                FormMode = FormModes.Baja;
                EnableForm(false);
                LoadForm(this.SelectedID);
            }
        }


        protected void nuevoLinkButton_Click(object sender, EventArgs e) {
            formPanel.Visible = true;
            FormMode = FormModes.Alta;
            ClearForm();
            EnableForm(true);
        }

        private void ClearForm() {
            IDLabel.Text = "ID: -";
            descTextBox.Text = string.Empty;
            GenerarEsp();
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e) {
            formPanel.Visible = false;
        }

        protected void especialidadDDL_SelectedIndexChanged(object sender, EventArgs e) {

        }
    }
}