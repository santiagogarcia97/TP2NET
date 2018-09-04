using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data.SqlClient;

namespace Data.Database {
    public class CursoMatComAdapter : Adapter {
        public List<CursoMatCom> GetAll() {
            List<CursoMatCom> cmcs = new List<CursoMatCom>();
            try {
                this.OpenConnection();
                SqlCommand cmdCursoMatCom = new SqlCommand("SELECT * " +
                                                            "FROM cursos LEFT JOIN materias " +
                                                                "ON cursos.id_materia = materias.id_materia LEFT JOIN comisiones " +
                                                                "ON cursos.id_comision = comisiones.id_comision;", SqlConn);
                SqlDataReader drCursoMatCom = cmdCursoMatCom.ExecuteReader();

                while (drCursoMatCom.Read()) {
                    CursoMatCom cmc = new CursoMatCom();

                    cmc.ID = (int)drCursoMatCom["id_curso"];
                    cmc.IDMateria = (int)drCursoMatCom["id_materia"];
                    cmc.IDPlan = (int)drCursoMatCom["id_plan"];
                    cmc.IDComision = (int)drCursoMatCom["id_comision"];
                    cmc.DescComision = drCursoMatCom["desc_comision"].ToString();
                    cmc.DescMateria = drCursoMatCom["desc_materia"].ToString();
                    cmcs.Add(cmc);
                }
                drCursoMatCom.Close();
            }
            catch (Exception Ex) {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }
            finally {
                this.CloseConnection();
            }
            return cmcs;
        }



    }
}
