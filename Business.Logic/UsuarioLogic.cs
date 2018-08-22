﻿using System;
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
        public Usuario GetOne(String username){
            return UsuarioData.GetOne(username);
        }
        public void Delete(int id) {
            UsuarioData.Delete(id);
        }
        public void Save(Usuario user) {
            UsuarioData.Save(user);
        }
    }
}
