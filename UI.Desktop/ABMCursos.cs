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

namespace UI.Desktop {
    public partial class ABMCursos : ApplicationForm
    {
        private Usuario _UsuarioActual;
        public Usuario UsuarioActual { get => _UsuarioActual; set => _UsuarioActual = value; }

        public ABMCursos(){
            InitializeComponent();
            this.dgvCursos.AutoGenerateColumns = false;
        }
        public ABMCursos(Usuario user) : this() {
            UsuarioActual = user;
            if ((int)UsuarioActual.TipoPersona == 2) {
                tsbEliminar.Visible = false;
                tsbNuevo.Visible = false;
            }
        }

        public void Listar() {
            //Se limpia el dgv
            this.dgvCursos.DataSource = null;
            this.dgvCursos.Refresh();

            CursoLogic cl = new CursoLogic();
            this.dgvCursos.DataSource = cl.GetListado(UsuarioActual);
            
        }

        private void Cursos_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            ABMCursosDesktop cursoDesktop = new ABMCursosDesktop(ApplicationForm.ModoForm.Alta);
            cursoDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvCursos.SelectedRows.Count != 0)
            {
                int ID = (int)this.dgvCursos.SelectedRows[0].Cells["id"].Value;
                if ((int)UsuarioActual.TipoPersona == 3) {
                    ABMCursosDesktop cursoDesktop = new ABMCursosDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                    cursoDesktop.ShowDialog();
                }
                else if((int)UsuarioActual.TipoPersona == 2) {
                    MisInscripciones ai = new MisInscripciones(UsuarioActual, ID);
                    ai.ShowDialog();                   
                }
                this.Listar();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvCursos.SelectedRows.Count != 0)
            {
                int ID = (int)this.dgvCursos.SelectedRows[0].Cells["id"].Value;
                ABMCursosDesktop cursoDesktop = new ABMCursosDesktop(ID, ApplicationForm.ModoForm.Baja);
                cursoDesktop.ShowDialog();
                this.Listar();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
