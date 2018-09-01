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
    public partial class MateriaDesktop : ApplicationForm {

        private Business.Entities.Materia _materiaActual;
        public Business.Entities.Materia MateriaActual {
            get { return _materiaActual; }
            set { _materiaActual = value; }
        }

        public MateriaDesktop() {
            InitializeComponent();
            PlanLogic pl = new PlanLogic();
            List<Plan> planes = pl.GetAll();
            foreach (Plan pln in planes) {
            //    cbPlan.Items.Add(pln.IDString);
            }
        }
        public MateriaDesktop(ModoForm modo) : this() {
            Modo = modo;
        }

        public MateriaDesktop(int ID, ModoForm modo) : this() {
            Modo = modo;
            MateriaLogic auxMateria = new MateriaLogic();
            MateriaActual = auxMateria.GetOne(ID);
            MapearDeDatos();
        }

        public override void MapearDeDatos() {
            txtID.Text = MateriaActual.ID.ToString();
            txtDescripcion.Text = MateriaActual.Descripcion;
            txtHSSemanales.Text = MateriaActual.HSSemanales.ToString(); ;
            txtHSTotales.Text = MateriaActual.HSTotales.ToString(); ;
            PlanLogic pl = new PlanLogic();
            Plan pln = pl.GetOne(MateriaActual.IDPlan);
           // cbPlan.Text = pln.IDString;

            switch (Modo) {
                case ModoForm.Alta:
                case ModoForm.Modificacion:             //Equivalente a if(Modo == ModoForm.Alta || Modo == Modoform.Modificacion){...}        
                    btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    btnAceptar.Text = "Eliminar";
                    txtHSSemanales.ReadOnly = true;
                    txtHSTotales.ReadOnly = true;
                    txtDescripcion.ReadOnly = true;
                    cbPlan.Enabled = false;

                    break;
                case ModoForm.Consulta:
                    btnAceptar.Text = "Aceptar";
                    txtHSSemanales.ReadOnly = true;
                    txtHSTotales.ReadOnly = true;
                    txtDescripcion.ReadOnly = true;
                    cbPlan.Enabled = false;
                    break;
            }
        }

        public override void MapearADatos() {
            switch (Modo) {                                      //Emprolijar: Evitar repetición de asignaciones  
                case ModoForm.Alta:
                    MateriaActual = new Materia();
                    MateriaActual.Descripcion = txtDescripcion.Text;
                    MateriaActual.HSSemanales = int.Parse(txtHSSemanales.Text);
                    MateriaActual.HSSemanales = int.Parse(txtHSSemanales.Text);
                   // MateriaActual.IDPlan = getPlnID(cbPlan.Text);
                    MateriaActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    MateriaActual.Descripcion = txtDescripcion.Text;
                    MateriaActual.HSSemanales = int.Parse(txtHSSemanales.Text);
                    MateriaActual.HSSemanales = int.Parse(txtHSSemanales.Text);
                 //   MateriaActual.IDPlan = getPlnID(cbPlan.Text);
                    MateriaActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Baja:
                    MateriaActual.State = BusinessEntity.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    MateriaActual.State = BusinessEntity.States.Unmodified;
                    break;
            }
        }

        public override void GuardarCambios() {
            MapearADatos();
            MateriaLogic auxMateria = new MateriaLogic();
            auxMateria.Save(MateriaActual);
        }

        public override bool Validar() {
            return !(string.IsNullOrEmpty(txtHSSemanales.Text) ||        //Si cualquiera de estas condiciones es verdadera, retorna false
            string.IsNullOrEmpty(txtHSTotales.Text) ||
            string.IsNullOrEmpty(txtDescripcion.Text) ||
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

  //      private int getPlnID(string StrID) {
    //        PlanLogic pl = new PlanLogic();
      //      List<Plan> planes = pl.GetAll();
        //    foreach (Plan pln in planes) {
          //      if (pln.IDString == StrID) {
            //        return pln.ID;
              //  }
            //}
            //return (0);
        //}
    }
}
