using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class Plan : BusinessEntity
    {
        private String _Descripcion;
        private int _IDEspecialidad;
        private string _IDString;

        public string Descripcion {
            get { return (_Descripcion); }
            set { _Descripcion = value; }
        }

        public int IDEspecialidad
        {
            get { return (_IDEspecialidad); }
            set { _IDEspecialidad = value; }
        }

        public string IDString {
            get { return _IDString; }
            set { _IDString = value; }
        }

    }
}