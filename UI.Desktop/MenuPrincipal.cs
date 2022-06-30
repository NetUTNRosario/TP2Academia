using System;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class MenuPrincipal : Form
    {
        Business.Entities.Usuario _usuarioLogueado;

        public Business.Entities.Usuario usuarioLogueado {
            get { return _usuarioLogueado; }
            set { _usuarioLogueado = value; }
        }

        public MenuPrincipal()
        {
            InitializeComponent();
        }
        public MenuPrincipal(Business.Entities.Usuario usuarioActual) : this()
        {
            usuarioLogueado = usuarioActual;
        }

        private void especialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Especialidades().Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Usuarios().Show();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //new Logueo().Show();
            this.Close();
        }

        private void cambiarContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO: Inicio de sesion que inicialice usuarioLogueado
            UsuarioDesktop usuarioDesk = new UsuarioDesktop(usuarioLogueado.ID, ApplicationForm.ModoForm.Modificacion);
            usuarioDesk.ShowDialog();
        }
    }
}
