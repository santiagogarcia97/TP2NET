using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data.SqlClient;

namespace Data.Database {
    public class EspecialidadAdapter : Adapter {
        public List<Especialidad> GetAll() {
            List<Especialidad> especialidades = new List<Especialidad>();
            try {
                this.OpenConnection();
                SqlCommand cmdEspecialidades = new SqlCommand("SELECT * FROM especialidades", SqlConn);
                SqlDataReader drEspecialidades = cmdEspecialidades.ExecuteReader();

                while (drEspecialidades.Read()) {
                    Especialidad esp = new Especialidad();

                    esp.ID = (int)drEspecialidades["id_especialidad"];
                    esp.Habilitado = (bool)drEspecialidades["esp_hab"];
                    esp.Descripcion = (string)drEspecialidades["desc_especialidad"];
                    especialidades.Add(esp);
                }
                drEspecialidades.Close();
            }
            catch (Exception Ex) {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de especialidades", Ex);
                throw ExcepcionManejada;
            }
            finally {
                this.CloseConnection();
            }
            return especialidades;
        }

        public Business.Entities.Especialidad GetOne(int ID) {
            Especialidad esp = new Especialidad();
            try {
                this.OpenConnection();
                SqlCommand cmdEspecialidades = new SqlCommand("SELECT * FROM especialidades WHERE id_especialidad=@id", SqlConn);
                cmdEspecialidades.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drEspecialidades = cmdEspecialidades.ExecuteReader();

                if (drEspecialidades.Read()) {
                    esp.ID = (int)drEspecialidades["id_especialidad"];
                    esp.Habilitado = (bool)drEspecialidades["esp_hab"];
                    esp.Descripcion = (string)drEspecialidades["desc_especialidad"];
                }
                drEspecialidades.Close();
            }
            catch (Exception Ex) {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar especialidad", Ex);
                throw ExcepcionManejada;
            }
            finally {
                this.CloseConnection();
            }
            return esp;
        }

        public void Delete(int ID) {
            try {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE especialidades WHERE id_especialidad=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex) {
                Exception excepcionManejada = new Exception("Error al eliminar especialidad", ex);
                throw excepcionManejada;
            }
            finally {
                this.CloseConnection();
            }
        }

        protected void Update(Especialidad especialidad) {
            try {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE especialidades SET desc_especialidad = @desc, esp_hab = @esp_hab " +
                    "WHERE id_especialidad=@id", SqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = especialidad.ID;
                cmdSave.Parameters.Add("@esp_hab", SqlDbType.Bit).Value = especialidad.Habilitado;
                cmdSave.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = especialidad.Descripcion;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex) {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la especialidad", Ex);
                throw ExcepcionManejada;
            }
            finally {
                this.CloseConnection();
            }
        }

        protected void Insert(Especialidad especialidad) {

            try {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO especialidades(desc_especialidad,esp_hab) " +
                    "values(@desc,@esp_hab) SELECT @@identity", SqlConn);
                cmdSave.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = especialidad.Descripcion;
                especialidad.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex) {
                Exception ExcepcionManejada = new Exception("Error al crear especialidad", Ex);
                throw ExcepcionManejada;
            }
            finally {
                this.CloseConnection();
            }
        }


        public void Save(Especialidad especialidad) {
            if (especialidad.State == BusinessEntity.States.Deleted) {
                this.Delete(especialidad.ID);
            }
            else if (especialidad.State == BusinessEntity.States.New) {
                this.Insert(especialidad);
            }
            else if (especialidad.State == BusinessEntity.States.Modified) {
                this.Update(especialidad);
            }
            especialidad.State = BusinessEntity.States.Unmodified;
        }
    }
}
