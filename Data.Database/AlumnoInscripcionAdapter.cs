using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data.SqlClient;

namespace Data.Database
{
    public class AlumnoInscripcionAdapter: Adapter
    {
        public List<AlumnoInscripcion> GetAll()
        {
            List<AlumnoInscripcion> alumnoInscripciones = new List<AlumnoInscripcion>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdAlumnoInscripciones = new SqlCommand("SELECT * FROM alumnos_inscripciones", SqlConn);
                SqlDataReader drAlumnoInscripciones = cmdAlumnoInscripciones.ExecuteReader();

                while (drAlumnoInscripciones.Read()){
                    AlumnoInscripcion insc = new AlumnoInscripcion {
                        ID = (int)drAlumnoInscripciones["id_inscripcion"],
                        IDAlumno = (int)drAlumnoInscripciones["id_alumno"],
                        IDCurso = (int)drAlumnoInscripciones["id_curso"],
                        Habilitado = (bool)drAlumnoInscripciones["ai_hab"],
                        Nota = drAlumnoInscripciones["nota"].ToString(),
                        Condicion = (AlumnoInscripcion.Condiciones)System.Enum.Parse(typeof(AlumnoInscripcion.Condiciones), (string)drAlumnoInscripciones["condicion"])
                    };
                    alumnoInscripciones.Add(insc);
                }
                drAlumnoInscripciones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de Inscripciones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return alumnoInscripciones;
        }
        public List<AlumnoInscripcion> GetAllFromUser(int IDUsuario) {
            List<AlumnoInscripcion> alumnoInscripciones = new List<AlumnoInscripcion>();
            try {
                this.OpenConnection();
                SqlCommand cmdAlumnoInscripciones = new SqlCommand("SELECT * FROM alumnos_inscripciones WHERE id_alumno = @ID AND ai_hab = @ai_hab", SqlConn);
                cmdAlumnoInscripciones.Parameters.Add("@ID", SqlDbType.Int).Value = IDUsuario;
                cmdAlumnoInscripciones.Parameters.Add("@ai_hab", SqlDbType.Bit).Value = true;
                SqlDataReader drAlumnoInscripciones = cmdAlumnoInscripciones.ExecuteReader();

                while (drAlumnoInscripciones.Read()) {
                    AlumnoInscripcion insc = new AlumnoInscripcion {
                        ID = (int)drAlumnoInscripciones["id_inscripcion"],
                        IDAlumno = (int)drAlumnoInscripciones["id_alumno"],
                        IDCurso = (int)drAlumnoInscripciones["id_curso"],
                        Habilitado = (bool)drAlumnoInscripciones["ai_hab"],
                        Nota = drAlumnoInscripciones["nota"].ToString(),
                        Condicion = (AlumnoInscripcion.Condiciones)System.Enum.Parse(typeof(AlumnoInscripcion.Condiciones), (string)drAlumnoInscripciones["condicion"])
                    };
                    alumnoInscripciones.Add(insc);
                }
                drAlumnoInscripciones.Close();
            }
            catch (Exception Ex) {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de Inscripciones", Ex);
                throw ExcepcionManejada;
            }
            finally {
                this.CloseConnection();
            }
            return alumnoInscripciones;
        }
        public List<AlumnoInscripcion> GetAllFromCurso(int IDCurso) {
            List<AlumnoInscripcion> alumnoInscripciones = new List<AlumnoInscripcion>();
            try {
                this.OpenConnection();
                SqlCommand cmdAlumnoInscripciones = new SqlCommand("SELECT * FROM alumnos_inscripciones WHERE id_curso = @ID AND ai_hab = @ai_hab", SqlConn);
                cmdAlumnoInscripciones.Parameters.Add("@ID", SqlDbType.Int).Value = IDCurso;
                cmdAlumnoInscripciones.Parameters.Add("@ai_hab", SqlDbType.Bit).Value = true;
                SqlDataReader drAlumnoInscripciones = cmdAlumnoInscripciones.ExecuteReader();

                while (drAlumnoInscripciones.Read()) {
                    AlumnoInscripcion insc = new AlumnoInscripcion {
                        ID = (int)drAlumnoInscripciones["id_inscripcion"],
                        IDAlumno = (int)drAlumnoInscripciones["id_alumno"],
                        IDCurso = (int)drAlumnoInscripciones["id_curso"],
                        Habilitado = (bool)drAlumnoInscripciones["ai_hab"],
                        Nota = drAlumnoInscripciones["nota"].ToString(),
                        Condicion = (AlumnoInscripcion.Condiciones)System.Enum.Parse(typeof(AlumnoInscripcion.Condiciones), (string)drAlumnoInscripciones["condicion"])
                    };
                    alumnoInscripciones.Add(insc);
                }
                drAlumnoInscripciones.Close();
            }
            catch (Exception Ex) {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de Inscripciones", Ex);
                throw ExcepcionManejada;
            }
            finally {
                this.CloseConnection();
            }
            return alumnoInscripciones;
        }
        public AlumnoInscripcion GetOne(int ID)
        {
            AlumnoInscripcion insc = new AlumnoInscripcion();
            try
            {
                this.OpenConnection();
                SqlCommand cmdAlumnoInscripciones = new SqlCommand("SELECT * FROM alumnos_inscripciones WHERE id_inscripcion =@id", SqlConn);
                cmdAlumnoInscripciones.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drAlumnoInscripciones = cmdAlumnoInscripciones.ExecuteReader();

                if (drAlumnoInscripciones.Read())
                {
                    insc.ID = (int)drAlumnoInscripciones["id_inscripcion"];
                    insc.IDAlumno = (int)drAlumnoInscripciones["id_alumno"];
                    insc.IDCurso = (int)drAlumnoInscripciones["id_curso"];
                    insc.Habilitado = (bool)drAlumnoInscripciones["ai_hab"];
                    insc.Nota = drAlumnoInscripciones["nota"].ToString();
                    insc.Condicion = (AlumnoInscripcion.Condiciones)System.Enum.Parse(typeof(AlumnoInscripcion.Condiciones), (string)drAlumnoInscripciones["condicion"]);
                }
                drAlumnoInscripciones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar Inscripciones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return insc;
        }
        public int GetCupo(int IDCurso) {
            try {
                this.OpenConnection();
                SqlCommand cmdCountCupo = new SqlCommand("SELECT COUNT(id_alumno) FROM alumnos_inscripciones WHERE id_curso = @idcurso", SqlConn);
                cmdCountCupo.Parameters.Add("@idcurso", SqlDbType.Int).Value = IDCurso;
                int cant = (int)cmdCountCupo.ExecuteScalar();

                return cant;
            }
            catch (Exception ex) {
                Exception excepcionManejada = new Exception("Error al obtener cupo", ex);
                throw excepcionManejada;
            }
            finally {
                this.CloseConnection();
            }
        }
        public void Delete(AlumnoInscripcion insc) {
            try{
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("UPDATE alumnos_inscripciones SET ai_hab@false WHERE id_inscripcion=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = insc.ID;
                cmdDelete.Parameters.Add("@false",SqlDbType.Bit).Value = false;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex){
                Exception excepcionManejada = new Exception("Error al eliminar alumnoInscripcion", ex);
                throw excepcionManejada;
            }
            finally{
                this.CloseConnection();
            }
        }
        protected void Update(AlumnoInscripcion insc){
            try{
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE alumnos_inscripciones SET id_alumno = @id_alumno, " +
                    "id_curso = @id_curso, nota = @nota, condicion = @condicion, ai_hab = @ai_hab " +
                    "WHERE id_inscripcion=@id", SqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = insc.ID;
                cmdSave.Parameters.Add("@id_alumno", SqlDbType.Int).Value = insc.IDAlumno;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = insc.IDCurso;
                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = Int32.Parse(insc.Nota);
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = insc.Condicion.ToString();
                cmdSave.Parameters.Add("@ai_hab", SqlDbType.Bit).Value = insc.Habilitado;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex){
                Exception ExcepcionManejada = new Exception("Error al modificar datos de Inscripcion", Ex);
                throw ExcepcionManejada;
            }
            finally{
                this.CloseConnection();
            }
        }
        protected void Insert(AlumnoInscripcion insc){
            try{
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO alumnos_inscripciones(id_alumno, id_curso, condicion, ai_hab) " +
                    "values(@id_alumno, @id_curso, @condicion, @ai_hab) SELECT @@identity", SqlConn);

                cmdSave.Parameters.Add("@id_alumno", SqlDbType.Int).Value = insc.IDAlumno;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = insc.IDCurso;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = insc.Condicion.ToString();
                cmdSave.Parameters.Add("@ai_hab", SqlDbType.Bit).Value = insc.Habilitado;

                insc.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex){
                Exception ExcepcionManejada = new Exception("Error al crear Inscripcion", Ex);
                throw ExcepcionManejada;
            }
            finally{
                this.CloseConnection();
            }
        }
        public void Save(AlumnoInscripcion insc){
            if (insc.State == BusinessEntity.States.Deleted){
                this.Delete(insc);
            }
            else if (insc.State == BusinessEntity.States.New){
                this.Insert(insc);
            }
            else if (insc.State == BusinessEntity.States.Modified){
                this.Update(insc);
            }
            insc.State = BusinessEntity.States.Unmodified;
        }
    }

}

