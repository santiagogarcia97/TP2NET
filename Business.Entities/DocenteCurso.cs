using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities {
    class DocenteCurso : BusinessEntity {
        private TipoCargos _Cargo;
        private int _IDCurso;
        private int _IDDocente;

        public enum TipoCargos { Titular, Auxiliar, JefeTP}

        public int IDCurso {
            get => default(int);
            set {
            }
        }

        public int IDDocente {
            get => default(int);
            set {
            }
        }

        public TipoCargos Cargo { get => _Cargo; set => _Cargo = value; }
    }
}
