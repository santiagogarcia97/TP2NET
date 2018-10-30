using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;
using System.Data;

namespace Business.Logic {
    public class MateriaLogic : BusinessLogic {
        private MateriaAdapter _MateriaData;

        public MateriaAdapter MateriaData {
            get { return _MateriaData; }
            set { _MateriaData = value; }
        }

        public MateriaLogic() {
            MateriaData = new MateriaAdapter();
        }

        public List<Materia> GetAll() {
            return MateriaData.GetAll();

        }

        public Materia GetOne(int id) {
            return MateriaData.GetOne(id);
        }

        public void Save(Materia mat) {
            MateriaData.Save(mat);
        }
        public DataTable GetListado() {

            List<Materia> materias = MateriaData.GetAll();
            //Se crea el DataTable que va a ser el DataSource del dgv
            DataTable Listado = new DataTable();
            Listado.Columns.Add("ID", typeof(int));
            Listado.Columns.Add("Descripcion", typeof(string));
            Listado.Columns.Add("HSSemanales", typeof(int));
            Listado.Columns.Add("HSTotales", typeof(int));
            Listado.Columns.Add("Plan", typeof(string));

            //Se obtienen las especialidades y los planes para mostrar en la columna Plan = esp.Descripcion + plan.Descripcion
            PlanLogic pl = new PlanLogic();
            List<Plan> planes = pl.GetAll();
            EspecialidadLogic el = new EspecialidadLogic();
            List<Especialidad> especialidades = el.GetAll();

            foreach (Materia mat in materias) {
                DataRow Linea = Listado.NewRow();

                Linea["ID"] = mat.ID;
                Linea["Descripcion"] = mat.Descripcion;
                Linea["HSSemanales"] = mat.HSSemanales;
                Linea["HSTotales"] = mat.HSTotales;

                Plan plan = planes.FirstOrDefault(x => x.ID == mat.IDPlan);
                Especialidad esp = especialidades.FirstOrDefault(x => x.ID == plan.IDEspecialidad);
                Linea["Plan"] = esp.Descripcion + " - " + plan.Descripcion;

                Listado.Rows.Add(Linea);
            }
            return Listado;
        }
            
    }
}
