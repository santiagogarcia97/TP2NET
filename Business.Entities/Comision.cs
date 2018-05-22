using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class Comision : BusinessEntity
    {
        private int _AnioEspecialidad;
        private String _Descripcion;
        private int _IDPlan;

        public int AnioEspecialidad
        {
            get => default(int);
            set
            {
            }
        }

        public string Descripcion
        {
            get => default(int);
            set
            {
            }
        }

        public int IDPlan
        {
            get => default(int);
            set
            {
            }
        }
    }
}