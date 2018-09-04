using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities {

    // esta entidad facilita el listado de cursos e inscripciones
    // se carga con un join entre las tablas cursos, comisiones y materias de la DB
    public class CursoMatCom : BusinessEntity {
        private int _IDMateria, _IDComision, _IDPlan;
        private string _DescMateria, _DescComision;

        public int IDMateria { get => _IDMateria; set => _IDMateria = value; }
        public int IDComision { get => _IDComision; set => _IDComision = value; }
        public int IDPlan { get => _IDPlan; set => _IDPlan = value; }
        public string DescMateria { get => _DescMateria; set => _DescMateria = value; }
        public string DescComision { get => _DescComision; set => _DescComision = value; }
    }
}
