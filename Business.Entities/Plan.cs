﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    class Plan:BusinessEntities
    {
        private string _Descripcion;
        public string Descripcion{ get { return _Descripcion; } set { _Descripcion = value; } }
        private int _IDEspecialidad; 
        public int IDEspecialidad{ get { return _IDEspecialidad; } set { _IDEspecialidad=value; } }
    }
}
