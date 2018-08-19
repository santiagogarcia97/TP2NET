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
    public partial class PlanDesktop : ApplicationForm {

        private Business.Entities.Plan _planActual;
        public Business.Entities.Plan PlanActual {
            get { return _planActual; }
            set { _planActual = value; }
        }

        public PlanDesktop() {
            InitializeComponent();
        }

        public PlanDesktop(ModoForm modo) : this() {
            Modo = modo;
        }

        public PlanDesktop(int ID, ModoForm modo) : this() {
            Modo = modo;
            PlanLogic auxPlan = new PlanLogic();
            PlanActual = auxPlan.GetOne(ID);
            MapearDeDatos();
        }

        public override void MapearDeDatos() {
            txtID.Text = PlanActual.ID.ToString();
            txtDescripcion.Text = PlanActual.Descripcion;

            switch (Modo) {
                case ModoForm.Alta:
                case ModoForm.Modificacion:                     //Equivalente a if(Modo == ModoForm.Alta || Modo == Modoform.Modificacion){...}
                    btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    btnAceptar.Text = "Eliminar";
                    txtDescripcion.ReadOnly = true;
                    cbEspecialidad.Enabled = false;

                    break;
                case ModoForm.Consulta:
                    btnAceptar.Text = "Aceptar";
                    txtDescripcion.ReadOnly = true;
                    cbEspecialidad.Enabled = false;
                    break;
            }
        }

        public override void MapearADatos() {
            switch (Modo) {                                      //Emprolijar: Evitar repetición de asignaciones  
                case ModoForm.Alta:
                    PlanActual = new Plan();
                    PlanActual.Descripcion = txtDescripcion.Text;
                    PlanActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    PlanActual.Descripcion = txtDescripcion.Text;
                    PlanActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Baja:
                    PlanActual.State = BusinessEntity.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    PlanActual.State = BusinessEntity.States.Unmodified;
                    break;
            }
        }

        public override void GuardarCambios() {
            MapearADatos();
            PlanLogic auxPlan = new PlanLogic();
            auxPlan.Save(PlanActual);
        }

        public override bool Validar() {
            return !(                                     //Si cualquiera de estas condiciones es verdadera, retorna false
            string.IsNullOrEmpty(txtDescripcion.Text) ||
            string.IsNullOrEmpty(cbEspecialidad.Text));
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
    }
}
