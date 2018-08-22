using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class UsuarioAdapter:Adapter
    {
        public List<Usuario> GetAll()
        {
            List<Usuario> usuarios = new List<Usuario>();
            try {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("SELECT * FROM usuarios", SqlConn);
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();

                while (drUsuarios.Read()) {
                    Usuario user = new Usuario();
                    user.ID = (int)drUsuarios["id_usuario"];
                    user.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    user.Clave = (string)drUsuarios["clave"];
                    user.Habilitado = (bool)drUsuarios["habilitado"];
                    user.Nombre = (string)drUsuarios["nombre"];
                    user.Apellido = (string)drUsuarios["apellido"];
                    user.Email = (string)drUsuarios["email"];
                    user.Direccion = (string)drUsuarios["direccion"];
                    user.Telefono = (string)drUsuarios["telefono"];
                    user.FechaNacimiento = (DateTime)drUsuarios["fecha_nac"];
                    user.Habilitado = (bool)drUsuarios["habilitado"];
                    user.CambiaClave = (bool)drUsuarios["cambia_clave"];
                    user.Legajo = (int)drUsuarios["legajo"];
                    user.TipoPersona = (int)drUsuarios["tipo_persona"];
                    user.Email = (string)drUsuarios["email"];
                    user.IDPlan = (int)drUsuarios["id_plan"];
                    usuarios.Add(user);
                }
                drUsuarios.Close();
            }
            catch (Exception Ex) {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally {
                this.CloseConnection();
            }        
            return usuarios;
        }

        public Usuario GetOne(int ID){

            Usuario user = new Usuario();
            try {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("SELECT * FROM usuarios WHERE id_usuario=@id", SqlConn);
                cmdUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();

                if (drUsuarios.Read()) {
                    user.ID = (int)drUsuarios["id_usuario"];
                    user.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    user.Clave = (string)drUsuarios["clave"];
                    user.Habilitado = (bool)drUsuarios["habilitado"];
                    user.Nombre = (string)drUsuarios["nombre"];
                    user.Apellido = (string)drUsuarios["apellido"];
                    user.Email = (string)drUsuarios["email"];
                    user.Direccion = (string)drUsuarios["direccion"];
                    user.Telefono = (string)drUsuarios["telefono"];
                    user.FechaNacimiento = (DateTime)drUsuarios["fecha_nac"];
                    user.Habilitado = (bool)drUsuarios["habilitado"];
                    user.CambiaClave = (bool)drUsuarios["cambia_clave"];
                    user.Legajo = (int)drUsuarios["legajo"];
                    user.TipoPersona = (int)drUsuarios["tipo_persona"];
                    user.Email = (string)drUsuarios["email"];
                    user.IDPlan = (int)drUsuarios["id_plan"];
                }
                drUsuarios.Close();
            }
            catch (Exception Ex) {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar usuario", Ex);
                throw ExcepcionManejada;
            }
            finally {
                this.CloseConnection();
            }
            return user;
        }
        public Usuario GetOne(String username) {

            Usuario user = new Usuario();
            try {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("SELECT * FROM usuarios WHERE nombre_usuario=@username", SqlConn);
                cmdUsuarios.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();

                if (drUsuarios.Read()) {
                    user.ID = (int)drUsuarios["id_usuario"];
                    user.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    user.Clave = (string)drUsuarios["clave"];
                    user.Habilitado = (bool)drUsuarios["habilitado"];
                    user.Nombre = (string)drUsuarios["nombre"];
                    user.Apellido = (string)drUsuarios["apellido"];
                    user.Email = (string)drUsuarios["email"];
                    user.Direccion = (string)drUsuarios["direccion"];
                    user.Telefono = (string)drUsuarios["telefono"];
                    user.FechaNacimiento = (DateTime)drUsuarios["fecha_nac"];
                    user.Habilitado = (bool)drUsuarios["habilitado"];
                    user.CambiaClave = (bool)drUsuarios["cambia_clave"];
                    user.Legajo = (int)drUsuarios["legajo"];
                    user.TipoPersona = (int)drUsuarios["tipo_persona"];
                    user.Email = (string)drUsuarios["email"];
                    user.IDPlan = (int)drUsuarios["id_plan"];
                }
                drUsuarios.Close();
            }
            catch (Exception Ex) {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar usuario", Ex);
                throw ExcepcionManejada;
            }
            finally {
                this.CloseConnection();
            }
            return user;
        }

        public void Delete(int ID)
        {
            try {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE usuarios WHERE id_usuario=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch(Exception ex) {
                Exception excepcionManejada = new Exception("Error al eliminar usuario", ex);
                throw excepcionManejada;
            }
            finally {
                this.CloseConnection();
            }
        }

        protected void Update(Usuario usuario) {
            try {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE usuarios SET nombre_usuario = @nombre_usuario, " +
                    "clave = @clave,  habilitado = @habilitado, id_persona = @id_persona " +
                    "WHERE id_usuario=@id", SqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = usuario.ID;
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex) {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del usuario", Ex);
                throw ExcepcionManejada;
            }
            finally {
                this.CloseConnection();
            }
        }

        protected void Insert(Usuario usuario) {

            try {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO usuarios(nombre_usuario,clave,habilitado,id_persona) " +
                    "values(@nombre_usuario, @clave,@habilitado, @id_persona) SELECT @@identity", SqlConn);
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                usuario.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex) {
                Exception ExcepcionManejada = new Exception("Error al crear usuario", Ex);
                throw ExcepcionManejada;
            }
            finally {
                this.CloseConnection();
            }
        }


public void Save(Usuario usuario)
        {
            if (usuario.State == BusinessEntity.States.Deleted)
            {
                this.Delete(usuario.ID);
            }
            else if (usuario.State == BusinessEntity.States.New)
            {
                this.Insert(usuario);
            }
            else if (usuario.State == BusinessEntity.States.Modified)
            {
                this.Update(usuario);
            }
            usuario.State = BusinessEntity.States.Unmodified;            
        }
    }
}
