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
            Console.WriteLine("Menu principal\n1- Listado General\n2- Consulta\n3- Agregar\n4- Modificar\n5- Eliminar\n6- Salir");

            ConsoleKeyInfo op = Console.ReadKey();
            switch (op.Key) {
                case ConsoleKey.D1: {
                        this.ListadoGeneral();
                        break;
                    }
                case ConsoleKey.D2: {
                        this.Consultar();
                        break;
                    }
                case ConsoleKey.D3: {
                        this.Agregar();
                        break;
                    }
                case ConsoleKey.D4: {
                        this.Modificar();
                        break;
                    }
                case ConsoleKey.D5: {
                        this.Eliminar();
                        break;
                    }
            }
            Console.ReadKey();
        }
        public void ListadoGeneral() {
            Console.Clear();
            foreach (Business.Entities.Usuario usr in UsuarioNegocio.GetAll()) {
                MostrarDatos(usr);
            }

        }
        public void Consultar() {
            try {
                Console.Clear();
                Console.Write("Ingrese el ID del usuario a consultar: ");
                int id = int.Parse(Console.ReadLine());
                this.MostrarDatos(UsuarioNegocio.GetOne(id));
            }
            catch (FormatException fe) {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un número entero");
            }
            catch (Exception e) {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally {
                Console.WriteLine();
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
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
            Console.WriteLine("\t\tNombre: {0}", usr.Nombre);
            Console.WriteLine("\t\tApellido: {0}", usr.Apellido);
            Console.WriteLine("\t\tNombre de Usuario: {0}", usr.NombreUsuario);
            Console.WriteLine("\t\tClave: {0}", usr.Clave);
            Console.WriteLine("\t\tEmail: {0}", usr.Email);
            Console.WriteLine("\t\tHabilitado: {0}", usr.Habilitado);

            Console.WriteLine();
        }
    }
}
