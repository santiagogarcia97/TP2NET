using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities {
    class Materia : BusinessEntity {
        private string _Descripcion;
        private int _HSSemanales;
        private int _HSTotales;
        private int _IDPlan;

        public string Descripcion {
            get => default(string);
            set {
            }
        }

        public int HSSemanales {
            get => default(int);
            set {
            }
        }

        public int HSTotales {
            get => default(int);
            set {
            }
        }

        public int IDPlan {
            get => default(int);
            set {
            }
        }
    }
}
