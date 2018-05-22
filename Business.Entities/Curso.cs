using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities {
    class Curso : BusinessEntity {
        private int _AnioCalendario;
        private int _Cupo;
        private string _Descripcion;
        private int _IDComision;
        private int _IDMateria;

        public int AnioCalendario {
            get => default(int);
            set {
            }
        }

        public int Cupo {
            get => default(int);
            set {
            }
        }

        public string Descripcion {
            get => default(int);
            set {
            }
        }

        public int IDComision {
            get => default(int);
            set {
            }
        }

        public int IDMateria {
            get => default(int);
            set {
            }
        }
    }
}
