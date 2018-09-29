using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic {
    public class DocenteCursoLogic : BusinessLogic {

        private DocenteCursoAdapter _DocenteCursoData;
        public DocenteCursoAdapter DocenteCursoData { get => _DocenteCursoData; set => _DocenteCursoData = value; }

        public DocenteCursoLogic() {
            DocenteCursoData = new DocenteCursoAdapter();
        }

        public List<DocenteCurso> GetAll() {
            return DocenteCursoData.GetAll();
        }
        public List<DocenteCurso> GetAllFromUser(int id) {
            return DocenteCursoData.GetAllFromUser(id);
        }

        public DocenteCurso GetOne(int id) {
            return DocenteCursoData.GetOne(id);
        }

        public void Save(DocenteCurso dc) {
            DocenteCursoData.Save(dc);
        }
    }
}
