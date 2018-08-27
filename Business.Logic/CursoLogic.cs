using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic {
    public class CursoLogic : BusinessLogic {
        private CursoAdapter _CursoData;

        public CursoAdapter CursoData {
            get { return _CursoData; }
            set { _CursoData = value; }
        }

        public CursoLogic() {
            CursoData = new CursoAdapter();
        }

        public List<Curso> GetAll() {
            return CursoData.GetAll();

        }

        public Curso GetOne(int id) {
            return CursoData.GetOne(id);
        }

        public void Delete(int id) {
            CursoData.Delete(id);
        }

        public void Save(Curso crs) {
            CursoData.Save(crs);
        }
    }
}
