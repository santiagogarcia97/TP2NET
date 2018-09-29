﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    public class AlumnoInscripcionLogic: BusinessLogic
    {
        private AlumnoInscripcionAdapter _AlumnoInscripcionData;
        public AlumnoInscripcionAdapter AlumnoInscripcionData { get => _AlumnoInscripcionData; set => _AlumnoInscripcionData = value; }

        public AlumnoInscripcionLogic()
        {
            AlumnoInscripcionData = new AlumnoInscripcionAdapter();
        }

        public List<AlumnoInscripcion> GetAll()
        {
            return AlumnoInscripcionData.GetAll();
        }

        public List<AlumnoInscripcion> GetAllFromUser(int IDUsuario) {
            return AlumnoInscripcionData.GetAllFromUser(IDUsuario);
        }
        public List<AlumnoInscripcion> GetAllFromCurso(int IDCurso) {
            return AlumnoInscripcionData.GetAllFromCurso(IDCurso);
        }
        public AlumnoInscripcion GetOne(int id)
        {
            return AlumnoInscripcionData.GetOne(id);
        }
        public int GetCantCupo(int IDCurso) {
            return AlumnoInscripcionData.GetCupo(IDCurso);
        }

        public void Save(AlumnoInscripcion insc)
        {
            AlumnoInscripcionData.Save(insc);
        }
    }
}
