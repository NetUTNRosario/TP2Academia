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
using Business.Logic;


namespace UI.Desktop
{
    public partial class Especialidades : Form
    {
        public Especialidades()
        {
            InitializeComponent();

            this.dgvEspecialidades.ReadOnly = true;

            this.dgvEspecialidades.AutoGenerateColumns = false;
            this.dgvEspecialidades.AllowUserToAddRows = false;
            this.dgvEspecialidades.AllowUserToDeleteRows = false;
            this.dgvEspecialidades.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvEspecialidades.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            AddTextColumn("id", "ID", "ID");
            AddTextColumn("descripcion", "Descripcion", "Descripcion");

        }

        public void Listar()
        {
            EspecialidadesLogic el = new EspecialidadesLogic();
            this.dgvEspecialidades.DataSource = el.GetAll();
        }

        private void AddTextColumn (string name, string headerText, string dataPropertyName)
        {
            DataGridViewTextBoxColumn newColumn = new DataGridViewTextBoxColumn();
            newColumn.Name = name;
            newColumn.HeaderText = headerText;
            newColumn.DataPropertyName = dataPropertyName;

            this.dgvEspecialidades.Columns.Add(newColumn);
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            UsuarioDesktop usuarioDesk = new UsuarioDesktop( ApplicationForm.ModoForm.Alta);
            usuarioDesk.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Usuario)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;

            UsuarioDesktop usuarioDesk = new UsuarioDesktop(ID,ApplicationForm.ModoForm.Baja);
            usuarioDesk.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Usuario)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;

            UsuarioDesktop usuarioDesk = new UsuarioDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            usuarioDesk.ShowDialog();
            this.Listar();
        }
    }
}
