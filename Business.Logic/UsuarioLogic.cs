using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic {
    public class UsuarioLogic : BusinessLogic {

        private UsuarioAdapter _UsuarioData;
        public UsuarioAdapter UsuarioData { get => _UsuarioData; set => _UsuarioData = value; }
        public UsuarioLogic() {
            UsuarioData = new UsuarioAdapter();
        }
        public List<Usuario> GetAll() {
            return UsuarioData.GetAll();
        }
        public Usuario GetOne(int id) {
            return UsuarioData.GetOne(id);
        }
        public Usuario GetOne(String username) {
            try {
                return UsuarioData.GetOne(username);
            }
            catch(Exception ex) {
                throw ex;
            }
        }
        public void Save(Usuario user) {
            UsuarioData.Save(user);
        }
        public void SavePassword(Usuario user) {
            UsuarioData.SavePassword(user);
        }
        public int getNewLegajo() {
            int legajo = UsuarioData.getMaxLegajo();
            legajo++;
            return legajo;
        }

    }
}
