using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class BusinessEntity
    {

        public enum States { Deleted, New, Modified, Unmodified }

        private int _ID;
        private States _State;
        private bool _Habilitado;

        public int ID { get => _ID; set => _ID = value; }
        public States State { get => _State; set => _State = value; }
        public bool Habilitado { get => _Habilitado; set => _Habilitado = value; }
    }
}
