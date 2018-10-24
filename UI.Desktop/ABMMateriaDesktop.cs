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
    public partial class ABMMateriaDesktop : ApplicationForm {

        private Materia _materiaActual;
        public Materia MateriaActual {get { return _materiaActual; }set { _materiaActual = value; }}

        public ABMMateriaDesktop() {
            InitializeComponent();

            //Se genera el comobox de especialidades
            //getEspecialidades devuelve un DataTable con un columna de ID y otra de Descripcion
            //La de ID se usa como valor interno al seleccionar una opcion y la Desc es la que se muestra al usuario
            cbEsp.ValueMember = "id_esp";
            cbEsp.DisplayMember = "desc_esp";
            cbEsp.DataSource = GenerarComboBox.getEspecialidades();
            cbEsp.SelectedValue = 0;
        }
        public ABMMateriaDesktop(ModoForm modo) : this() {
            Modo = modo;
        }

        public ABMMateriaDesktop(int ID, ModoForm modo) : this() {
            Modo = modo;
            MateriaLogic auxMateria = new MateriaLogic();
            MateriaActual = auxMateria.GetOne(ID);

            PlanLogic pl = new PlanLogic();
            Plan plan = pl.GetOne(MateriaActual.IDPlan);

            GenerarPlanes(plan.IDEspecialidad);

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
                MateriaActual = new Materia();
                MateriaActual.Descripcion = txtDescripcion.Text;
                MateriaActual.HSSemanales = (int)nudHSSem.Value;
                MateriaActual.HSTotales = (int)nudHSTot.Value;
                MateriaActual.IDPlan = (int)cbPlan.SelectedValue;

                MateriaActual.Habilitado = true;

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
        private void GenerarPlanes(int idEsp) {
            //Se genera el comobox de planes el funcionamiento es igual al de especialidades solo que se pasa
            //el id de la esp para filtrar los planes de dicha esp
            cbPlan.ValueMember = "id_plan";
            cbPlan.DisplayMember = "desc_plan";
            cbPlan.DataSource = GenerarComboBox.getPlanes(idEsp);
            cbPlan.SelectedValue = 0;
        }

        public override void GuardarCambios() {
            MapearADatos();
            MateriaLogic auxMateria = new MateriaLogic();
            auxMateria.Save(MateriaActual);
        }

        public override bool Validar() {
            lblRedDesc.Visible = (string.IsNullOrWhiteSpace(txtDescripcion.Text)) ? true : false;
            lblRedHSS.Visible = (nudHSSem.Value == 0) ? true : false;
            lblRedHST.Visible = (nudHSTot.Value == 0) ? true : false;
            lblRedPlan.Visible = ((int)cbEsp.SelectedValue == 0 || (int)cbPlan.SelectedValue == 0 ||
                                    cbEsp.SelectedValue == null || cbPlan.SelectedValue == null) ? true : false;

            if (lblRedDesc.Visible == true ||
                lblRedHSS.Visible == true ||
                lblRedHST.Visible == true ||
                lblRedPlan.Visible == true) {
                return false;
            }
            else {
                return true;
            }
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
