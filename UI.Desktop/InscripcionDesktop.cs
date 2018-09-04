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
using static Business.Entities.AlumnoInscripcion;

namespace UI.Desktop
{
    public partial class InscripcionDesktop : ApplicationForm
    {
        private AlumnoInscripcion _inscripcionActual;

        public AlumnoInscripcion InscripcionActual {
            get { return _inscripcionActual; }
            set { _inscripcionActual  = value; }
        }


        public InscripcionDesktop()
        {
            InitializeComponent();
            UsuarioLogic ul = new UsuarioLogic();
            List<Usuario> usuarios = ul.GetAll();
            foreach (Usuario usr in usuarios)
            {
        //        if (usr.TipoPersona == 1){
          //          cbAlumno.Items.Add(usr.IDString);
            //    }
            }
            CursoLogic cl = new CursoLogic();
            List<Curso> cursos = cl.GetAll();
            foreach (Curso cur in cursos)
            {
           //     cbCurso.Items.Add(cur.IDString);
            }
            foreach (string con in Enum.GetNames(typeof(Condiciones)))
            {
                cbCondicion.Items.Add(con);
            }   
        }

        public InscripcionDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }


        public InscripcionDesktop(ModoForm modo, int ID) : this()
        {
            Modo = modo;
            AlumnoInscripcionLogic auxInsc = new AlumnoInscripcionLogic();
            InscripcionActual = auxInsc.GetOne(ID);
            MapearDeDatos(); 
        }


        public override void MapearDeDatos()
        {
            txtID.Text = InscripcionActual.ID.ToString();
            CursoLogic cl = new CursoLogic();
            Curso crs = cl.GetOne(InscripcionActual.IDCurso);
        //    cbCurso.Text = crs.IDString;

            UsuarioLogic ul = new UsuarioLogic();
            Usuario usr = ul.GetOne(InscripcionActual.IDAlumno);
          //  cbAlumno.Text = usr.IDString;

            cbCondicion.Text = InscripcionActual.Condicion.ToString();

            nudNota.Value = InscripcionActual.Nota;


            switch (Modo)
            {
                case ModoForm.Alta:
                    btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Modificacion:
                    btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    btnAceptar.Text = "Eliminar";
                    cbCurso.Enabled = false;
                    cbAlumno.Enabled = false;
                    cbCondicion.Enabled = false;
                    nudNota.Enabled = false;

                    break;
                case ModoForm.Consulta:
                    btnAceptar.Text = "Aceptar";
                    cbCurso.Enabled = false;
                    cbAlumno.Enabled = false;
                    cbCondicion.Enabled = false;
                    nudNota.Enabled = false;
                    break;
            }
        }

        public override void MapearADatos()
        {
            switch (Modo)
            {                                      //Emprolijar: Evitar repetición de asignaciones  
                case ModoForm.Alta:
                    InscripcionActual = new AlumnoInscripcion();
                    InscripcionActual.IDCurso = getCrsID(cbCurso.Text);
                    InscripcionActual.IDAlumno = getUsrID(cbAlumno.Text);
                    InscripcionActual.Nota = (int)nudNota.Value;
                    InscripcionActual.Condicion = (AlumnoInscripcion.Condiciones)System.Enum.Parse(typeof(AlumnoInscripcion.Condiciones), cbCondicion.Text);
                    InscripcionActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    InscripcionActual.IDCurso = getCrsID(cbCurso.Text);
                    InscripcionActual.IDAlumno = getUsrID(cbAlumno.Text);
                    InscripcionActual.Nota = (int)nudNota.Value;
                    InscripcionActual.Condicion = (AlumnoInscripcion.Condiciones)System.Enum.Parse(typeof(AlumnoInscripcion.Condiciones), cbCondicion.Text);
                    break;
                case ModoForm.Baja:
                    InscripcionActual.State = BusinessEntity.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    InscripcionActual.State = BusinessEntity.States.Unmodified;
                    break;
            }
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            AlumnoInscripcionLogic auxInsc = new AlumnoInscripcionLogic();
            auxInsc.Save(InscripcionActual);
        }

        public override bool Validar()
        {
            return !(                                     //Si cualquiera de estas condiciones es verdadera, retorna false
            string.IsNullOrEmpty(cbCurso.Text) ||
            string.IsNullOrEmpty(cbCondicion.Text) ||
            string.IsNullOrEmpty(cbAlumno.Text));
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
                MessageBox.Show("Complete todos los campos.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int getCrsID(string StrID)
        {
            CursoLogic cl = new CursoLogic();
            List<Curso> cursos = cl.GetAll();
            foreach (Curso crs in cursos)
            {
          //      if (crs.IDString == StrID)
            //    {
              //      return crs.ID;
                //}
            }
            return (0);
        }

        private int getUsrID(string StrID)
        {
            UsuarioLogic ul = new UsuarioLogic();
            List<Usuario> usuarios = ul.GetAll();
            foreach (Usuario usr in usuarios)
            {
            //    if (usr.IDString == StrID)
              //  {
                //    return usr.ID;
                //}
            }
            return (0);
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
