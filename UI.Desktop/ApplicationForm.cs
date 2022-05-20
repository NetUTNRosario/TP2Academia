using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class ApplicationForm : Form
    {
        public enum ModoForm
        {
            Baja = 0, Alta =1,  Modificacion=2, Consulta=3

        }

        public ModoForm modo;


        public ApplicationForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// MapearDeDatos va a ser utilizado en cada formulario para copiar la 
        /// información de las entidades a los controles del formulario(TextBox,
        /// ComboBox, etc) para mostrar la infromación de cada entidad
        /// </summary>
        public virtual void MapearDeDatos() { }

        /// <summary>
        /// MapearADatos se va a utilizar para pasar la información de los
        /// controles a una entidad para luego enviarla a las capas inferiores
        /// </summary>
        public virtual void MapearADatos() { }

        /// <summary>
        /// GuardarCambios es el método que se encargará de invocar al método
        /// correspondiente de la capa de negocio según sea el ModoForm en que se
        /// encuentre el formulario
        /// </summary>
        public virtual void GuardarCambios() { }

        /// <summary>
        /// Validar será el método que devuelva si los datos son válidos para poder
        /// registrar los cambios realizados
        /// </summary>
        /// <returns></returns>
        public virtual bool Validar() { return false; }
        
        /// <summary>
        /// Notificar es el método que utilizaremos para unificar el mecanismo de
        ///avisos al usuario y en caso de tener que modificar la forma en que se
        ///realizan los avisos al usuario sólo se debe modificar este método, en
        ///lugar de tener que reemplazarlo en toda la aplicación. 
        /// </summary>
        public void Notificar(string titulo, string mensaje, MessageBoxButtons
        botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }

        /// <summary>
        /// Notificar es el método que utilizaremos para unificar el mecanismo de
        ///avisos al usuario y en caso de tener que modificar la forma en que se
        ///realizan los avisos al usuario sólo se debe modificar este método, en
        ///lugar de tener que reemplazarlo en toda la aplicación.
        /// </summary>
        public void Notificar(string mensaje, MessageBoxButtons botones,
        MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }
    }
}
