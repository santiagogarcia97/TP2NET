using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Business.Logic;
using System.Data;

namespace Util {
    public static class Listado {
        private static UsuarioLogic _UserLogic;
        private static EspecialidadLogic _EspLogic;
        private static PlanLogic _PlanLogic;
        private static MateriaLogic _MatLogic;
        private static ComisionLogic _ComLogic;
        private static CursoLogic _CursoLogic;
        private static AlumnoInscripcionLogic _AILogic;
        private static DocenteCursoLogic _DCLogic;

        private static UsuarioLogic UserLogic { get { if (_UserLogic == null) _UserLogic = new UsuarioLogic(); return _UserLogic; } }
        private static EspecialidadLogic EspLogic { get { if (_EspLogic == null) _EspLogic = new EspecialidadLogic(); return _EspLogic; } }
        private static PlanLogic PlanLogic { get { if (_PlanLogic == null) _PlanLogic = new PlanLogic(); return _PlanLogic; } }
        private static MateriaLogic MatLogic { get { if (_MatLogic == null) _MatLogic = new MateriaLogic(); return _MatLogic; } }
        private static ComisionLogic ComLogic { get { if (_ComLogic == null) _ComLogic = new ComisionLogic(); return _ComLogic; } }
        private static CursoLogic CursoLogic { get { if (_CursoLogic == null) _CursoLogic = new CursoLogic(); return _CursoLogic; } }
        private static AlumnoInscripcionLogic AILogic { get { if (_AILogic == null) _AILogic = new AlumnoInscripcionLogic(); return _AILogic; } }
        private static DocenteCursoLogic DCLogic { get { if (_DCLogic == null) _DCLogic = new DocenteCursoLogic(); return _DCLogic; } }


        public static DataTable Generar(List<AlumnoInscripcion> inscripciones) {

            DataTable Listado = new DataTable();
            Listado.Columns.Add("ID", typeof(int));
            Listado.Columns.Add("Alumno", typeof(string));
            Listado.Columns.Add("Curso", typeof(string));
            Listado.Columns.Add("Nota", typeof(string));
            Listado.Columns.Add("Condicion", typeof(string));

            UsuarioLogic ul = new UsuarioLogic();
            List<Usuario> usuarios = ul.GetAll();
            CursoLogic curl = new CursoLogic();
            List<Curso> cursos = curl.GetAll();
            MateriaLogic matl = new MateriaLogic();
            List<Materia> materias = matl.GetAll();
            ComisionLogic coml = new ComisionLogic();
            List<Comision> comisiones = coml.GetAll();

            foreach (AlumnoInscripcion ai in inscripciones) {
                DataRow Linea = Listado.NewRow();

                Linea["ID"] = ai.ID;
                Linea["Nota"] = (ai.Nota == 0) ? "-" : ai.Nota.ToString();
                Linea["Condicion"] = ai.Condicion.ToString();

                Usuario user = usuarios.FirstOrDefault(x => x.ID == ai.IDAlumno);
                Linea["Alumno"] = user.Legajo + " - " + user.Apellido + ", " + user.Nombre;

                Curso curso = cursos.FirstOrDefault(x => x.ID == ai.IDCurso);
                Materia materia = materias.FirstOrDefault(x => x.ID == curso.IDMateria);
                Comision comision = comisiones.FirstOrDefault(x => x.ID == curso.IDComision);
                Linea["Curso"] = comision.Descripcion + " - " + materia.Descripcion;

                Listado.Rows.Add(Linea);
            }
            return Listado;
        }
        public static DataTable Generar(List<Curso> cursos) {

            DataTable Listado = new DataTable();
            Listado.Columns.Add("ID", typeof(int));
            Listado.Columns.Add("AnioCalendario", typeof(int));
            Listado.Columns.Add("Cupo", typeof(string));
            Listado.Columns.Add("Curso", typeof(string));
            Listado.Columns.Add("Materia", typeof(string));
            Listado.Columns.Add("Comision", typeof(string));
            Listado.Columns.Add("Plan", typeof(string));

            List<Especialidad> especialidades = EspLogic.GetAll();
            List<Plan> planes = PlanLogic.GetAll();
            List<Materia> materias = MatLogic.GetAll();
            List<Comision> comisiones = ComLogic.GetAll();

            foreach (Curso cur in cursos) {
                DataRow Linea = Listado.NewRow();

                Linea["ID"] = cur.ID;
                Linea["AnioCalendario"] = cur.AnioCalendario;
                Linea["Cupo"] = AILogic.GetCantCupo(cur.ID) + "/" + cur.Cupo;
                Comision com = comisiones.FirstOrDefault(x => x.ID == cur.IDComision);
                Linea["Comision"] = com.Descripcion;
                Materia materia = materias.FirstOrDefault(x => x.ID == cur.IDMateria);
                Linea["Materia"] = materia.Descripcion;
                Plan plan = planes.FirstOrDefault(x => x.ID == materia.IDPlan);
                Especialidad esp = especialidades.FirstOrDefault(x => x.ID == plan.IDEspecialidad);
                Linea["Plan"] = esp.Descripcion + " - " + plan.Descripcion;
                Linea["Curso"] = com.Descripcion + " - " + materia.Descripcion;

                Listado.Rows.Add(Linea);
            }

            return Listado;
        }

        public static DataTable Generar(List<Usuario> users)
        {

            DataTable Listado = new DataTable();
            Listado.Columns.Add("ID", typeof(int));
            Listado.Columns.Add("NombreUsuario", typeof(string));
            Listado.Columns.Add("Nombre", typeof(string));
            Listado.Columns.Add("Apellido", typeof(string));
            Listado.Columns.Add("Email", typeof(string));
            Listado.Columns.Add("Direccion", typeof(string));
            Listado.Columns.Add("Telefono", typeof(string));
            Listado.Columns.Add("FechaNac", typeof(string));
            Listado.Columns.Add("Legajo", typeof(int));
            Listado.Columns.Add("Tipo", typeof(string));
            Listado.Columns.Add("Plan", typeof(string));

            foreach (Usuario user in users) {
                DataRow Linea = Listado.NewRow();

                Linea["ID"] = user.ID;
                Linea["NombreUsuario"] = user.NombreUsuario;
                Linea["Nombre"] = user.Nombre;
                Linea["Apellido"] = user.Apellido;
                Linea["Email"] = user.Email;
                Linea["Direccion"] = user.Direccion;
                Linea["Telefono"] = user.Telefono;
                Linea["FechaNac"] = user.FechaNacimiento.ToString("dd/MM/yyyy");
                Linea["Legajo"] = user.Legajo;
                Linea["Tipo"] = user.TipoPersona.ToString();

                Plan plan = PlanLogic.GetOne(user.IDPlan);
                Especialidad esp = EspLogic.GetOne(plan.IDEspecialidad);
                Linea["Plan"] = esp.Descripcion + " - " + plan.Descripcion;

                Listado.Rows.Add(Linea);
            }
                        
            return Listado;
        }













    }
}
