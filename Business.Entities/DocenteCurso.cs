using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    class DocenteCurso:BusinessEntities
    {
        private TiposCargos _Cargo;
        public TiposCargos Cargo { set { _Cargo = value; } get { return _Cargo; } }

        private int _IDCurso;
        public int IDCurso { set { _IDCurso = value; } get { return _IDCurso; } }

        private int _IDDocente;
        public int IDDocente { set { _IDDocente = value; } get { return _IDDocente; } }

        public enum TiposCargos { }
    }
}
