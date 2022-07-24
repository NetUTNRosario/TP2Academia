﻿using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class ModuloUsuarioLogic : BusinessLogic
    {
        private ModuloUsuarioAdapter ModuloUsuarioData;

        public ModuloUsuarioLogic()
        {
            ModuloUsuarioData = new ModuloUsuarioAdapter();
        }

        public ModuloUsuario GetOne(int id)
        {
            return ModuloUsuarioData.GetOne(id);
        }

        public List<ModuloUsuario> GetAll()
        {
            return ModuloUsuarioData.GetAll();
        }

        public void Delete(int id)
        {
            ModuloUsuarioData.Delete(id);
        }

        public void Save(ModuloUsuario usuario)
        {
            ModuloUsuarioData.Save(usuario);
        }
    }
}
