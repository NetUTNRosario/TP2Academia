using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Modulo:BusinessEntities
    {
        private string _Descripcion;
        public string Descripcion { set { _Descripcion = value; } get { return _Descripcion; } }
    }
}
