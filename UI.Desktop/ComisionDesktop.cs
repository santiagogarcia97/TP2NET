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
            txtPlan.Text = ComisionActual.IDPlan.ToString();
            txtAnio.Text = ComisionActual.AnioEspecialidad.ToString();

            switch (Modo) {
                case ModoForm.Alta:
                case ModoForm.Modificacion:                     //Equivalente a if(Modo == ModoForm.Alta || Modo == Modoform.Modificacion){...}
                    btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    btnAceptar.Text = "Eliminar";
                    txtDescripcion.ReadOnly = true;
                    break;
                case ModoForm.Consulta:
                    btnAceptar.Text = "Aceptar";
                    txtDescripcion.ReadOnly = true;
                    break;
            }
        }

        public override void MapearADatos() {
            switch (Modo) {                                      //Emprolijar: Evitar repetición de asignaciones  
                case ModoForm.Alta:
                    ComisionActual = new Comision();
                    ComisionActual.Descripcion = txtDescripcion.Text;
                    ComisionActual.IDPlan = Int32.Parse(txtPlan.Text);
                    ComisionActual.AnioEspecialidad = Int32.Parse(txtAnio.Text);
                    ComisionActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    ComisionActual.Descripcion = txtDescripcion.Text;
                    ComisionActual.IDPlan = Int32.Parse(txtPlan.Text);
                    ComisionActual.AnioEspecialidad = Int32.Parse(txtAnio.Text);
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
            return !(string.IsNullOrEmpty(txtDescripcion.Text));
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
