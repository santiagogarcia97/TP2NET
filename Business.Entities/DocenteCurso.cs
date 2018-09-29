using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities {
    public class DocenteCurso : BusinessEntity {
        private TipoCargos _Cargo;
        private int _IDCurso, _IDDocente;

        public enum TipoCargos { Titular = 0,
                                 Auxiliar = 1,
                                 JefeTP = 2 }


        public TipoCargos Cargo { get => _Cargo; set => _Cargo = value; }
        public int IDCurso { get => _IDCurso; set => _IDCurso = value; }
        public int IDDocente { get => _IDDocente; set => _IDDocente = value; }
    }
}
