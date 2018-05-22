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

        public TiposCargos Cargo {
            get => default(int);
            set {
            }
        }

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
    }
}
