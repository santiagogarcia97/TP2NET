using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

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
    }
}
