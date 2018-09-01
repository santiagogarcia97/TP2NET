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
        public static DataTable getEspecialidades() {
            DataTable dtEspecialidades = new DataTable();
            dtEspecialidades.Columns.Add("id_esp", typeof(int));
            dtEspecialidades.Columns.Add("desc_esp", typeof(string));
            EspecialidadLogic el = new EspecialidadLogic();
            List<Especialidad> especialidades = el.GetAll();
            foreach (Especialidad esp in especialidades) {
                dtEspecialidades.Rows.Add(new object[] { esp.ID, esp.Descripcion });
            }
            return dtEspecialidades;
        }
    }
}
