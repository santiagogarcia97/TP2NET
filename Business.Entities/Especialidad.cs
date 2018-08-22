using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class Especialidad : BusinessEntity {
        private string _Descripcion;
        private string _IDString;

        public string Descripcion {
            get { return (_Descripcion); }
            set { _Descripcion = value; }
        }

        public string IDString {        //String para usar en dropdown
            get { return _IDString; }
            set { _IDString = value; }
        }
    }
}