using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using Util;
using System.Data;


namespace UI.Web {
    public partial class inscribirCursos : System.Web.UI.Page {

        private Usuario _UsuarioActual;
        private int SelectedID {
            get {
                if (ViewState["SelectedID"] != null) return (int)ViewState["SelectedID"];
                else return 0;
            }
            set {
                ViewState["SelectedID"] = value;
            }
        }

        public Usuario UsuarioActual { get => _UsuarioActual; set => _UsuarioActual = value; }

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                SelectedID = 0;
                UsuarioLogic ul = new UsuarioLogic();
                UsuarioActual = ul.GetOne(Session["username"].ToString());
                lblEstado.Text = "Cursos habilitados para " + UsuarioActual.Apellido + ", " + UsuarioActual.Nombre + " al día " + DateTime.Now.ToString();
                Listar();
            }
        }

        private void Listar() {

            CursoLogic cl = new CursoLogic();
            List<Curso> cursos = cl.GetAll();

            MateriaLogic ml = new MateriaLogic();
            List<Materia> materias = ml.GetAll();
            ComisionLogic coml = new ComisionLogic();
            List<Comision> comisiones = coml.GetAll();

            //Cargo las materias en la que ya esta inscripto en una nueva lista
            AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
            List<AlumnoInscripcion> inscripciones = ail.GetAllFromUser(UsuarioActual.ID); //Obtengo todas las insc del alumno
            List<Materia> matInscripto = new List<Materia>();

            foreach (AlumnoInscripcion ai in inscripciones) {
                Curso cur = cursos.First(x => x.ID == ai.IDCurso);
                Materia mat = materias.First(x => x.ID == cur.IDMateria);
                if(ai.Condicion != AlumnoInscripcion.Condiciones.Libre) matInscripto.Add(mat);// Creo una list con las materias a las que se puede inscribir, sin contar las inscripciones "libres"
            }

            List<Curso> cursosHabilitado = new List<Curso>(); //creo la lista de cursos que se van a mostrar

            foreach (Curso cur in cursos) {
                // Valido que no este inscripto a la materia
                Materia mat = materias.FirstOrDefault(x => x.ID == cur.IDMateria);
                if (!matInscripto.Exists(x => x.ID == mat.ID) &&    //Para poder inscribirme a un curso no puedo estar inscripto a otro de la misma materia a menos que esté "libre"
                    !inscripciones.Exists(x => x.IDCurso == cur.ID && x.Condicion == AlumnoInscripcion.Condiciones.Libre)) {//Si estoy libre no puedo inscribirme a ese mismo curso

                    //Solo se muestran los cursos correspondientes al mismo plan del usuario
                    if (mat.IDPlan == UsuarioActual.IDPlan) {
                        if(cur.Cupo > ail.GetCantCupo(cur.ID))
                            cursosHabilitado.Add(cur);
                    }
                }
            }

            cursos = null; materias = null; comisiones = null; //para liberar memoria

            if(cursosHabilitado.Count == 0) {
                divSinCursos.Visible = true;
            }
            else {
                gvCursos.DataSource = Listado.Generar(cursosHabilitado); // paso la lista de cursos para que me devuelva el datatable 
                gvCursos.DataBind();
            }

        }

        protected void gvCursos_SelectedIndexChanged(object sender, EventArgs e) {
            SelectedID = (gvCursos.SelectedValue != null) ? (int)gvCursos.SelectedValue : 0;
            
            lblCurso.Text = gvCursos.SelectedRow.Cells[2].Text;
            UpdatePanelModal.Update();
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#ModalConfirm').modal('show');", true);
        }

        protected void btnAceptar_Click(object sender, EventArgs e) {
            UsuarioLogic ul = new UsuarioLogic();
            UsuarioActual = ul.GetOne(Session["username"].ToString());
            AlumnoInscripcion InscripcionActual = new AlumnoInscripcion();
            InscripcionActual.IDCurso = SelectedID;
            InscripcionActual.IDAlumno = UsuarioActual.ID;
            InscripcionActual.Condicion = AlumnoInscripcion.Condiciones.Cursando;
            InscripcionActual.Habilitado = true;
            InscripcionActual.Nota = 0;
            InscripcionActual.State = BusinessEntity.States.New;

            AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
            ail.Save(InscripcionActual);
            Response.Redirect(Request.RawUrl);
        }
    }
    
}