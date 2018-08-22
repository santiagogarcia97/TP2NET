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


namespace UI.Desktop {
    public partial class ComisionDesktop : ApplicationForm {

        private Comision _ComisionActual;
        public Comision ComisionActual { get => _ComisionActual; set => _ComisionActual = value; }

        public ComisionDesktop() {
            InitializeComponent();
            PlanLogic pl = new PlanLogic();
            List<Plan> planes = pl.GetAll();
            foreach (Plan pln in planes) {
                cbPlan.Items.Add(pln.IDString);
            }
        }

        public ComisionDesktop(ModoForm modo) : this() {
            Modo = modo;
        }

        public ComisionDesktop(int ID, ModoForm modo) : this() {
            Modo = modo;
            ComisionLogic auxComision = new ComisionLogic();
            ComisionActual = auxComision.GetOne(ID);
            MapearDeDatos();
        }

        public override void MapearDeDatos() {
            txtID.Text = ComisionActual.ID.ToString();
            txtDescripcion.Text = ComisionActual.Descripcion;
            txtAnio.Text = ComisionActual.AnioEspecialidad.ToString();
            PlanLogic pl = new PlanLogic();
            Plan pln = pl.GetOne(ComisionActual.IDPlan);
            cbPlan.Text = pln.IDString;

            switch (Modo) {
                case ModoForm.Alta:
                case ModoForm.Modificacion:                     //Equivalente a if(Modo == ModoForm.Alta || Modo == Modoform.Modificacion){...}
                    btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    btnAceptar.Text = "Eliminar";
                    txtDescripcion.ReadOnly = true;
                    cbPlan.Enabled = false;
                    break;
                case ModoForm.Consulta:
                    btnAceptar.Text = "Aceptar";
                    txtDescripcion.ReadOnly = true;
                    cbPlan.Enabled = false;
                    break;
            }
        }

        public override void MapearADatos() {
            switch (Modo) {                                      //Emprolijar: Evitar repetición de asignaciones  
                case ModoForm.Alta:
                    ComisionActual = new Comision();
                    ComisionActual.Descripcion = txtDescripcion.Text;
                    ComisionActual.AnioEspecialidad = Int32.Parse(txtAnio.Text);
                    ComisionActual.IDPlan = getPlnID(cbPlan.Text);
                    ComisionActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    ComisionActual.Descripcion = txtDescripcion.Text;
                    ComisionActual.AnioEspecialidad = Int32.Parse(txtAnio.Text);
                    ComisionActual.IDPlan = getPlnID(cbPlan.Text);
                    ComisionActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Baja:
                    ComisionActual.State = BusinessEntity.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    ComisionActual.State = BusinessEntity.States.Unmodified;
                    break;
            }
        }

        public override void GuardarCambios() {
            MapearADatos();
            ComisionLogic auxComision = new ComisionLogic();
            auxComision.Save(ComisionActual);
        }

        public override bool Validar() {
            return !(string.IsNullOrEmpty(txtDescripcion.Text) ||
                     string.IsNullOrEmpty(txtAnio.Text) ||
                     string.IsNullOrEmpty(cbPlan.Text));
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

        private int getPlnID(string StrID) {
            PlanLogic pl = new PlanLogic();
            List<Plan> planes = pl.GetAll();
            foreach (Plan pln in planes) {
                if (pln.IDString == StrID) {
                    return pln.ID;
                }
            }
            return (0);
        }

    }
}
