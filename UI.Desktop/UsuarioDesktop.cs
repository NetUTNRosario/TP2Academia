using Business.Entities;
using Business.Logic;
using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace UI.Desktop
{
    public partial class UsuarioDesktop : ApplicationForm
    {
        public Usuario UsuarioActual;

        public UsuarioDesktop()
        {
            InitializeComponent();
        }

        public UsuarioDesktop(ModoForm modo) : this()
        {
            this.modo = modo;
            MapearDeDatos();
        }

        public UsuarioDesktop(int ID, ModoForm modo) : this()
        {
            this.modo = modo;
            UsuarioLogic ul = new UsuarioLogic();
            this.UsuarioActual = ul.GetOne(ID);
            MapearDeDatos();
        }


        private new void MapearDeDatos()
        {
            if (modo == ModoForm.Alta)
            {
                this.txtID.Text = "";//Cuando hace el save lo genera automaticamente autoincremental
            }
            else
            {
                this.txtID.Text = this.UsuarioActual.ID.ToString();
                this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
                this.txtNombre.Text = this.UsuarioActual.Nombre;
                this.txtApellido.Text = this.UsuarioActual.Apellido;
                this.txtEmail.Text = this.UsuarioActual.Email;
                this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
                this.txtClave.Text = this.UsuarioActual.Clave;
                this.txtConfirmarClave.Text = this.UsuarioActual.Clave;
            } 
            if(modo == ModoForm.Baja)
            {
                this.txtClave.Hide();
                this.lblClave.Hide();
                this.txtConfirmarClave.Hide();
                this.lblConfirmarClave.Hide();
            }

            switch (modo)
            {
                case ModoForm.Alta:
                    this.Text="Alta";
                    this.btnAceptar.Text = "Guardar";
                    break;

                case ModoForm.Baja:
                    this.Text = "Baja";
                    this.btnAceptar.Text = "Eliminar";
                    break;

                case ModoForm.Modificacion:
                    this.Text = "Modificación";
                    this.btnAceptar.Text = "Guardar";
                    break;

                case ModoForm.Consulta:
                    this.Text = "Consulta";
                    this.btnAceptar.Text = "Aceptar";
                    break;

                default:
                    break;
            }
        }

        private new void MapearADatos()
        {
            if (modo == ModoForm.Alta)
            {
                this.UsuarioActual = new Usuario();

                this.txtID.TabStop = true;
            }
            else
            {
                this.UsuarioActual.ID = Convert.ToInt32(this.txtID.Text.Trim());
            }
            this.UsuarioActual.Nombre = this.txtNombre.Text.Trim();
            this.UsuarioActual.Apellido = this.txtApellido.Text.Trim();
            this.UsuarioActual.Email = this.txtEmail.Text.Trim();
            this.UsuarioActual.NombreUsuario = this.txtUsuario.Text.Trim();
            this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;
            this.UsuarioActual.State = (BusinessEntity.States)(int)modo;
            this.UsuarioActual.Clave = this.txtClave.Text.Trim();
        }

        private new void GuardarCambios()
        {
            MapearADatos();
            UsuarioLogic ul = new UsuarioLogic();
            ul.Save(UsuarioActual);
        }

        private new bool Validar()
        {
            List<string> incorrectFields = new List<string>();

            if (String.IsNullOrEmpty(this.txtID.Text.Trim())) {
                incorrectFields.Add("ID");
            };
            if (String.IsNullOrEmpty(this.txtNombre.Text.Trim())) {
                incorrectFields.Add("Nombre");
            };
            if (String.IsNullOrEmpty(this.txtApellido.Text.Trim())) {
                incorrectFields.Add("Apellido");
            };
            if (String.IsNullOrEmpty(this.txtUsuario.Text.Trim())) {
                incorrectFields.Add("Usuario");
            };

            bool claveOk = (this.txtClave.Text.Trim() == this.txtConfirmarClave.Text.Trim()) && this.txtClave.Text.Trim().Length >= 8;

            if (!claveOk)
            {
                incorrectFields.Add("Clave y/o confirmación");
            }
            
            bool validEmail = IsValidEmail(this.txtEmail.Text);

            if (!validEmail)
            {
                incorrectFields.Add("Email");
            }

            string toShow = String.Join(", ",incorrectFields.ToArray());
            if (!String.IsNullOrEmpty(toShow))
            {
                this.Notificar("Error", $"Los campos {toShow} son incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
            return true;
            }

        }

        private bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool ok = Validar();
            if (ok) { GuardarCambios(); this.Close(); }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}