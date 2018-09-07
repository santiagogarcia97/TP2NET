using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic {
    public class MateriaLogic : BusinessLogic {
        private MateriaAdapter _MateriaData;

        public MateriaAdapter MateriaData {
            get { return _MateriaData; }
            set { _MateriaData = value; }
        }

        public MateriaLogic() {
            MateriaData = new MateriaAdapter();
        }

        public List<Materia> GetAll() {
            return MateriaData.GetAll();

        }

        public Materia GetOne(int id) {
            return MateriaData.GetOne(id);
        }

        public void Save(Materia mat) {
            MateriaData.Save(mat);
        }
    }
}
