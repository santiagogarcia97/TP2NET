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
    public partial class ABMEspecialidadesDesktop : ApplicationForm {

        private Especialidad _EspecialidadActual;
        public Especialidad EspecialidadActual { get => _EspecialidadActual; set => _EspecialidadActual = value; }

        public ABMEspecialidadesDesktop() {
            InitializeComponent();
        }

        public ABMEspecialidadesDesktop(ModoForm modo) : this() {//alta
            Modo = modo;
        }

        public ABMEspecialidadesDesktop(int ID, ModoForm modo) : this() {//baja o mod
            Modo = modo;
            EspecialidadLogic auxEspecialidad = new EspecialidadLogic();
            EspecialidadActual = auxEspecialidad.GetOne(ID);
            MapearDeDatos();
        }

        public override void MapearDeDatos() {
            lblID.Text = EspecialidadActual.ID.ToString();
            txtDescripcion.Text = EspecialidadActual.Descripcion;

            switch (Modo) {
                case ModoForm.Alta:
                case ModoForm.Modificacion:             //Equivalente a if(Modo == ModoForm.Alta || Modo == Modoform.Modificacion){...}
                    btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    btnAceptar.Text = "Eliminar";
                    txtDescripcion.ReadOnly = true;
                    break;
            }
        }

        public override void MapearADatos() {
            switch (Modo) {                                      
                case ModoForm.Alta:
                    EspecialidadActual = new Especialidad {
                        Descripcion = txtDescripcion.Text,
                        Habilitado = true,
                        State = BusinessEntity.States.New
                    };
                    break;
                case ModoForm.Modificacion:
                    EspecialidadActual.Descripcion = txtDescripcion.Text;
                    EspecialidadActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Baja:
                    EspecialidadActual.State = BusinessEntity.States.Deleted;
                    break;
            }
        }

        public override void GuardarCambios() {
            MapearADatos();
            EspecialidadLogic auxEspecialidad = new EspecialidadLogic();
            auxEspecialidad.Save(EspecialidadActual);
        }

        public override bool Validar() {
            if (Validaciones.ValTexto(txtDescripcion.Text)) return true;
            else{
                lblRedDesc.Visible = true;
                return false;
            }
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
    }
}
