using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities {
    class Personas : BusinessEntity {
        private string _Apellido;
        private string _Direccion;
        private string _Email;
        private DateTime _FechaNacimiento;
        private int _IDPlan;
        private int _Legajo;
        private string _Nombre;
        private string _Telefono;
        private TiposPersonas _TipoPersona;

        public string Apellido {
            get => default(int);
            set {
            }
        }

        public string Direccion {
            get => default(int);
            set {
            }
        }

        public string Email {
            get => default(int);
            set {
            }
        }

        public DateTime FechaNacimiento {
            get => default(int);
            set {
            }
        }

        public int IDPlan {
            get => default(int);
            set {
            }
        }

        public int Legajo {
            get => default(int);
            set {
            }
        }

        public string Nombre {
            get => default(int);
            set {
            }
        }

        public string Telefono {
            get => default(int);
            set {
            }
        }

        public TiposPersonas TipoPersona {
            get => default(int);
            set {
            }
        }
    }
}
