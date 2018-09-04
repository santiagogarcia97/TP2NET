﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class Comision : BusinessEntity
    {
        private int _AnioEspecialidad,_IDPlan;
        private String _Descripcion;

        public int AnioEspecialidad { get => _AnioEspecialidad; set => _AnioEspecialidad = value; }
        public int IDPlan { get => _IDPlan; set => _IDPlan = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
    }
}