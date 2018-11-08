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
    public partial class inscribir_cursos : System.Web.UI.Page {
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
            UsuarioLogic ul = new UsuarioLogic();
            UsuarioActual = ul.GetOne(Session["username"].ToString());
            Listar();
        }

        private void Listar() {

            CursoLogic cl = new CursoLogic();
            List<Curso> cursos = cl.GetAll();

            //Se crea el DataTable que va a ser el DataSource del dgv
            DataTable Listado = new DataTable();
            Listado.Columns.Add("ID", typeof(int));
            Listado.Columns.Add("AnioCalendario", typeof(int));
            Listado.Columns.Add("Cupo", typeof(string));
            Listado.Columns.Add("Curso", typeof(string));

            MateriaLogic ml = new MateriaLogic();
            List<Materia> materias = ml.GetAll();
            ComisionLogic coml = new ComisionLogic();
            List<Comision> comisiones = coml.GetAll();

            //Cargo las materias en la que ya esta inscripto en una nueva lista
            AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
            List<AlumnoInscripcion> inscripciones = ail.GetAllFromUser(UsuarioActual.ID);
            List<Materia> matInscripto = new List<Materia>();
            foreach (AlumnoInscripcion ai in inscripciones) {
                Curso cur = cursos.First(x => x.ID == ai.IDCurso);
                Materia mat = materias.First(x => x.ID == cur.IDMateria);
                matInscripto.Add(mat);
            }

            foreach (Curso cur in cursos) {

                // Valido que no este inscripto a la materia
                Materia mat = materias.FirstOrDefault(x => x.ID == cur.IDMateria);
                if (!matInscripto.Exists(x => x.ID == mat.ID)) {

                    //Solo se muestran los cursos correspondientes al mismo plan del usuario
                    if (mat.IDPlan == UsuarioActual.IDPlan) {

                        DataRow Linea = Listado.NewRow();

                        Linea["ID"] = cur.ID;
                        Linea["AnioCalendario"] = cur.AnioCalendario.ToString();
                        Linea["Cupo"] = ail.GetCantCupo(cur.ID) + "/" + cur.Cupo;

                        Comision com = comisiones.FirstOrDefault(x => x.ID == cur.IDComision);
                        Linea["Curso"] = com.Descripcion + " - " + mat.Descripcion;
                        Listado.Rows.Add(Linea);
                    }
                }
            }
            gvCursos.DataSource = Listado;
            gvCursos.DataBind();

        }
        private void ButtonState() {

            if (SelectedID == 0) {
                btnInscribir.CssClass = "btn btn-outline-secondary btn-sm";
                btnInscribir.Enabled = false;
                btnDeseleccionar.Visible = false;
            }
            else {
                btnInscribir.CssClass = "btn btn-outline-success btn-sm";
                btnInscribir.Enabled = true;
                btnDeseleccionar.Visible = true;
            }
            UpdatePanelButtons.Update();
        }
        protected void gvCursos_SelectedIndexChanged(object sender, EventArgs e) {
            SelectedID = (gvCursos.SelectedValue != null) ? (int)gvCursos.SelectedValue : 0;
            ButtonState();
        }

        protected void btnInscribir_Click(object sender, EventArgs e) {

            AlumnoInscripcion InscripcionActual = new AlumnoInscripcion();
            InscripcionActual.IDCurso = SelectedID;
            InscripcionActual.IDAlumno = UsuarioActual.ID;
            InscripcionActual.Condicion = AlumnoInscripcion.Condiciones.Cursando;
            InscripcionActual.Habilitado = true;
            InscripcionActual.Nota = 0;
            InscripcionActual.State = BusinessEntity.States.New;

            AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
            ail.Save(InscripcionActual);

        }
    }
    
}