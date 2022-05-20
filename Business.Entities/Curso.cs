using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    class Curso:BusinessEntity
    {
        private int _AnioCalendario;
        public int AnioCalendario { set { _AnioCalendario = value; } get { return _AnioCalendario; } }

        private int _Cupo;
        public int Cupo { set { _Cupo = value; } get { return _Cupo; } }

        private string _Descripcion;
        public string Descripcion { set { _Descripcion = value; } get { return _Descripcion; } }

        private int _IDComision;
        public int IDComision { set { _IDComision = value; } get { return _IDComision; } }

        private int _IDMateria;
        public int IDMateria { set { _IDMateria = value; } get { return _IDMateria; } }
    }
}
