using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data.SqlClient;

namespace Data.Database {
    public class MateriaAdapter : Adapter {
        public List<Materia> GetAll() {
            List<Materia> materias = new List<Materia>();
            try {
                this.OpenConnection();
                SqlCommand cmdMaterias = new SqlCommand("SELECT * FROM materias", SqlConn);
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();

                while (drMaterias.Read()) {
                    Materia mat = new Materia();

                    mat.ID = (int)drMaterias["id_materia"];
                    mat.Descripcion = (string)drMaterias["desc_materia"];
                    mat.HSSemanales = (int)drMaterias["hs_semanales"];
                    mat.HSTotales = (int)drMaterias["hs_totales"];
                    mat.IDPlan = (int)drMaterias["id_plan"];
                    mat.IDString = (mat.ID.ToString() + " - " + mat.Descripcion);
                    materias.Add(mat);
                }
                drMaterias.Close();
            }
            catch (Exception Ex) {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de materias", Ex);
                throw ExcepcionManejada;
            }
            finally {
                this.CloseConnection();
            }
            return materias;
        }

        public Business.Entities.Materia GetOne(int ID) {
            Materia mat = new Materia();
            try {
                this.OpenConnection();
                SqlCommand cmdMaterias = new SqlCommand("SELECT * FROM materias WHERE id_materia=@id", SqlConn);
                cmdMaterias.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();

                if (drMaterias.Read()) {
                    mat.ID = (int)drMaterias["id_materia"];
                    mat.Descripcion = (string)drMaterias["desc_materia"];
                    mat.HSSemanales = (int)drMaterias["hs_semanales"];
                    mat.HSTotales = (int)drMaterias["hs_totales"];
                    mat.IDPlan = (int)drMaterias["id_plan"];
                    mat.IDString = (mat.ID.ToString() + " - " + mat.Descripcion);
                }
                drMaterias.Close();
            }
            catch (Exception Ex) {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar materia", Ex);
                throw ExcepcionManejada;
            }
            finally {
                this.CloseConnection();
            }
            return mat;
        }

        public void Delete(int ID) {
            try {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE materias WHERE id_materia=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex) {
                Exception excepcionManejada = new Exception("Error al eliminar materia", ex);
                throw excepcionManejada;
            }
            finally {
                this.CloseConnection();
            }
        }

        protected void Update(Materia materia) {
            try {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE materias SET desc_materia = @desc, " +
                    "hs_semanales = @hs_semanales, hs_totales = @hs_totales, id_plan = @id_plan " +
                    "WHERE id_materia=@id", SqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = materia.ID;
                cmdSave.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = materia.Descripcion;
                cmdSave.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = materia.HSSemanales;
                cmdSave.Parameters.Add("@hs_totales", SqlDbType.Int).Value = materia.HSTotales;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = materia.IDPlan;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex) {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del materia", Ex);
                throw ExcepcionManejada;
            }
            finally {
                this.CloseConnection();
            }
        }

        protected void Insert(Materia materia) {

            try {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO materias(desc_materia, hs_semanales, hs_totales,id_plan) " +
                    "values(@desc, @hs_semanales, @hs_totales, @id_plan) SELECT @@identity", SqlConn);
                cmdSave.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = materia.Descripcion;
                cmdSave.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = materia.HSSemanales;
                cmdSave.Parameters.Add("@hs_totales", SqlDbType.Int).Value = materia.HSTotales;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = materia.IDPlan;
                materia.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex) {
                Exception ExcepcionManejada = new Exception("Error al crear materia", Ex);
                throw ExcepcionManejada;
            }
            finally {
                this.CloseConnection();
            }
        }


        public void Save(Materia materia) {
            if (materia.State == BusinessEntity.States.Deleted) {
                this.Delete(materia.ID);
            }
            else if (materia.State == BusinessEntity.States.New) {
                this.Insert(materia);
            }
            else if (materia.State == BusinessEntity.States.Modified) {
                this.Update(materia);
            }
            materia.State = BusinessEntity.States.Unmodified;
        }
    }
}
