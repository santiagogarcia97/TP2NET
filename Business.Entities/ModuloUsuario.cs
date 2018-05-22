﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities {
    public class ModuloUsuario : BusinessEntity {
        int _IDUsuario;
        int _IDModulo;
        bool _PermiteAlta;
        bool _PermiteBaja;
        bool _PermiteModificacion;
        bool _PermiteConsulta;
        public int IdUsuario {
            get { return (_IDUsuario); }
            set { _IDUsuario = value; }
        }

        public int IdModulo {
            get { return (_IDModulo); }
            set { _IDModulo = value; }
        }

        public bool PermiteAlta {
            get { return (_PermiteAlta); }
            set { _PermiteAlta = value; }
        }

        public bool PermiteBaja {
            get { return (_PermiteBaja); }
            set { _PermiteBaja = value; }
        }

        public bool PermiteModificacion {
            get { return (_PermiteModificacion); }
            set { _PermiteModificacion = value; }
        }

        public bool PermiteConsulta {
            get { return (_PermiteConsulta); }
            set { _PermiteConsulta = value; }
        }
    }
}
