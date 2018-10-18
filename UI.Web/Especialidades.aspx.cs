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

        private Especialidad EspecialidadActual;

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
            gridView.SelectedIndex = -1;
            List<Especialidad> lista = Logic.GetAll();
            gridView.DataSource = lista.Where(x => x.Habilitado == true);
            gridView.DataBind();
        }


        protected void Page_Load(object sender,EventArgs e) {
            LoadGrid();
            gridView.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected void gridView_SelectedIndexChanged(object sender,EventArgs e) {
            SelectedID = (int)gridView.SelectedValue;
        }

        private void LoadForm(int id) {
            EspecialidadActual = Logic.GetOne(id);
            inputID.Text = EspecialidadActual.ID.ToString();
            descripcionTextBox.Text = EspecialidadActual.Descripcion;
            if (this.FormMode == FormModes.Baja) {
                modalHeader.Text = "Eliminar Especialidad";
                aceptarButton.Text = "Eliminar";
            }
            else if(this.FormMode == FormModes.Modificacion) {
                modalHeader.Text = "Editar Especialidad";
                aceptarButton.Text = "Editar";
            }
            UpdatePanelModal.Update();
        }


        protected void editarButton_Click(object sender,EventArgs e) {
            if(IsEntitySelected) {
                EnableForm(true);
 //               formPanel.Visible = true;
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

        protected void aceptarButton_Click(object sender,EventArgs e) {
            switch(FormMode) {
                case FormModes.Baja:
                    EspecialidadActual = new Especialidad();
                    EspecialidadActual.ID = SelectedID;
                    EspecialidadActual.State = BusinessEntity.States.Deleted;
                    SaveEntity(EspecialidadActual);
                    LoadGrid();
                    break;
                case FormModes.Modificacion:
                    EspecialidadActual = new Especialidad {
                        ID = SelectedID,
                        Habilitado = true,
                        State = BusinessEntity.States.Modified
                    };
                    LoadEntity(EspecialidadActual);
                    SaveEntity(EspecialidadActual);
                    LoadGrid();
                    break;
                case FormModes.Alta:
                    EspecialidadActual = new Especialidad {
                        State = BusinessEntity.States.New,
                        Descripcion = descripcionTextBox.Text,
                        Habilitado = true
                    };
                    SaveEntity(EspecialidadActual);
                    LoadGrid();
                    break;
            }
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#nuevoModal').modal('hide');", true);
            //           formPanel.Visible = false;
        }

        private void EnableForm(bool enable) {
            //IDLabel.Enabled = false;
            descripcionTextBox.Enabled = enable;
        }

        protected void eliminarButton_Click(object sender,EventArgs e) {
            if(this.IsEntitySelected) {
   //             formPanel.Visible = true;
                FormMode = FormModes.Baja;
                EnableForm(false);
                LoadForm(this.SelectedID);
            }
        }

        protected void nuevoButton_Click(object sender,EventArgs e) {
 //           formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            ClearForm();
            EnableForm(true);
        }

        private void ClearForm() {
            inputID.Text = "";
            descripcionTextBox.Text = string.Empty;
            modalHeader.Text = "Nueva Especialidad";
            aceptarButton.Text = "Crear";
            UpdatePanelModal.Update();
        }
    }
}