﻿using Business.Entities;
using Business.Logic;
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
    public partial class Modulos : Form
    {
        public Modulos()
        {
            InitializeComponent();

            this.dgvModulos.ReadOnly = true;

            this.dgvModulos.AutoGenerateColumns = false;
            this.dgvModulos.AllowUserToAddRows = false;
            this.dgvModulos.AllowUserToDeleteRows = false;
            this.dgvModulos.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvModulos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            AddTextColumn("id", "ID", "ID");
            AddTextColumn("descripcion", "Descripcion", "Descripcion");

        }

        public void Listar()
        {
            ModulosLogic el = new ModulosLogic();
            this.dgvModulos.DataSource = el.GetAll();
        }

        private void AddTextColumn(string name, string headerText, string dataPropertyName)
        {
            DataGridViewTextBoxColumn newColumn = new DataGridViewTextBoxColumn();
            newColumn.Name = name;
            newColumn.HeaderText = headerText;
            newColumn.DataPropertyName = dataPropertyName;

            this.dgvModulos.Columns.Add(newColumn);
        }

        private void Modulos_Load(object sender, EventArgs e)
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
            ModuloDesktop ModuloDesktop = new ModuloDesktop(ApplicationForm.ModoForm.Alta);
            ModuloDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Modulo)this.dgvModulos.SelectedRows[0].DataBoundItem).ID;

            ModuloDesktop ModuloDesktop = new ModuloDesktop(ID, ApplicationForm.ModoForm.Baja);
            ModuloDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Modulo)this.dgvModulos.SelectedRows[0].DataBoundItem).ID;

            ModuloDesktop ModuloDesktop = new ModuloDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            ModuloDesktop.ShowDialog();
            this.Listar();
        }
    }
}
