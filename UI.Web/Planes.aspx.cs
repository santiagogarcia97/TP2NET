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

        private Plan PlanActual { get; set; }

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
            gridView.SelectedIndex = -1;
            List<Plan> lista = Logic.GetAll();
            gridView.DataSource = lista.Where(x => x.Habilitado == true);
            gridView.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e) {
            LoadGrid();
            gridView.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e) {
            SelectedID = (int)gridView.SelectedValue;
        }

        private void LoadForm(int id) {
            PlanActual = Logic.GetOne(id);
            inputID.Text = PlanActual.ID.ToString();
            descripcionTextBox.Text = PlanActual.Descripcion;
            if (this.FormMode == FormModes.Baja) {
                modalHeader.Text = "Eliminar Plan";
                aceptarButton.Text = "Eliminar";
            }
            else if (this.FormMode == FormModes.Modificacion) {
                modalHeader.Text = "Editar Plan";
                aceptarButton.Text = "Editar";
            }
            this.GenerarEsp();
            UpdatePanelModal.Update();
        }

        private void GenerarEsp() {
            DataTable dtEspecialidades = GenerarComboBox.getEspecialidades();
            especialidadDropDown.DataValueField = "id_esp";
            especialidadDropDown.DataTextField = "desc_esp";
            especialidadDropDown.DataSource = dtEspecialidades;
            especialidadDropDown.DataBind();
        }


        protected void editarButton_Click(object sender, EventArgs e) {
            if (IsEntitySelected) {
                EnableForm(true);
                FormMode = FormModes.Modificacion;
                descRed.Visible = false;
                espRed.Visible = false;
                LoadForm(SelectedID);
                this.GenerarEsp();
            }
        }
        private void LoadEntity() {
            PlanActual.Descripcion = descripcionTextBox.Text;
            PlanActual.IDEspecialidad = int.Parse(especialidadDropDown.SelectedValue);
        }

        private void SaveEntity(Plan plan) {
            Logic.Save(plan);
        }

        protected void aceptarButton_Click(object sender, EventArgs e) {
            if (Validar()) {
                switch (FormMode) {
                    case FormModes.Baja:
                        PlanActual = new Plan();
                        PlanActual.ID = SelectedID;
                        PlanActual.State = BusinessEntity.States.Deleted;
                        SaveEntity(PlanActual);
                        break;
                    case FormModes.Modificacion:
                        PlanActual = new Plan {
                            ID = SelectedID,
                            Habilitado = true,
                            State = BusinessEntity.States.Modified
                        };
                        LoadEntity();
                        SaveEntity(PlanActual);
                        break;
                    case FormModes.Alta:
                        PlanActual = new Plan {
                            State = BusinessEntity.States.New,
                            Habilitado = true
                        };
                        LoadEntity();
                        SaveEntity(PlanActual);
                        break;
                }
                LoadGrid();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#nuevoModal').modal('hide');", true);
            }
        }

        protected bool Validar() {
            descRed.Visible = (string.IsNullOrWhiteSpace(descripcionTextBox.Text)) ? true : false;
            espRed.Visible = (especialidadDropDown.SelectedValue == null) ? true : false;
            UpdatePanelModal.Update();

            return !(descRed.Visible ||
                        espRed.Visible);
        }
        private void EnableForm(bool enable) {
            descripcionTextBox.Enabled = enable;
            especialidadDropDown.Enabled = enable;
        }

        protected void eliminarButton_Click(object sender, EventArgs e) {
            if (this.IsEntitySelected) {
                FormMode = FormModes.Baja;
                EnableForm(false);
                LoadForm(this.SelectedID);
            }
        }


        protected void nuevoButton_Click(object sender, EventArgs e) {
            FormMode = FormModes.Alta;
            ClearForm();
            EnableForm(true);
        }
        protected void cerrarModal_Click(object sender, EventArgs e) {
            descRed.Visible = false;
            espRed.Visible = false;
            UpdatePanelModal.Update();
        }

        private void ClearForm() {
            inputID.Text = "";
            descripcionTextBox.Text = string.Empty;
            modalHeader.Text = "Nueva Especialidad";
            aceptarButton.Text = "Crear";
            descRed.Visible = false;
            espRed.Visible = false;
            GenerarEsp();
            UpdatePanelModal.Update();
        }
    }
}