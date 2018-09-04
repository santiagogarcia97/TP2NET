using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data.SqlClient;

namespace Data.Database {
    public class CursoAdapter : Adapter {
        public List<Curso> GetAll() {
            List<Curso> cursos = new List<Curso>();
            try {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("SELECT * FROM cursos", SqlConn);
                SqlDataReader drCursos = cmdCursos.ExecuteReader();

                while (drCursos.Read()) {
                    Curso crs = new Curso();

                    crs.ID = (int)drCursos["id_curso"];
                    crs.Cupo = (int)drCursos["cupo"];
                    crs.AnioCalendario = (int)drCursos["anio_calendario"];
                    crs.IDComision = (int)drCursos["id_comision"];
                    crs.IDMateria = (int)drCursos["id_materia"];
                    crs.Habilitado = (bool)drCursos["curso_hab"];
                    cursos.Add(crs);
                }
                drCursos.Close();
            }
            catch (Exception Ex) {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }
            finally {
                this.CloseConnection();
            }
            return cursos;
        }

        public Business.Entities.Curso GetOne(int ID) {
            Curso crs = new Curso();
            try {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("SELECT * FROM cursos WHERE id_curso=@id", SqlConn);
                cmdCursos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drCursos = cmdCursos.ExecuteReader();

                if (drCursos.Read()) {
                    crs.ID = (int)drCursos["id_curso"];
                    crs.Cupo = (int)drCursos["cupo"];
                    crs.AnioCalendario = (int)drCursos["anio_calendario"];
                    crs.IDComision = (int)drCursos["id_comision"];
                    crs.IDMateria = (int)drCursos["id_materia"];
                    crs.Habilitado = (bool)drCursos["curso_hab"];


                }
                drCursos.Close();
            }
            catch (Exception Ex) {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar curso", Ex);
                throw ExcepcionManejada;
            }
            finally {
                this.CloseConnection();
            }
            return crs;
        }

        public void Delete(int ID) {
            try {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE cursos WHERE id_curso=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex) {
                Exception excepcionManejada = new Exception("Error al eliminar curso", ex);
                throw excepcionManejada;
            }
            finally {
                this.CloseConnection();
            }
        }

        protected void Update(Curso curso) {
            try {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE cursos SET " +
                    "cupo = @cupo, anio_calendario = @anio_calendario, id_comision = @id_comision, " +
                    "id_materia = @id_materia, mat_hab = @mat_hab WHERE id_curso=@id", SqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = curso.ID;
                cmdSave.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
                cmdSave.Parameters.Add("@anio_calendario", SqlDbType.Int).Value = curso.AnioCalendario;
                cmdSave.Parameters.Add("@id_comision", SqlDbType.Int).Value = curso.IDComision;
                cmdSave.Parameters.Add("@id_materia", SqlDbType.Int).Value = curso.IDMateria;
                cmdSave.Parameters.Add("@mat_hab", SqlDbType.Bit).Value = curso.Habilitado;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex) {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del curso", Ex);
                throw ExcepcionManejada;
            }
            finally {
                this.CloseConnection();
            }
        }

        protected void Insert(Curso curso) {

            try {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO cursos(cupo, anio_calendario,id_comision,id_materia,mat_hab) " +
                    "values(@cupo, @anio_calendario, @id_comision,@id_materia,@mat_hab) SELECT @@identity", SqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = curso.ID;
                cmdSave.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
                cmdSave.Parameters.Add("@anio_calendario", SqlDbType.Int).Value = curso.AnioCalendario;
                cmdSave.Parameters.Add("@id_comision", SqlDbType.Int).Value = curso.IDComision;
                cmdSave.Parameters.Add("@id_materia", SqlDbType.Int).Value = curso.IDMateria;
                cmdSave.Parameters.Add("@mat_hab", SqlDbType.Bit).Value = curso.Habilitado;

                curso.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex) {
                Exception ExcepcionManejada = new Exception("Error al crear curso", Ex);
                throw ExcepcionManejada;
            }
            finally {
                this.CloseConnection();
            }
        }


        public void Save(Curso curso) {
            if (curso.State == BusinessEntity.States.Deleted) {
                this.Delete(curso.ID);
            }
            else if (curso.State == BusinessEntity.States.New) {
                this.Insert(curso);
            }
            else if (curso.State == BusinessEntity.States.Modified) {
                this.Update(curso);
            }
            curso.State = BusinessEntity.States.Unmodified;
        }
    }
}
