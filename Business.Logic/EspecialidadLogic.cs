using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;
using System.Data;

namespace Business.Logic {
    public class EspecialidadLogic : BusinessLogic {

        private EspecialidadAdapter _EspecialidadData;
        public EspecialidadAdapter EspecialidadData { get => _EspecialidadData; set => _EspecialidadData = value; }

        public EspecialidadLogic() {
            EspecialidadData = new EspecialidadAdapter();
        }

        public List<Especialidad> GetAll() {
            return EspecialidadData.GetAll();
        }

        public Especialidad GetOne(int id) {
            return EspecialidadData.GetOne(id);
        }


        public void Save(Especialidad esp) {
            EspecialidadData.Save(esp);
        }

        public DataTable GetListado() {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Descripcion", typeof(string));

            List<Especialidad> especialidades = EspecialidadData.GetAll();

            foreach (Especialidad esp in especialidades) {
                dt.Rows.Add(new object[] { esp.ID, esp.Descripcion });
            }
            return dt;
        }
    }
}
