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

namespace UI.Desktop
{
    public partial class CursoDesktop : ApplicationForm
    {
        private Business.Entities.Curso _cursoActual;
        public Business.Entities.Curso CursoActual {
            get { return _cursoActual; }
            set { _cursoActual = value; }
        }

        public CursoDesktop()
        {
            InitializeComponent();
            MateriaLogic ml = new MateriaLogic();
            List<Materia> materias = ml.GetAll();
            foreach (Materia mat in materias)
            {
                cbMateria.Items.Add(mat.IDString);
            }

            ComisionLogic cl = new ComisionLogic();
            List<Comision> comisiones = cl.GetAll();
            foreach (Comision com in comisiones)
            {
                cbComision.Items.Add(com.IDString);
            }

        }
        public CursoDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }

        public CursoDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            CursoLogic auxCurso = new CursoLogic();
            CursoActual = auxCurso.GetOne(ID);
            MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            txtID.Text = CursoActual.ID.ToString();
            txtDescripcion.Text = CursoActual.Descripcion;
            txtAnio.Text = CursoActual.AnioCalendario.ToString();
            txtCupo.Text = CursoActual.Cupo.ToString();

            MateriaLogic ml = new MateriaLogic();
            Materia mat = ml.GetOne(CursoActual.IDMateria);
            cbMateria.Text = mat.IDString;

            ComisionLogic cl = new ComisionLogic();
            Comision com = cl.GetOne(CursoActual.IDComision);
            cbComision.Text = com.IDString;


            switch (Modo)
            {
                case ModoForm.Alta:
                case ModoForm.Modificacion:             //Equivalente a if(Modo == ModoForm.Alta || Modo == Modoform.Modificacion){...}        
                    btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    btnAceptar.Text = "Eliminar";
                    txtAnio.ReadOnly = true;
                    txtCupo.ReadOnly = true;
                    txtDescripcion.ReadOnly = true;
                    cbMateria.Enabled = false;
                    cbComision.Enabled = false;

                    break;
                case ModoForm.Consulta:
                    btnAceptar.Text = "Aceptar";
                    txtAnio.ReadOnly = true;
                    txtCupo.ReadOnly = true;
                    txtDescripcion.ReadOnly = true;
                    cbMateria.Enabled = false;
                    cbComision.Enabled = false;
                    break;
            }
        }

        public override void MapearADatos()
        {
            switch (Modo)
            {                                      //Emprolijar: Evitar repetición de asignaciones  
                case ModoForm.Alta:
                    CursoActual = new Curso();
                    CursoActual.Descripcion = txtDescripcion.Text;
                    CursoActual.IDComision = getComID(cbComision.Text);
                    CursoActual.IDMateria = getMatID(cbMateria.Text);
                    CursoActual.AnioCalendario = int.Parse(txtAnio.Text);
                    CursoActual.Cupo = int.Parse(txtCupo.Text);
                    CursoActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    CursoActual.Descripcion = txtDescripcion.Text;
                    CursoActual.IDComision = getComID(cbComision.Text);
                    CursoActual.IDMateria = getMatID(cbMateria.Text);
                    CursoActual.AnioCalendario = int.Parse(txtAnio.Text);
                    CursoActual.Cupo = int.Parse(txtCupo.Text);
                    CursoActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Baja:
                    CursoActual.State = BusinessEntity.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    CursoActual.State = BusinessEntity.States.Unmodified;
                    break;
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
            return !(string.IsNullOrEmpty(txtAnio.Text) ||        //Si cualquiera de estas condiciones es verdadera, retorna false
            string.IsNullOrEmpty(txtCupo.Text) ||
            string.IsNullOrEmpty(txtDescripcion.Text) ||
            string.IsNullOrEmpty(cbComision.Text) ||
            string.IsNullOrEmpty(cbMateria.Text));
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                this.Close();
            }
            else
            {
                MessageBox.Show("Commlete todos los campos.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int getMatID(string StrID)
        {
            MateriaLogic ml = new MateriaLogic();
            List<Materia> materias = ml.GetAll();
            foreach (Materia mat in materias)
            {
                if (mat.IDString == StrID)
                {
                    return mat.ID;
                }
            }
            return (0);
        }

        private int getComID(string StrID)
        {
            ComisionLogic cl = new ComisionLogic();
            List<Comision> comisiones = cl.GetAll();
            foreach (Comision com in comisiones)
            {
                if (com.IDString == StrID)
                {
                    return com.ID;
                }
            }
            return (0);
        }

    }
}
