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
    public partial class ABMMateriasDesktop : ApplicationForm {

        private Materia _MateriaActual;
        public Materia MateriaActual {get { return _MateriaActual; }set { _MateriaActual = value; }}

        public ABMMateriasDesktop() {
            InitializeComponent();
        }
        public ABMMateriasDesktop(ModoForm modo) : this() {
            Modo = modo;
            GenerarEsp(0);
        }

        public ABMMateriasDesktop(int ID, ModoForm modo) : this() {
            Modo = modo;
            MateriaLogic auxMateria = new MateriaLogic();
            MateriaActual = auxMateria.GetOne(ID);

            PlanLogic pl = new PlanLogic();
            Plan plan = pl.GetOne(MateriaActual.IDPlan);

            GenerarEsp(MateriaActual.IDPlan);
            GenerarPlanes(plan.IDEspecialidad, MateriaActual.IDPlan);

            MapearDeDatos(plan);
            //El plan se pasa como argumento para tener el id de la especilidad y seleccionarlo en el combobox
        }
        private void MateriaDesktop_Load(object sender, EventArgs e) {
            lblRedDesc.Visible = false;
            lblRedHSS.Visible = false;
            lblRedHST.Visible = false;
            lblRedPlan.Visible = false;
        }

        public void MapearDeDatos(Plan pln) {
            labelID.Text = MateriaActual.ID.ToString();
            txtDescripcion.Text = MateriaActual.Descripcion;
            nudHSSem.Value = MateriaActual.HSSemanales;
            nudHSTot.Value = MateriaActual.HSTotales;
            cbEsp.SelectedValue = pln.IDEspecialidad;
            cbPlan.SelectedValue = MateriaActual.IDPlan;

            switch (Modo) {
                case ModoForm.Alta:
                case ModoForm.Modificacion:             //Equivalente a if(Modo == ModoForm.Alta || Modo == Modoform.Modificacion){...}        
                    btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    btnAceptar.Text = "Eliminar";
                    nudHSSem.ReadOnly = true;
                    nudHSTot.ReadOnly = true;
                    txtDescripcion.ReadOnly = true;
                    cbEsp.Enabled = false;
                    cbPlan.Enabled = false;
                    break;
            }
        }

        public override void MapearADatos() {
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion) {
                MateriaActual = new Materia {
                    Descripcion = txtDescripcion.Text,
                    HSSemanales = (int)nudHSSem.Value,
                    HSTotales = (int)nudHSTot.Value,
                    IDPlan = (int)cbPlan.SelectedValue,

                    Habilitado = true
                };

                if (Modo == ModoForm.Alta) {
                    MateriaActual.State = BusinessEntity.States.New;
                }
                else if (Modo == ModoForm.Modificacion) {
                    MateriaActual.State = BusinessEntity.States.Modified;
                    MateriaActual.ID = Int32.Parse(labelID.Text);
                }
            }
            else {
                MateriaActual.State = BusinessEntity.States.Deleted;
            }
        }
        private void GenerarPlanes(int idEsp, int idPlanActual) {
            //Se genera el comobox de planes el funcionamiento es igual al de especialidades solo que se pasa
            //el id de la esp para filtrar los planes de dicha esp
            cbPlan.ValueMember = "id_plan";
            cbPlan.DisplayMember = "desc_plan";
            cbPlan.DataSource = GenerarComboBox.getPlanes(idEsp, idPlanActual);
            cbPlan.SelectedValue = 0;
        }

        public override void GuardarCambios() {
            MapearADatos();
            MateriaLogic auxMateria = new MateriaLogic();
            auxMateria.Save(MateriaActual);
        }

        public override bool Validar() {
            lblRedDesc.Visible = (Validaciones.ValTexto(txtDescripcion.Text)) ? false : true;
            lblRedHSS.Visible = Validaciones.ValHSSem((int)nudHSSem.Value) ? false : true;
            lblRedHST.Visible = Validaciones.ValHSTot((int)nudHSTot.Value) ? false : true;
            lblRedPlan.Visible = ((int)cbEsp.SelectedValue == 0 || (int)cbPlan.SelectedValue == 0 ||
                                    cbEsp.SelectedValue == null || cbPlan.SelectedValue == null) ? true : false;

            return !(lblRedDesc.Visible ||
                lblRedHSS.Visible ||
                lblRedHST.Visible ||
                lblRedPlan.Visible); 

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

            private void cbEsp_SelectedValueChanged(object sender, EventArgs e) {
            if (cbEsp.SelectedValue != null) {
                //Si el valor del combobox de especialidades cambia, se vuelven a generar los planes
                //pasando como argumento el id de la especialidad para mostrar solo los planes que
                //corresponden a dicha especialidad
                cbPlan.Text = "";
                GenerarPlanes((int)cbEsp.SelectedValue, Modo == ModoForm.Alta ? 0 : MateriaActual.IDPlan);
            }
        }
    }
}
