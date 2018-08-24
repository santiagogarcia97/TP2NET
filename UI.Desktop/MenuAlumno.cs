using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class MenuAlumno : Form
    {
        public MenuAlumno()
        {
            InitializeComponent();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            Usuarios formUsuarios = new Usuarios();
            formUsuarios.ShowDialog(); // El metodo showDialog hace que el form se abra de forma modal, no se puede interactuar con el menu hasta que no se cierre el form abierto
        }

        private void btnPlanes_Click(object sender, EventArgs e)
        {
            Planes formPlanes = new Planes();
            formPlanes.ShowDialog();
        }

        private void btnEspecialidades_Click(object sender, EventArgs e)
        {
            Especialidades formEspecialidades = new Especialidades();
            formEspecialidades.ShowDialog();
        }

        private void btnMaterias_Click(object sender, EventArgs e)
        {
            Materias formMaterias = new Materias();
            formMaterias.ShowDialog();
        }

        private void btnComisiones_Click(object sender, EventArgs e) {
            Comisiones formComisiones = new Comisiones();
            formComisiones.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
