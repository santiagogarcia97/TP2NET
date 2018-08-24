using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities {
    public class Usuario : BusinessEntity {
        private string _Nombre,_Apellido,_Direccion,_Email,_Telefono,_NombreUsuario,_Clave;
        private DateTime _FechaNacimiento;
        private bool _Habilitado,_CambiaClave;
        private int _Legajo,_TipoPersona,_IDPlan;

        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellido { get => _Apellido; set => _Apellido = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string NombreUsuario { get => _NombreUsuario; set => _NombreUsuario = value; }
        public string Clave { get => _Clave; set => _Clave = value; }
        public DateTime FechaNacimiento { get => _FechaNacimiento; set => _FechaNacimiento = value; }
        public bool Habilitado { get => _Habilitado; set => _Habilitado = value; }
        public bool CambiaClave { get => _CambiaClave; set => _CambiaClave = value; }
        public int Legajo { get => _Legajo; set => _Legajo = value; }
        public int TipoPersona { get => _TipoPersona; set => _TipoPersona = value; }
        public int IDPlan { get => _IDPlan; set => _IDPlan = value; }
    }

}
