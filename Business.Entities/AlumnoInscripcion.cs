using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities {
    class AlumnoInscripcion : BusinessEntity {
        private string _Condicion;
        private int _IDAlumno;
        private int _IDCurso;
        private int _Nota;

        public string Condicion {
            get => default(string);
            set {
            }
        }

        public int IDAlumno {
            get => default(int);
            set {
            }
        }

        public int IDCurso {
            get => default(int);
            set {
            }
        }

        public int Nota {
            get => default(int);
            set {
            }
        }
    }
}
