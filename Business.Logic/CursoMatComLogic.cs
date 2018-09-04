using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic {
    public class CursoMatComLogic : BusinessLogic {
        private CursoMatComAdapter _CursoMatComData;
        public CursoMatComAdapter CursoMatComData { get => _CursoMatComData; set => _CursoMatComData = value; }

        public CursoMatComLogic() {
            CursoMatComData = new CursoMatComAdapter();
        }
        public List<CursoMatCom> GetAll() {
            return CursoMatComData.GetAll();
        }
    }
}
