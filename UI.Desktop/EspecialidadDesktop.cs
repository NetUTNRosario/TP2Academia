using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;

namespace UI.Desktop
{
    public partial class EspecialidadDesktop : ApplicationForm
    {

        public EspecialidadDesktop():base()
        {
        
        }


        public EspecialidadDesktop(ModoForm modo) : this()
        {

        }

        public EspecialidadDesktop(int ID, ModoForm modo) : this()
        {

        }

        private void EspecialidadDesktop_Load(object sender, EventArgs e)
        {

        }

        private new void MapearDeDatos() { }

        private new void MapearADatos()
        { }

        private new void GuardarCambios() { }

        private new bool Validar() { return false; }

    }
}
