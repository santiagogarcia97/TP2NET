using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;
using Util;

namespace UI.Desktop.admin
{
    public partial class ABMPlanesDesktop : ApplicationForm {

        private Plan _planActual;
        public Plan PlanActual {get { return _planActual; }set { _planActual = value; }}

        public ABMPlanesDesktop() {
            InitializeComponent();
        }

        public ABMPlanesDesktop(ModoForm modo) : this() {
            Modo = modo;
            GenerarEsp(0);
            lblID.Text = "-";
        }

        public ABMPlanesDesktop(int ID, ModoForm modo) : this() {
            Modo = modo;
            PlanLogic auxPlan = new PlanLogic();
            PlanActual = auxPlan.GetOne(ID);
            GenerarEsp(PlanActual.IDEspecialidad);
            MapearDeDatos();
        }

        public override void MapearDeDatos() {
            lblID.Text = PlanActual.ID.ToString();
            txtDescripcion.Text = PlanActual.Descripcion;
            EspecialidadLogic el = new EspecialidadLogic();
            Especialidad esp = el.GetOne(PlanActual.IDEspecialidad);
            cbEsp.SelectedValue = PlanActual.IDEspecialidad;

            switch (Modo) {
                case ModoForm.Alta:
                    btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Modificacion:           
                    btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    btnAceptar.Text = "Eliminar";
                    txtDescripcion.ReadOnly = true;
                    cbEsp.Enabled = false;

                    break;
            }
        }

        public override void MapearADatos() {
            switch (Modo) {                                    
                case ModoForm.Alta:
                    PlanActual = new Plan {
                        Descripcion = txtDescripcion.Text,
                        IDEspecialidad = (int)cbEsp.SelectedValue,
                        Habilitado = true,
                        State = BusinessEntity.States.New
                    };
                    break;
                case ModoForm.Modificacion:
                    PlanActual.Descripcion = txtDescripcion.Text;
                    PlanActual.State = BusinessEntity.States.Modified;
                    PlanActual.IDEspecialidad = (int)cbEsp.SelectedValue;
                    break;
                case ModoForm.Baja:
                    PlanActual.State = BusinessEntity.States.Deleted;
                    break;
            }
        }

        public override void GuardarCambios() {
            MapearADatos();
            PlanLogic auxPlan = new PlanLogic();
            auxPlan.Save(PlanActual);
        }

        public override bool Validar() {

            lblDescRed.Visible = Validaciones.ValTexto(txtDescripcion.Text) ? false : true;
            lblEspRed.Visible = (cbEsp.SelectedValue == null || (int)cbEsp.SelectedValue == 0) ? true : false;

            return !(lblEspRed.Visible || lblDescRed.Visible);
        }

        private void btnAceptar_Click(object sender, EventArgs e) {
            if (Validar()) {
                GuardarCambios();
                this.Close();
            }
            else {
                MessageBox.Show("Compruebe los datos ingresados.");
            }
        }
        private void GenerarEsp(int idEspActual){
            cbEsp.ValueMember = "id_esp";
            cbEsp.DisplayMember = "desc_esp";
            cbEsp.DataSource = GenerarComboBox.getEspecialidades(idEspActual);
            cbEsp.SelectedValue = 0;
        }

    }
}
