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
    public partial class ABMComisionesDesktop : ApplicationForm {

        private Comision _ComisionActual;
        public Comision ComisionActual { get => _ComisionActual; set => _ComisionActual = value; }

        public ABMComisionesDesktop() {
            InitializeComponent();
        }

        public ABMComisionesDesktop(ModoForm modo) : this() {
            Modo = modo;
            GenerarEsp(0);
        }

        public ABMComisionesDesktop(int ID, ModoForm modo) : this() {
            Modo = modo;
            ComisionLogic auxComision = new ComisionLogic();
            ComisionActual = auxComision.GetOne(ID);

            PlanLogic pl = new PlanLogic();
            Plan plan = pl.GetOne(ComisionActual.IDPlan);

            GenerarEsp(plan.IDEspecialidad);
            GenerarPlanes(plan.IDEspecialidad, plan.ID);

            //El plan se pasa como argumento para tener el id de la especilidad y seleccionarlo en el combobox
            MapearDeDatos(plan);
        }

        private void ComisionDesktop_Load(object sender, EventArgs e) {
            lblRedAnio.Visible = false;
            lblRedDesc.Visible = false;
            lblRedPlan.Visible = false;
        }

        public void MapearDeDatos(Plan plan) {
            labelID.Text = ComisionActual.ID.ToString();
            txtDescripcion.Text = ComisionActual.Descripcion;
            nudAnio.Value = ComisionActual.AnioEspecialidad;
            cbEsp.SelectedValue = plan.IDEspecialidad;
            cbPlan.SelectedValue = ComisionActual.IDPlan;

            switch (Modo) {
                case ModoForm.Alta:
                case ModoForm.Modificacion:                     //Equivalente a if(Modo == ModoForm.Alta || Modo == Modoform.Modificacion){...}
                    btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    btnAceptar.Text = "Eliminar";
                    txtDescripcion.ReadOnly = true;
                    cbEsp.Enabled = false;
                    cbPlan.Enabled = false;
                    break;
            }
        }

        public override void MapearADatos() {
            if(Modo == ModoForm.Alta || Modo == ModoForm.Modificacion) {
                ComisionActual = new Comision {
                    Descripcion = txtDescripcion.Text,
                    AnioEspecialidad = (int)nudAnio.Value,
                    IDPlan = (int)cbPlan.SelectedValue,

                    Habilitado = true
                };

                if (Modo == ModoForm.Alta) {
                    ComisionActual.State = BusinessEntity.States.New;
                }
                else if (Modo == ModoForm.Modificacion) {
                    ComisionActual.State = BusinessEntity.States.Modified;
                    ComisionActual.ID = Int32.Parse(labelID.Text);
                }
            }
            else {
                ComisionActual.State = BusinessEntity.States.Deleted;
            }
        }

        public override void GuardarCambios() {
            MapearADatos();
            ComisionLogic auxComision = new ComisionLogic();
            auxComision.Save(ComisionActual);
        }

        public override bool Validar() {
            lblRedDesc.Visible = (Validaciones.ValTexto(txtDescripcion.Text)) ? false : true;
            lblRedAnio.Visible = Validaciones.ValAnio((int)nudAnio.Value) ? false : true;
            lblRedPlan.Visible = (cbEsp.SelectedValue == null || cbPlan.SelectedValue == null ||
                                    (int)cbEsp.SelectedValue == 0 || (int)cbPlan.SelectedValue == 0) ? true : false;

            return !(lblRedDesc.Visible ||
                lblRedAnio.Visible ||
                lblRedPlan.Visible); 
        }

        private void GenerarPlanes(int idEsp, int idPlanActual) {
            //Se genera el comobox de planes el funcionamiento es igual al de especialidades solo que se pasa
            //el id de la esp para filtrar los planes de dicha esp
            cbPlan.ValueMember = "id_plan";
            cbPlan.DisplayMember = "desc_plan";
            cbPlan.DataSource = GenerarComboBox.getPlanes(idEsp, idPlanActual);
            cbPlan.SelectedValue = 0;
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
        private void GenerarEsp(int idEspActual)
        {
            cbEsp.ValueMember = "id_esp";
            cbEsp.DisplayMember = "desc_esp";
            cbEsp.DataSource = GenerarComboBox.getEspecialidades(idEspActual);
            cbEsp.SelectedValue = 0;
        }

        private void btnCancelar_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void cbEsp_SelectedValueChanged(object sender, EventArgs e) {
            if (cbEsp.SelectedValue != null) {
                //Si el valor del combobox de especialidades cambia, se vuelven a generar los planes
                //pasando como argumento el id de la especialidad para mostrar solo los planes que
                //corresponden a dicha especialidad
                cbPlan.Text = "";
                GenerarPlanes((int)cbEsp.SelectedValue, Modo == ModoForm.Alta ? 0 : ComisionActual.IDPlan);
            }
        }
    }
}
