using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data.SqlClient;

namespace Data.Database {
    public class PlanAdapter : Adapter {
        public List<Plan> GetAll() {
            List<Plan> planes = new List<Plan>();
            try {
                this.OpenConnection();
                SqlCommand cmdPlanes = new SqlCommand("SELECT * FROM planes", SqlConn);
                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();

                while (drPlanes.Read()) {
                    Plan pln = new Plan();

                    pln.ID = (int)drPlanes["id_plan"];
                    pln.Descripcion = (string)drPlanes["desc_plan"];
                    pln.IDEspecialidad = (int)drPlanes["id_especialidad"];
                    pln.Habilitado = (bool)drPlanes["plan_hab"];

                    planes.Add(pln);
                }
                drPlanes.Close();
            }
            catch (Exception Ex) {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de planes", Ex);
                throw ExcepcionManejada;
            }
            finally {
                this.CloseConnection();
            }
            return planes;
        }

        public Business.Entities.Plan GetOne(int ID) {
            Plan pln = new Plan();
            try {
                this.OpenConnection();
                SqlCommand cmdPlanes = new SqlCommand("SELECT * FROM planes WHERE id_plan=@id", SqlConn);
                cmdPlanes.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();

                if (drPlanes.Read()) {
                    pln.ID = (int)drPlanes["id_plan"];
                    pln.Descripcion = (string)drPlanes["desc_plan"];
                    pln.IDEspecialidad = (int)drPlanes["id_especialidad"];
                    pln.Habilitado = (bool)drPlanes["plan_hab"];
                }
                drPlanes.Close();
            }
            catch (Exception Ex) {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar plan", Ex);
                throw ExcepcionManejada;
            }
            finally {
                this.CloseConnection();
            }
            return pln;
        }

        public void Delete(Plan plan) {
            try {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("UPDATE planes SET plan_hab=@false WHERE id_plan=@id",SqlConn);
                cmdDelete.Parameters.Add("@id",SqlDbType.Int).Value = plan.ID;
                cmdDelete.Parameters.Add("@false",SqlDbType.Bit).Value = false;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex) {
                Exception excepcionManejada = new Exception("Error al eliminar plan", ex);
                throw excepcionManejada;
            }
            finally {
                this.CloseConnection();
            }
        }

        protected void Update(Plan plan) {
            try {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE planes SET desc_plan = @desc, id_especialidad = @id_e, plan_hab = @plan_hab " +
                    "WHERE id_plan=@id", SqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = plan.ID;
                cmdSave.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = plan.Descripcion;
                cmdSave.Parameters.Add("@id_e", SqlDbType.Int).Value = plan.IDEspecialidad;
                cmdSave.Parameters.Add("@plan_hab", SqlDbType.Bit).Value = plan.Habilitado;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex) {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del plan", Ex);
                throw ExcepcionManejada;
            }
            finally {
                this.CloseConnection();
            }
        }

        protected void Insert(Plan plan) {

            try {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO planes(desc_plan,id_especialidad,plan_hab) " +
                    "values(@desc,@id_e,@plan_hab) SELECT @@identity", SqlConn);
                cmdSave.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = plan.Descripcion;
                cmdSave.Parameters.Add("@id_e", SqlDbType.Int).Value = plan.IDEspecialidad;
                cmdSave.Parameters.Add("@plan_hab", SqlDbType.Bit).Value = plan.Habilitado;
                plan.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex) {
                Exception ExcepcionManejada = new Exception("Error al crear plan", Ex);
                throw ExcepcionManejada;
            }
            finally {
                this.CloseConnection();
            }
        }


        public void Save(Plan plan) {
            if (plan.State == BusinessEntity.States.Deleted) {
                this.Delete(plan);
            }
            else if (plan.State == BusinessEntity.States.New) {
                this.Insert(plan);
            }
            else if (plan.State == BusinessEntity.States.Modified) {
                this.Update(plan);
            }
            plan.State = BusinessEntity.States.Unmodified;
        }
    }
}
