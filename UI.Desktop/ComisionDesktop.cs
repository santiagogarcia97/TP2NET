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


namespace UI.Desktop {
    public partial class ComisionDesktop : ApplicationForm {

        private Comision _ComisionActual;
        public Comision ComisionActual { get => _ComisionActual; set => _ComisionActual = value; }

        public ComisionDesktop() {
            InitializeComponent();

            //Se genera el comobox de especialidades
            //getEspecialidades devuelve un DataTable con un columna de ID y otra de Descripcion
            //La de ID se usa como valor interno al seleccionar una opcion y la Desc es la que se muestra al usuario
            cbEsp.ValueMember = "id_esp";
            cbEsp.DisplayMember = "desc_esp";
            cbEsp.DataSource = GenerarComboBox.getEspecialidades();
        }

        public ComisionDesktop(ModoForm modo) : this() {
            Modo = modo;
        }

        public ComisionDesktop(int ID, ModoForm modo) : this() {
            Modo = modo;
            ComisionLogic auxComision = new ComisionLogic();
            ComisionActual = auxComision.GetOne(ID);

            PlanLogic pl = new PlanLogic();
            Plan plan = pl.GetOne(ComisionActual.IDPlan);

            GenerarPlanes(plan.IDEspecialidad);

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
            txtAnio.Text = ComisionActual.AnioEspecialidad.ToString();
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
                ComisionActual = new Comision();
                ComisionActual.Descripcion = txtDescripcion.Text;
                ComisionActual.AnioEspecialidad = Int32.Parse(txtAnio.Text);
                ComisionActual.IDPlan = (int)cbPlan.SelectedValue;

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
            lblRedDesc.Visible = (string.IsNullOrWhiteSpace(txtDescripcion.Text)) ? true : false;
            lblRedAnio.Visible = (string.IsNullOrWhiteSpace(txtAnio.Text)) ? true : false;
            lblRedPlan.Visible = (cbEsp.SelectedValue == null || cbPlan.SelectedValue == null) ? true : false;

            if (lblRedDesc.Visible == true ||
                lblRedAnio.Visible == true ||
                lblRedPlan.Visible == true) {
                return false;
            }
            else {
                return true;
            }
        }

        private void GenerarPlanes(int idEsp) {
            //Se genera el comobox de planes el funcionamiento es igual al de especialidades solo que se pasa
            //el id de la esp para filtrar los planes de dicha esp
            cbPlan.ValueMember = "id_plan";
            cbPlan.DisplayMember = "desc_plan";
            cbPlan.DataSource = GenerarComboBox.getPlanes(idEsp);
        }

        private void btnAceptar_Click(object sender, EventArgs e) {
            if (Validar()) {
                GuardarCambios();
                this.Close();
            }
            else {
                MessageBox.Show("Complete todos los campos.");
            }
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
                GenerarPlanes((int)cbEsp.SelectedValue);
            }
        }
    }
}
