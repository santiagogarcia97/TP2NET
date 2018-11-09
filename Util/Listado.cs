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
        private static EspecialidadLogic EspLogic { get { if (_EspLogic == null) _EspLogic = new EspecialidadLogic(); return EspLogic; } }
        private static PlanLogic PlanLogic { get { if (_PlanLogic == null) _PlanLogic = new PlanLogic(); return PlanLogic; } }
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
















    }
}
