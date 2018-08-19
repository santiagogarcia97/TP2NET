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
                    Usuario usr = new Usuario();
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.IDPersona = (int)drUsuarios["id_persona"];
                    usuarios.Add(usr);
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
            try {
                for(int i = 0; i < usuarios.Count;i++) {
                    this.OpenConnection();
                    SqlCommand cmdPersonas = new SqlCommand("SELECT nombre, apellido, email from personas WHERE id_persona=@idp", SqlConn);
                    cmdPersonas.Parameters.Add("@idp", SqlDbType.Int).Value = usuarios[i].IDPersona;
                    SqlDataReader drPersonas = cmdPersonas.ExecuteReader();
                    if(drPersonas.Read()) {
                        usuarios[i].Nombre = (string)drPersonas["nombre"];
                        usuarios[i].Apellido = (string)drPersonas["apellido"];
                        usuarios[i].Email = (string)drPersonas["email"];
                    }
                }
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

        public Business.Entities.Usuario GetOne(int ID)
        {
            Usuario usr = new Usuario();
            try {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("SELECT * FROM usuarios WHERE id_usuario=@id", SqlConn);
                cmdUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();

                if (drUsuarios.Read()) {
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.IDPersona = (int)drUsuarios["id_persona"];
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
            try {
                this.OpenConnection();
                SqlCommand cmdPersonas = new SqlCommand("SELECT nombre, apellido, email from personas WHERE id_persona=@idp", SqlConn);
                cmdPersonas.Parameters.Add("@idp", SqlDbType.Int).Value = usr.IDPersona;
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();
                if (drPersonas.Read()) {
                    usr.Nombre = (string)drPersonas["nombre"];
                    usr.Apellido = (string)drPersonas["apellido"];
                    usr.Email = (string)drPersonas["email"];
                }
                }
            catch (Exception Ex) {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally {
                this.CloseConnection();
            }
            return usr;
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
                cmdSave.Parameters.Add("@id_persona", SqlDbType.Int).Value = usuario.IDPersona;
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
                cmdSave.Parameters.Add("@id_persona", SqlDbType.Int).Value = usuario.IDPersona;
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
