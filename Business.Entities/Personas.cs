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
    //    private TiposPersonas _TipoPersona;

        public string Apellido {
            get => default(string);
            set {
            }
        }

        public string Direccion {
            get => default(string);
            set {
            }
        }

        public string Email {
            get => default(string);
            set {
            }
        }

        public DateTime FechaNacimiento {
            get => default(DateTime);
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
            get => default(string);
            set {
            }
        }

        public string Telefono {
            get => default(string);
            set {
            }
        }

      //  public TiposPersonas TipoPersona {
        //    get => default(int);
          //  set {
            //}
        //}
    }
}
