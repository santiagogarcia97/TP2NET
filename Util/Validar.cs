using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util {
    public static class Validar {

        private static string[] _formatosFecha = { "d/M/yyyy", "dd/MM/yyyy", "d-M-yyyy", "dd-MM-yyyy", "ddMMyyyy", "dMyyyy" };
        public static string[] FormatosFecha { get => _formatosFecha; set => _formatosFecha = value; }
    }
}
