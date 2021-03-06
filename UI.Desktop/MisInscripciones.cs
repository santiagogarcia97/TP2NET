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

namespace UI.Desktop{
    public partial class MisInscripciones : ApplicationForm{

        private Usuario _UsuarioActual;
        private int _IDCurso;
        public Usuario UsuarioActual { get => _UsuarioActual; set => _UsuarioActual = value; }
        public int IDCurso { get => _IDCurso; set => _IDCurso = value; }

        public MisInscripciones(){
            InitializeComponent();
            this.dgvAlumnoInscripciones.AutoGenerateColumns = false;
        }
        public MisInscripciones(Usuario user) : this() {
            UsuarioActual = user;
            if((int)UsuarioActual.TipoPersona == 1) {
                tcAlumnoInscripciones.TopToolStripPanel.Visible = false;
            }
        }
        public MisInscripciones(Usuario user, int id) : this() {
            UsuarioActual = user;
            IDCurso = id;
            tsbNuevo.Visible = false;
            tsbEliminar.Visible = false;
        }
        private void AlumnoInscripciones_Load(object sender, EventArgs e) {
            Listar();
        }

        public void Listar(){
            this.dgvAlumnoInscripciones.DataSource = null;
            this.dgvAlumnoInscripciones.Refresh();

            AlumnoInscripcionLogic ins = new AlumnoInscripcionLogic();
            List<AlumnoInscripcion> inscripciones = new List<AlumnoInscripcion>();
            if ((int)UsuarioActual.TipoPersona == 1) {
                inscripciones = ins.GetAll().Where(x => x.IDAlumno == UsuarioActual.ID).ToList();
            }
            else if ((int)UsuarioActual.TipoPersona == 2) {
                inscripciones = ins.GetAllFromCurso(IDCurso);
            }
            else if ((int)UsuarioActual.TipoPersona == 3) {
                inscripciones = ins.GetAll();
            }
            if (inscripciones.Count() == 0){
                MessageBox.Show("No hay inscripciones cargadas!");
            }

            if (inscripciones.Count == 0) {
                MessageBox.Show("No esta inscripto a ningun curso.");
            }
            else {
                this.dgvAlumnoInscripciones.DataSource = Listado.Generar(inscripciones);
            }
        }

        private void tsbNuevo_Click(object sender, EventArgs e){
            InscribirCursos alumnoInscripcionDesktop = new InscribirCursos(ApplicationForm.ModoForm.Alta, UsuarioActual);
            alumnoInscripcionDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e){
                InscribirCursos alumnoInscripcionDesktop = new InscribirCursos(ApplicationForm.ModoForm.Baja, UsuarioActual);
                alumnoInscripcionDesktop.ShowDialog();
                this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e){
            this.Close();
        }

        private void tsbEditar_Click(object sender, EventArgs e) {
            if (this.dgvAlumnoInscripciones.SelectedRows.Count != 0) {
                int ID = (int)this.dgvAlumnoInscripciones.SelectedRows[0].Cells["id"].Value;
                AlumnoInscripcionLogic ins = new AlumnoInscripcionLogic();
                AlumnoInscripcion inscripcion = ins.GetOne(ID);
                CargaNotas cn = new CargaNotas(inscripcion);
                cn.ShowDialog();
                this.Listar();
            }
        }
    }
}
