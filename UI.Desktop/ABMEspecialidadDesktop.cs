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
    public partial class ABMEspecialidadDesktop : ApplicationForm {

        private Business.Entities.Especialidad especialidadActual;
        public Especialidad EspecialidadActual { get => especialidadActual; set => especialidadActual = value; }

        public ABMEspecialidadDesktop() {
            InitializeComponent();
        }

        public ABMEspecialidadDesktop(ModoForm modo) : this() {
            Modo = modo;
        }

        public ABMEspecialidadDesktop(int ID, ModoForm modo) : this() {
            Modo = modo;
            EspecialidadLogic auxEspecialidad = new EspecialidadLogic();
            EspecialidadActual = auxEspecialidad.GetOne(ID);
            MapearDeDatos();
        }

        public override void MapearDeDatos() {
            txtID.Text = EspecialidadActual.ID.ToString();
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
                    EspecialidadActual = new Especialidad();
                    EspecialidadActual.Descripcion = txtDescripcion.Text;
                    especialidadActual.Habilitado = true;
                    EspecialidadActual.State = BusinessEntity.States.New;
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
            return !(string.IsNullOrWhiteSpace(txtDescripcion.Text));
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
