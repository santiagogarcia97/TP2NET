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
    public class DocenteCursoAdapter : Adapter
    {
        public List<DocenteCurso> GetAll()
        {
            List<DocenteCurso> docenteCursos = new List<DocenteCurso>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdDocenteCurso = new SqlCommand("SELECT * FROM docentes_cursos", SqlConn);
                SqlDataReader drDocenteCurso = cmdDocenteCurso.ExecuteReader();

                while (drDocenteCurso.Read()){
                    DocenteCurso dc = new DocenteCurso {
                        ID = (int)drDocenteCurso["id_dictado"],
                        IDCurso = (int)drDocenteCurso["id_curso"],
                        IDDocente = (int)drDocenteCurso["id_docente"],
                        Habilitado = (bool)drDocenteCurso["dc_hab"],
                        Cargo = (DocenteCurso.TipoCargos)drDocenteCurso["cargo"]
                    };

                    docenteCursos.Add(dc);
                }
                drDocenteCurso.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de DocenteCursos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return docenteCursos;
        }
        public List<DocenteCurso> GetAllFromUser(int IDUsuario) {
            List<DocenteCurso> docenteCursos = new List<DocenteCurso>();
            try {
                this.OpenConnection();
                SqlCommand cmdDocenteCurso = new SqlCommand("SELECT * FROM docentes_cursos WHERE id_docente = @ID AND dc_hab = @dc_hab", SqlConn);
                cmdDocenteCurso.Parameters.Add("@ID", SqlDbType.Int).Value = IDUsuario;
                cmdDocenteCurso.Parameters.Add("@dc_hab", SqlDbType.Bit).Value = true;
                SqlDataReader drDocenteCurso = cmdDocenteCurso.ExecuteReader();

                while (drDocenteCurso.Read()) {
                    DocenteCurso dc = new DocenteCurso {
                        ID = (int)drDocenteCurso["id_dictado"],
                        IDCurso = (int)drDocenteCurso["id_curso"],
                        IDDocente = (int)drDocenteCurso["id_docente"],
                        Habilitado = (bool)drDocenteCurso["dc_hab"],
                        Cargo = (DocenteCurso.TipoCargos)drDocenteCurso["cargo"]
                    };

                    docenteCursos.Add(dc);
                }
                drDocenteCurso.Close();
            }
            catch (Exception Ex) {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de DocenteCursos", Ex);
                throw ExcepcionManejada;
            }
            finally {
                this.CloseConnection();
            }
            return docenteCursos;
        }
        public DocenteCurso GetOne(int ID)
        {
            DocenteCurso dc = new DocenteCurso();
            try
            {
                this.OpenConnection();
                SqlCommand cmdDocenteCurso = new SqlCommand("SELECT * FROM docentes_cursos WHERE id_dictado=@id", SqlConn);
                cmdDocenteCurso.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drDocenteCurso = cmdDocenteCurso.ExecuteReader();

                if (drDocenteCurso.Read())
                {
                    dc.ID = (int)drDocenteCurso["id_dictado"];
                    dc.IDCurso = (int)drDocenteCurso["id_curso"];
                    dc.IDDocente = (int)drDocenteCurso["id_docente"];
                    dc.Habilitado = (bool)drDocenteCurso["dc_hab"];
                    dc.Cargo = (DocenteCurso.TipoCargos)drDocenteCurso["cargo"];
                }
                drDocenteCurso.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar DocenteCurso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return dc;
        }
        public DocenteCurso GetOne(int IDDocente, int IDCurso) {
            DocenteCurso dc = new DocenteCurso();
            try {
                this.OpenConnection();
                SqlCommand cmdDocenteCurso = new SqlCommand("SELECT * FROM docentes_cursos WHERE id_docente=@iddocente AND id_curso=@idcurso", SqlConn);
                cmdDocenteCurso.Parameters.Add("@iddocente", SqlDbType.Int).Value = IDDocente;
                cmdDocenteCurso.Parameters.Add("@idcurso", SqlDbType.Int).Value = IDCurso;
                SqlDataReader drDocenteCurso = cmdDocenteCurso.ExecuteReader();

                if (drDocenteCurso.Read()) {
                    dc.ID = (int)drDocenteCurso["id_dictado"];
                    dc.IDCurso = (int)drDocenteCurso["id_curso"];
                    dc.IDDocente = (int)drDocenteCurso["id_docente"];
                    dc.Habilitado = (bool)drDocenteCurso["dc_hab"];
                    dc.Cargo = (DocenteCurso.TipoCargos)drDocenteCurso["cargo"];
                }
                drDocenteCurso.Close();
            }
            catch (Exception Ex) {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar DocenteCurso", Ex);
                throw ExcepcionManejada;
            }
            finally {
                this.CloseConnection();
            }
            return dc;
        }

        public void Delete(DocenteCurso dc) {
            try{
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("UPDATE docentes_cursos SET dc_hab=@dc_hab WHERE id_dictado=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = dc.ID;
                cmdDelete.Parameters.Add("@dc_hab",SqlDbType.Bit).Value = false;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex){
                Exception excepcionManejada = new Exception("Error al eliminar DocenteCurso", ex);
                throw excepcionManejada;
            }
            finally{
                this.CloseConnection();
            }
        }
        protected void Update(DocenteCurso dc){
            try{
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE docentes_cursos SET id_docente = @id_docente, " +
                    "id_curso = @id_curso, cargo = @cargo, dc_hab = @dc_hab " +
                    "WHERE id_dictado=@id", SqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = dc.ID;
                cmdSave.Parameters.Add("@id_docente", SqlDbType.Int).Value = dc.IDDocente;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = dc.IDCurso;
                cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = (int)dc.Cargo;
                cmdSave.Parameters.Add("@dc_hab", SqlDbType.Bit).Value = dc.Habilitado;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex){
                Exception ExcepcionManejada = new Exception("Error al modificar datos de DocenteCurso", Ex);
                throw ExcepcionManejada;
            }
            finally{
                this.CloseConnection();
            }
        }
        protected void Insert(DocenteCurso dc){
            try{
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO docentes_cursos(id_docente, id_curso, cargo, dc_hab) " +
                    "values(@id_docente, @id_curso, @cargo, @dc_hab) SELECT @@identity", SqlConn);

                cmdSave.Parameters.Add("@id_docente", SqlDbType.Int).Value = dc.IDDocente;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = dc.IDCurso;
                cmdSave.Parameters.Add("@cargo", SqlDbType.Int, 50).Value = dc.Cargo;
                cmdSave.Parameters.Add("@dc_hab", SqlDbType.Bit).Value = dc.Habilitado;

                dc.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex){
                Exception ExcepcionManejada = new Exception("Error al crear DocenteCurso", Ex);
                throw ExcepcionManejada;
            }
            finally{
                this.CloseConnection();
            }
        }
        public void Save(DocenteCurso dc){
            if (dc.State == BusinessEntity.States.Deleted){
                this.Delete(dc);
            }
            else if (dc.State == BusinessEntity.States.New){
                this.Insert(dc);
            }
            else if (dc.State == BusinessEntity.States.Modified){
                this.Update(dc);
            }
            dc.State = BusinessEntity.States.Unmodified;
        }
    }

}

