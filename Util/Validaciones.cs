using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Business.Entities;
using Business.Logic;
using System.Globalization;

namespace Util {
    public static class Validaciones {

        private const string RegExEmail = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
        private const string RegExTel = @"/\(?([0-9]{3})\)?([ .-]?)([0-9]{3})\2([0-9]{4})/";
        private const string RegExUsername = @"^[a-zA-Z0-9]{3,15}$";

        private static string[] _formatosFecha = { "d/M/yyyy", "dd/MM/yyyy", "d-M-yyyy", "dd-MM-yyyy", "ddMMyyyy", "dMyyyy" };
        public static string[] FormatosFecha { get => _formatosFecha; set => _formatosFecha = value; }

        public static bool ValTexto(string desc) {
            bool valid = true;

            valid = (string.IsNullOrEmpty(desc)) ? false : true;
            valid = (string.IsNullOrWhiteSpace(desc)) ? false : true;

            return valid;
        }
        public static bool ValAnio(int anio) {
            if (anio > 1900 && anio < 3000) return true;
            else return false;
        }
        public static bool ValHSSem(int hr) {
            if (hr >= 1 && hr <= 40) return true;
            else return false;
        }
        public static bool ValHSTot(int hr) {
            if (hr >= 1 && hr <= 300) return true;
            else return false;
        }
        public static bool ValCupo(int cupo) {
            if (cupo >= 1 && cupo <= 200) return true;
            else return false;
        }
        public static bool ValCargo(int cargo) {
            return Enum.IsDefined(typeof(DocenteCurso.TipoCargos), cargo);
        }
        public static bool ValCondicion(int cond) {
            return Enum.IsDefined(typeof(AlumnoInscripcion.Condiciones), cond);
        }
        public static bool ValNota(int nota) {
            if (nota >= 0 && nota <= 10) return true;
            else return false;
        }
        public static bool ValEmail(string email) {
            return Regex.Match(email, RegExEmail).Success;
        }
        public static bool ValTel(string tel) {
            return Regex.Match(tel, RegExTel).Success;
        }
        public static bool ValFecha(string fecha) {
            DateTime dt;
            return DateTime.TryParseExact(fecha, FormatosFecha, null, DateTimeStyles.None, out dt);
        }
        public static bool ValTipo(int tipo) {
            return Enum.IsDefined(typeof(Usuario.TiposPersona), tipo);
        }
        public static bool ValUsername(string username) {
            return Regex.Match(username, RegExUsername).Success; 
        }
        public static bool ValUsernameExists(string username) {
            UsuarioLogic ul = new UsuarioLogic();
            Usuario user = ul.GetOne(username);

            return (user.ID != 0) ? true : false;
        }
        public static bool ValClave(string clave) {
            return (clave.Length >= 3 && clave.Length <= 32) ? true : false;
        }
    }
}
