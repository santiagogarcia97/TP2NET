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
    public partial class ABMEspecialidades : ApplicationForm {
        public ABMEspecialidades() {
            InitializeComponent();
            this.dgvEspecialidades.AutoGenerateColumns = false;
        }

        public void Listar() {
            this.dgvEspecialidades.DataSource = null;
            this.dgvEspecialidades.Refresh();
            EspecialidadLogic esp = new EspecialidadLogic();
            List<Especialidad> especialidades = esp.GetAll().Where(x => x.Habilitado == true).ToList(); ;
            if (especialidades.Count() == 0)
            {
                MessageBox.Show("No hay especialidades cargadas!");
            }
            this.dgvEspecialidades.DataSource = especialidades;
        }

        private void Especialidades_Load(object sender, EventArgs e) {
            Listar();
        }

        private void tsbNuevo_Click(object sender, EventArgs e) {
            ABMEspecialidadesDesktop especialidadDesktop = new ABMEspecialidadesDesktop(ApplicationForm.ModoForm.Alta);
            especialidadDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e) {
            if (this.dgvEspecialidades.SelectedRows.Count != 0) {
                int ID = ((Business.Entities.Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
                ABMEspecialidadesDesktop especialidadDesktop = new ABMEspecialidadesDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                especialidadDesktop.ShowDialog();
                this.Listar();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e) {
            if (this.dgvEspecialidades.SelectedRows.Count != 0) {
                int ID = ((Business.Entities.Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
                ABMEspecialidadesDesktop especialidadDesktop = new ABMEspecialidadesDesktop(ID, ApplicationForm.ModoForm.Baja);
                especialidadDesktop.ShowDialog();
                this.Listar();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
