using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic {
    public class ComisionLogic {
        private ComisionAdapter _ComisionData;
        public ComisionAdapter ComisionData { get => _ComisionData; set => _ComisionData = value; }

        public ComisionLogic() {
            ComisionData = new ComisionAdapter();
        }

        public List<Comision> GetAll() {
            return ComisionData.GetAll();
        }

        public Comision GetOne(int id) {
            return ComisionData.GetOne(id);
        }

        public void Delete(int id) {
            ComisionData.Delete(id);
        }

        public void Save(Comision com) {
            ComisionData.Save(com);
        }



    }
}
