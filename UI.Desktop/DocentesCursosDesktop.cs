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
    public partial class DocentesCursosDesktop : ApplicationForm {

        private DocenteCurso _DocenteCursoActual;
        public DocenteCurso DocenteCursoActual { get => _DocenteCursoActual; set => _DocenteCursoActual = value; }

        public DocentesCursosDesktop() {
            InitializeComponent();
        }

        public DocentesCursosDesktop(ModoForm modo) : this() {
            Modo = modo;
        }

        public DocentesCursosDesktop(int ID, ModoForm modo) : this() {
            Modo = modo;
            DocenteCursoLogic auxDocenteCurso = new DocenteCursoLogic();
            DocenteCursoActual = auxDocenteCurso.GetOne(ID);
            MapearDeDatos();
        }

        public override void MapearDeDatos() {
            txtID.Text = DocenteCursoActual.ID.ToString();
            txtIDCurso.Text = DocenteCursoActual.IDCurso.ToString();
            txtIDDocente.Text = DocenteCursoActual.IDDocente.ToString();
            txtCargo.Text = DocenteCursoActual.Cargo.ToString();

            switch (Modo) {
                case ModoForm.Alta:
                case ModoForm.Modificacion:             //Equivalente a if(Modo == ModoForm.Alta || Modo == Modoform.Modificacion){...}
                    btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    btnAceptar.Text = "Eliminar";
                    txtCargo.ReadOnly = true;
                    break;
            }
        }

        public override void MapearADatos() {
            switch (Modo) {                                      
                case ModoForm.Alta:
                    DocenteCursoActual = new DocenteCurso();
                    DocenteCursoActual.IDCurso = Int32.Parse(txtIDCurso.Text);
                    DocenteCursoActual.IDDocente = Int32.Parse(txtIDDocente.Text);
                    DocenteCursoActual.Cargo = (DocenteCurso.TipoCargos)System.Enum.Parse(typeof(DocenteCurso.TipoCargos), txtCargo.Text);
                    DocenteCursoActual.Habilitado = true;
                    DocenteCursoActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    DocenteCursoActual.IDCurso = Int32.Parse(txtIDCurso.Text);
                    DocenteCursoActual.IDDocente = Int32.Parse(txtIDDocente.Text);
                    DocenteCursoActual.Cargo = (DocenteCurso.TipoCargos)System.Enum.Parse(typeof(DocenteCurso.TipoCargos), txtCargo.Text);
                    DocenteCursoActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Baja:
                    DocenteCursoActual.State = BusinessEntity.States.Deleted;
                    break;
            }
        }

        public override void GuardarCambios() {
            MapearADatos();
            DocenteCursoLogic auxDocenteCurso = new DocenteCursoLogic();
            auxDocenteCurso.Save(DocenteCursoActual);
        }

        public override bool Validar() {
            return !(string.IsNullOrEmpty(txtCargo.Text));
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
    }
}
