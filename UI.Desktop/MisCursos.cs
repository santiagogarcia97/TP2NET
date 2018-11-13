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

namespace UI.Desktop
{
    public partial class MisCursos : ApplicationForm
    {
        private Usuario _UsuarioActual;
        public Usuario UsuarioActual { get => _UsuarioActual; set => _UsuarioActual = value; }

        public MisCursos(Usuario user)
        {
            InitializeComponent();
            this.dgvCursos.AutoGenerateColumns = false;
            UsuarioActual = user;
            Listar();
        }

        public void Listar() {
            //Se limpia el dgv
            this.dgvCursos.DataSource = null;
            this.dgvCursos.Refresh();

            List<Curso> cursos = new List<Curso>();

            DocenteCursoLogic dcl = new DocenteCursoLogic();
            List<DocenteCurso> dclist = dcl.GetAllFromUser(UsuarioActual.ID);
            CursoLogic cl = new CursoLogic();

            foreach (DocenteCurso dc in dclist) {
                cursos.Add(cl.GetOne(dc.IDCurso));
            }

            if (cursos.Count == 0) {
                MessageBox.Show("No hay cursos disponibles");
            }
            else {
                dgvCursos.DataSource = Listado.Generar(cursos);
            }
            
        }


        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvCursos.SelectedRows.Count != 0) {
                int ID = (int)this.dgvCursos.SelectedRows[0].Cells["id"].Value;
                MisInscripciones ai = new MisInscripciones(UsuarioActual, ID);
                ai.ShowDialog();                   
            }
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
