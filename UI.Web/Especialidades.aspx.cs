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
    public partial class Especialidades : System.Web.UI.Page {

        public enum FormModes { Alta, Baja, Modificacion }

        public FormModes FormMode {
            get { return (FormModes)ViewState["FormMode"]; }
            set { ViewState["FormMode"] = value; }
        }

        private Especialidad Entity {
            get;
            set;
        }

        private int SelectedID {
            get {
                if(ViewState["SelectedID"] != null) return (int)ViewState["SelectedID"];
                else return 0;
            }
            set {
                ViewState["SelectedID"] = value;
            }
        }


        private bool IsEntitySelected {
            get { return (SelectedID != 0); }
        }

        private EspecialidadLogic _logic;
        private EspecialidadLogic Logic {
            get {
                if(_logic == null) _logic = new EspecialidadLogic();
                return _logic;
            }
        }

        private void LoadGrid() {

            gridView.DataSource = Logic.GetAll();
            gridView.DataBind();
        }


        protected void Page_Load(object sender,EventArgs e) {
            LoadGrid();

        }

        protected void gridView_SelectedIndexChanged(object sender,EventArgs e) {
            SelectedID = (int)gridView.SelectedValue;
        }

        private void LoadForm(int id) {
            Entity = Logic.GetOne(id);
            IDTextBox.Text = Entity.ID.ToString();
            descripcionTextBox.Text = Entity.Descripcion;
        }


        protected void editarLinkButton_Click(object sender,EventArgs e) {
            if(IsEntitySelected) {
                EnableForm(true);
                formPanel.Visible = true;
                FormMode = FormModes.Modificacion;
                LoadForm(SelectedID);
            }
        }
        private void LoadEntity(Especialidad especialidad) {
            especialidad.Descripcion = descripcionTextBox.Text;

        }

        private void SaveEntity(Especialidad especialidad) {
            Logic.Save(especialidad);
        }

        protected void aceptarLinkButton_Click(object sender,EventArgs e) {
            switch(FormMode) {
                case FormModes.Baja:
                    Entity.State = BusinessEntity.States.Deleted;
                    DeleteEntity(SelectedID);
                    LoadGrid();
                    break;
                case FormModes.Modificacion:
                    Entity = new Especialidad();
                    Entity.ID = SelectedID;
                    Entity.State = BusinessEntity.States.Modified;
                    LoadEntity(Entity);
                    SaveEntity(Entity);
                    LoadGrid();
                    break;
                case FormModes.Alta:
                    Entity = new Especialidad();
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

        private void EnableForm(bool enable) {
            IDTextBox.Enabled = false;
            descripcionTextBox.Enabled = enable;
        }

        protected void eliminarLinkButton_Click(object sender,EventArgs e) {
            if(this.IsEntitySelected) {
                formPanel.Visible = true;
                FormMode = FormModes.Baja;
                EnableForm(false);
                LoadForm(this.SelectedID);
            }
        }

        private void DeleteEntity(int id) {
            Logic.Delete(id);
        }

        protected void nuevoLinkButton_Click(object sender,EventArgs e) {
            formPanel.Visible = true;
            FormMode = FormModes.Alta;
            ClearForm();
            EnableForm(true);
        }

        private void ClearForm() {
            descripcionTextBox.Text = string.Empty;
        }
    }
}