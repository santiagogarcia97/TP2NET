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

namespace UI.Desktop.admin
{
    public partial class ABMCursosDesktop : ApplicationForm
    {
        private Curso _CursoActual;
        public Curso CursoActual {get { return _CursoActual; }set { _CursoActual = value; }}

        public ABMCursosDesktop(){
            InitializeComponent();

        }
        public ABMCursosDesktop(ModoForm modo) : this(){
            Modo = modo;
            GenerarEsp(0);
        }

        public ABMCursosDesktop(int ID, ModoForm modo) : this(){
            Modo = modo;
            CursoLogic auxCurso = new CursoLogic();
            CursoActual = auxCurso.GetOne(ID);        

            //busco la materia para conseguir la id del plan correspondiente
            MateriaLogic ml = new MateriaLogic();
            Materia mat = ml.GetOne(CursoActual.IDMateria);
            //busco el plan para conseguir la id de la especialidad correspondiente
            PlanLogic pl = new PlanLogic();
            Plan plan = pl.GetOne(mat.IDPlan);
            GenerarEsp(plan.IDEspecialidad);
            GenerarPlanes(plan.IDEspecialidad, plan.ID);
            GenerarComisiones(plan.ID, CursoActual.IDComision);
            GenerarMaterias(plan.ID, CursoActual.IDMateria);

            //paso el plan como argumento para tener el id del mismo y de su especialidad y poder seleccionarlos en los combobox
            MapearDeDatos(plan);
        }
        private void CursoDesktop_Load(object sender, EventArgs e) {
            lblRedCupo.Visible = false;
            lblRedAnio.Visible = false;
            lblRedCom.Visible = false;
            lblRedMat.Visible = false;
            lblRedPlan.Visible = false;
        }
        public void MapearDeDatos(Plan pln)
        {
            labelID.Text = CursoActual.ID.ToString();
            nudAnio.Value = CursoActual.AnioCalendario;
            nudCupo.Value = CursoActual.Cupo;
            cbEsp.SelectedValue = pln.IDEspecialidad;
            cbPlan.SelectedValue = pln.ID;
            cbMateria.SelectedValue = CursoActual.IDMateria;
            cbComision.SelectedValue = CursoActual.IDComision;

            switch (Modo) {
                case ModoForm.Alta:
                case ModoForm.Modificacion:             //Equivalente a if(Modo == ModoForm.Alta || Modo == Modoform.Modificacion){...}        
                    btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    btnAceptar.Text = "Eliminar";
                    nudAnio.ReadOnly = true;
                    nudCupo.ReadOnly = true;
                    cbMateria.Enabled = false;
                    cbComision.Enabled = false;
                    cbMateria.Enabled = false;
                    cbComision.Enabled = false;
                    break;
            }

        }

        public override void MapearADatos(){
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion) {
                CursoActual = new Curso {
                    Cupo = (int)nudCupo.Value,
                    AnioCalendario = (int)nudAnio.Value,
                    IDComision = (int)cbComision.SelectedValue,
                    IDMateria = (int)cbMateria.SelectedValue,

                    Habilitado = true
                };

                if (Modo == ModoForm.Alta) {
                    CursoActual.State = BusinessEntity.States.New;
                }
                else if (Modo == ModoForm.Modificacion) {
                    CursoActual.State = BusinessEntity.States.Modified;
                    CursoActual.ID = Int32.Parse(labelID.Text);
                }
            }
            else {
                CursoActual.State = BusinessEntity.States.Deleted;
            }
        }
        public override void GuardarCambios()
        {
            MapearADatos();
            CursoLogic auxCurso = new CursoLogic();
            auxCurso.Save(CursoActual);
        }

        public override bool Validar()
        {
            lblRedCupo.Visible = Validaciones.ValCupo((int)nudCupo.Value) ? false : true;
            lblRedAnio.Visible = Validaciones.ValAnio((int)nudAnio.Value) ? false : true;
            lblRedPlan.Visible = (cbEsp.SelectedValue == null || cbPlan.SelectedValue == null ||
                                   (int)cbEsp.SelectedValue == 0 || (int)cbPlan.SelectedValue == 0) ? true : false;
            lblRedCom.Visible = (cbComision.SelectedValue == null || (int)cbComision.SelectedValue == 0) ? true : false;
            lblRedMat.Visible = (cbMateria.SelectedValue == null || (int)cbMateria.SelectedValue == 0) ? true : false;

            return !(lblRedCupo.Visible ||
                lblRedAnio.Visible ||
                lblRedCom.Visible ||
                lblRedMat.Visible ||
                lblRedPlan.Visible);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar()){
                GuardarCambios();
                this.Close();
            }
            else{
                MessageBox.Show("Compruebe los datos ingresados.");
            }
        }
        private void GenerarEsp(int idEspActual) {
            cbEsp.ValueMember = "id_esp";
            cbEsp.DisplayMember = "desc_esp";
            cbEsp.DataSource = GenerarComboBox.getEspecialidades(idEspActual);
            cbEsp.SelectedValue = 0;
        }
        private void GenerarPlanes(int idEsp, int idPlanActual) {
            //Se genera el comobox de planes el funcionamiento es igual al de especialidades solo que se pasa
            //el id de la esp para filtrar los planes de dicha esp
            cbPlan.ValueMember = "id_plan";
            cbPlan.DisplayMember = "desc_plan";
            cbPlan.DataSource = GenerarComboBox.getPlanes(idEsp, idPlanActual);
            cbPlan.SelectedValue = 0;
        }
        private void GenerarMaterias(int idPlan, int idMatActual) {
            //Se genera el comobox de materias el funcionamiento es igual al de planes solo que se pasa
            //el id del plan para filtrar las materias de dicho plan
            cbMateria.ValueMember = "id_mat";
            cbMateria.DisplayMember = "desc_mat";
            cbMateria.DataSource = GenerarComboBox.getMaterias(idPlan, idMatActual);
            cbMateria.SelectedValue = 0;
        }
        private void GenerarComisiones(int idPlan, int idComActual) {
            //Se genera el combobox de comisiones, funciona exactamente igual que el de materias
            cbComision.ValueMember = "id_com";
            cbComision.DisplayMember = "desc_com";
            cbComision.DataSource = GenerarComboBox.getComisiones(idPlan, idComActual);
            cbComision.SelectedValue = 0;
        }

        private void cbEsp_SelectedValueChanged(object sender, EventArgs e) {
            if (cbEsp.SelectedValue != null) {
                //Si el valor del combobox de especialidades cambia, se vuelven a generar los planes
                //pasando como argumento el id de la especialidad para mostrar solo los planes que
                //corresponden a dicha especialidad
                MateriaLogic ml = new MateriaLogic();
                Materia mat = ml.GetOne(CursoActual.IDMateria);
                cbPlan.Text = "";
                GenerarPlanes((int)cbEsp.SelectedValue, Modo == ModoForm.Alta ? 0 : mat.IDPlan);
            }
        }

        private void cbPlan_SelectedValueChanged(object sender, EventArgs e) {
            if (cbPlan.SelectedValue != null) {
                //Si el valor del combobox de planes cambia, se vuelven a generar las comisiones y materias
                //pasando como argumento el id del plan para mostrar solo las que
                //corresponden a dicho plan
                cbComision.Text = "";
                cbMateria.Text = "";
                GenerarComisiones((int)cbPlan.SelectedValue, Modo == ModoForm.Alta ? 0 : CursoActual.IDComision);
                GenerarMaterias((int)cbPlan.SelectedValue, Modo == ModoForm.Alta ? 0 : CursoActual.IDMateria);
            }
        }
    }
}
