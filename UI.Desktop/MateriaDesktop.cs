﻿using System;
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
    public partial class MateriaDesktop : ApplicationForm {

        private Materia _materiaActual;
        public Materia MateriaActual {get { return _materiaActual; }set { _materiaActual = value; }}

        public MateriaDesktop() {
            InitializeComponent();

            //Se genera el comobox de especialidades
            //getEspecialidades devuelve un DataTable con un columna de ID y otra de Descripcion
            //La de ID se usa como valor interno al seleccionar una opcion y la Desc es la que se muestra al usuario
            cbEsp.ValueMember = "id_esp";
            cbEsp.DisplayMember = "desc_esp";
            cbEsp.DataSource = GenerarComboBox.getEspecialidades();
        }
        public MateriaDesktop(ModoForm modo) : this() {
            Modo = modo;
        }

        public MateriaDesktop(int ID, ModoForm modo) : this() {
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
            txtHSSemanales.Text = MateriaActual.HSSemanales.ToString(); ;
            txtHSTotales.Text = MateriaActual.HSTotales.ToString(); ;
            cbEsp.SelectedValue = pln.IDEspecialidad;
            cbPlan.SelectedValue = MateriaActual.IDPlan;

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
                    cbEsp.Enabled = false;
                    cbPlan.Enabled = false;
                    break;
            }
        }

        public override void MapearADatos() {
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion) {
                MateriaActual = new Materia();
                MateriaActual.Descripcion = txtDescripcion.Text;
                MateriaActual.HSSemanales = Int32.Parse(txtHSSemanales.Text);
                MateriaActual.HSTotales = Int32.Parse(txtHSTotales.Text);
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
        }

        public override void GuardarCambios() {
            MapearADatos();
            MateriaLogic auxMateria = new MateriaLogic();
            auxMateria.Save(MateriaActual);
        }

        public override bool Validar() {
            lblRedDesc.Visible = (string.IsNullOrWhiteSpace(txtDescripcion.Text)) ? true : false;
            lblRedHSS.Visible = (string.IsNullOrWhiteSpace(txtHSSemanales.Text)) ? true : false;
            lblRedHST.Visible = (string.IsNullOrWhiteSpace(txtHSTotales.Text)) ? true : false;
            lblRedPlan.Visible = (cbEsp.SelectedValue == null || cbPlan.SelectedValue == null) ? true : false;

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
