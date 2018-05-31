using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Logic;
using Business.Entities;

namespace UI.Consola {
    public class Usuario {
        UsuarioLogic _UsuarioNegocio;
        public UsuarioLogic UsuarioNegocio {
            get { return _UsuarioNegocio; }
            set { _UsuarioNegocio = value; }
        }
        public Usuario() {
            UsuarioNegocio = new UsuarioLogic();
        }
        public void Menu() {

            //Mostrar listado de menu principal 4.6
            Console.WriteLine("Menu principal\n1- Listado General\n2- Consulta");
        }
        public void ListadoGeneral() {
            Console.Clear();
            foreach(Business.Entities.Usuario usr in UsuarioNegocio.GetAll()) {
                MostrarDatos(usr);
            }

        }
        public void Consultar() {

        }
        public void Agregar() {

        }
        public void Modificar() {

        }
        public void Eliminar() {

        }
        public void MostrarDatos(Business.Entities.Usuario usr) {
            //Mostrar datos, paso 4.8
            Console.WriteLine("Usuario: {0}", usr.ID);
        }
    }
}
