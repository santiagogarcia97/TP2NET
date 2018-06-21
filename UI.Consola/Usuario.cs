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
            while (true) {
                //Mostrar listado de menu principal 4.6
                Console.Clear();
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
                    case ConsoleKey.D6: {
                            System.Environment.Exit(1);
                            break;
                        }  
                }
                Console.ReadKey();
            }
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
            }
        }
        public void Agregar() {
            Console.Clear();
            Business.Entities.Usuario usuario = new Business.Entities.Usuario();
            Console.Write("Ingrese Nombre: ");
            usuario.Nombre = Console.ReadLine();
            Console.Write("Ingrese Apellido: ");
            usuario.Apellido = Console.ReadLine();
            Console.Write("Ingrese Nombre de Usuario: ");
            usuario.NombreUsuario = Console.ReadLine();
            Console.Write("Ingrese Clave: ");
            usuario.Clave = Console.ReadLine();
            Console.Write("Ingrese Email: ");
            usuario.Email = Console.ReadLine();
            Console.Write("Ingrese Habilitación de usuario (1-Si/otro-No): ");
            usuario.Habilitado = (Console.ReadLine() == "1");
            usuario.State = BusinessEntity.States.New;
            UsuarioNegocio.Save(usuario);
            Console.WriteLine();
            Console.WriteLine("ID: {0}", usuario.ID);
        }
        public void Modificar() {
            try { 
                Console.Clear();
                Console.Write("Ingrese el ID del usuario a modificar: ");
                int id = int.Parse(Console.ReadLine());
                Business.Entities.Usuario usuario = UsuarioNegocio.GetOne(id);
                Console.Write("Ingrese Nombre: ");
                usuario.Nombre = Console.ReadLine();
                Console.Write("Ingrese Apellido: ");
                usuario.Apellido = Console.ReadLine();
                Console.Write("Ingrese Nombre de Usuario: ");
                usuario.NombreUsuario = Console.ReadLine();
                Console.Write("Ingrese Clave: ");
                usuario.Clave = Console.ReadLine();
                Console.Write("Ingrese Email: ");
                usuario.Email = Console.ReadLine();
                Console.Write("Ingrese Habilitación de usuario (1-Si/otro-No): ");
                usuario.Habilitado = (Console.ReadLine() == "1");
                usuario.State = BusinessEntity.States.Modified;
                UsuarioNegocio.Save(usuario);
            } 
            catch(FormatException fe) {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un número entero");
            } 
            catch(Exception e) {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            } 
            finally {
                Console.WriteLine("Presione una tecla para continuar");
            }
        }
        public void Eliminar() {
            try {
                Console.Clear();
                Console.Write("Ingrese el ID del usuario a eliminar: ");
                int id = int.Parse(Console.ReadLine());
                UsuarioNegocio.Delete(id);
            }
            catch(FormatException fe){
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un numero entero");
            }
            catch(Exception e) {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally {
                Console.WriteLine("Presione una tecla para continuar");
            }
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
