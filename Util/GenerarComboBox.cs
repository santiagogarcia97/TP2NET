using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Business.Logic;


namespace Util {
    public class GenerarComboBox {
        /*
         *  Se devuelven los DataTable para generar los combobox
         *  Cada uno consiste en una columna de id que es el valor que se usara de forma interna
         *  y una columna Descripcion que corresponde al valor que se le mostrará al usuario
         *  A Planes, Materias y Comisiones se les agrega un filtro con la id que les llega como argumento
         * 
         */
     
        
        public static DataTable getEspecialidades() {
            DataTable dtEspecialidades = new DataTable();
            dtEspecialidades.Columns.Add("id_esp", typeof(int));
            dtEspecialidades.Columns.Add("desc_esp", typeof(string));
            EspecialidadLogic el = new EspecialidadLogic();
            List<Especialidad> especialidades = el.GetAll();
            dtEspecialidades.Rows.Add(new object[] { 0, string.Empty });
            foreach (Especialidad esp in especialidades) {
                if (esp.Habilitado) {
                    dtEspecialidades.Rows.Add(new object[] { esp.ID, esp.Descripcion });
                }
            }
            return dtEspecialidades;
        }
        public static DataTable getPlanes(int idEsp) {
            DataTable dtPlanes = new DataTable();
            dtPlanes.Columns.Add("id_plan", typeof(int));
            dtPlanes.Columns.Add("desc_plan", typeof(string));
            PlanLogic pl = new PlanLogic();
            List<Plan> planes = pl.GetAll();
            dtPlanes.Rows.Add(new object[] { 0, string.Empty });
            foreach (Plan plan in planes) {
                if (plan.IDEspecialidad == idEsp && plan.Habilitado) {
                    dtPlanes.Rows.Add(new object[] { plan.ID, plan.Descripcion });
                }
            }
            return dtPlanes;
        } 
        public static DataTable getTiposPersona() {
            DataTable dtTiposPersona = new DataTable();

            dtTiposPersona.Columns.Add("tipo_persona", typeof(int));
            dtTiposPersona.Columns.Add("desc_tipo", typeof(string));
            dtTiposPersona.Rows.Add(new object[] { 0, string.Empty });
            dtTiposPersona.Rows.Add(new object[] { 1, "Alumno" });
            dtTiposPersona.Rows.Add(new object[] { 2, "Docente" });
            dtTiposPersona.Rows.Add(new object[] { 3, "Administrativo" });

            return dtTiposPersona;
        }
        public static DataTable getMaterias(int idPlan) {
            DataTable dtMaterias = new DataTable();
            dtMaterias.Columns.Add("id_mat", typeof(int));
            dtMaterias.Columns.Add("desc_mat", typeof(string));
            MateriaLogic ml = new MateriaLogic();
            List<Materia> materias = ml.GetAll();
            dtMaterias.Rows.Add(new object[] { 0, string.Empty });
            foreach (Materia materia in materias) {
                if (materia.IDPlan == idPlan && materia.Habilitado) {
                    dtMaterias.Rows.Add(new object[] { materia.ID, materia.Descripcion });
                }
            }
            return dtMaterias;
        }
        public static DataTable getComisiones(int idPlan) {
            DataTable dtComisiones = new DataTable();
            dtComisiones.Columns.Add("id_com", typeof(int));
            dtComisiones.Columns.Add("desc_com", typeof(string));
            ComisionLogic cl = new ComisionLogic();
            List<Comision> comisiones = cl.GetAll();
            dtComisiones.Rows.Add(new object[] { 0, string.Empty });
            foreach (Comision com in comisiones) {
                if (com.IDPlan == idPlan && com.Habilitado) {
                    dtComisiones.Rows.Add(new object[] { com.ID, com.Descripcion });
                }
            }
            return dtComisiones;
        }
        public static DataTable getCondiciones() {
            DataTable dtCondiciones = new DataTable();
            dtCondiciones.Columns.Add("id_cond", typeof(int));
            dtCondiciones.Columns.Add("desc_cond", typeof(string));
            dtCondiciones.Rows.Add(new object[] { 4, string.Empty });

            dtCondiciones.Rows.Add(new object[] { 0, "Regular" });
            dtCondiciones.Rows.Add(new object[] { 1, "Aprobado" });
            dtCondiciones.Rows.Add(new object[] { 2, "Cursando" });
            dtCondiciones.Rows.Add(new object[] { 3, "Libre" });

            return dtCondiciones;
        }

    }
}
