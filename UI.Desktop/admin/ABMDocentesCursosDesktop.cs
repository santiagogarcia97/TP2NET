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
    public partial class ABMDocentesCursosDesktop : ApplicationForm {

        private DocenteCurso _DocenteCursoActual;
        public DocenteCurso DocenteCursoActual { get => _DocenteCursoActual; set => _DocenteCursoActual = value; }

        public ABMDocentesCursosDesktop() {
            InitializeComponent();

            cbCurso.DisplayMember = "desc_curso";
            cbCurso.ValueMember = "id_curso";
          //  cbCurso.DataSource = GenerarComboBox.getCursos();
            cbCurso.SelectedValue = 0;

            cbDocente.DisplayMember = "desc_docente";
            cbDocente.ValueMember = "id_docente";
     //       cbDocente.DataSource = GenerarComboBox.getDocentes();
            cbDocente.SelectedValue = 0;

            cbCargo.DisplayMember = "desc_cargo";
            cbCargo.ValueMember = "id_cargo";
            cbCargo.DataSource = GenerarComboBox.getCargos();
            cbCargo.SelectedValue = 0;

            lblCargoRed.Visible = false;
            lblCursoRed.Visible = false;
            lblDocenteRed.Visible = false;
        }

        public ABMDocentesCursosDesktop(ModoForm modo) : this() {
            Modo = modo;
        }

        public ABMDocentesCursosDesktop(int ID, ModoForm modo) : this() {
            Modo = modo;
            DocenteCursoLogic auxDocenteCurso = new DocenteCursoLogic();
            DocenteCursoActual = auxDocenteCurso.GetOne(ID);
            MapearDeDatos();
        }

        public override void MapearDeDatos() {
            lblID.Text = DocenteCursoActual.ID.ToString();
            cbCurso.SelectedValue = DocenteCursoActual.IDCurso;
            cbDocente.SelectedValue = DocenteCursoActual.IDDocente;
            cbCargo.SelectedValue = DocenteCursoActual.Cargo;

            switch (Modo) {
                case ModoForm.Alta:
                case ModoForm.Modificacion:             //Equivalente a if(Modo == ModoForm.Alta || Modo == Modoform.Modificacion){...}
                    btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    btnAceptar.Text = "Eliminar";
                    cbCargo.Enabled = false;
                    cbCurso.Enabled = false;
                    cbDocente.Enabled = false;
                    break;
            }
        }

        public override void MapearADatos() {
            switch (Modo) {                                      
                case ModoForm.Alta:
                    DocenteCursoActual = new DocenteCurso();
                    DocenteCursoActual.IDCurso = Int32.Parse(lblID.Text);
                    DocenteCursoActual.IDDocente = (int)cbDocente.SelectedValue;
                    DocenteCursoActual.Cargo = (DocenteCurso.TipoCargos)cbCargo.SelectedValue;
                    DocenteCursoActual.Habilitado = true;
                    DocenteCursoActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    DocenteCursoActual.IDCurso = Int32.Parse(lblID.Text);
                    DocenteCursoActual.IDDocente = (int)cbDocente.SelectedValue;
                    DocenteCursoActual.Cargo = (DocenteCurso.TipoCargos)cbCargo.SelectedValue;
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
            lblCursoRed.Visible = (cbCurso.SelectedValue == null || (int)cbCurso.SelectedValue == 0) ? true : false;
            lblDocenteRed.Visible = (cbDocente.SelectedValue == null || (int)cbDocente.SelectedValue == 0) ? true : false;
            lblCargoRed.Visible = (cbCargo.SelectedValue == null || (int)cbCargo.SelectedValue == 0) ? true : false;

            return !(lblCargoRed.Visible ||
                    lblCursoRed.Visible ||
                    lblDocenteRed.Visible);
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
