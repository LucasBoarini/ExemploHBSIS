using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Models;
using DAL;

namespace GUI
{
    public partial class frmCategoria : Form
    {
        public frmCategoria()
        {
            InitializeComponent();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            Categoria objCategoria = new Categoria();
            objCategoria.DsCategoria = txtDescricao.Text;

            CategoriaDAL cDAL = new CategoriaDAL();
            cDAL.InserirCategoria(objCategoria);

            LimparCampos();
            MessageBox.Show("Categoria adicionada com sucesso.");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int codCategoria = Convert.ToInt32(txtCodigo.Text);

            Categoria objCategoria = new Categoria();
            CategoriaDAL cDAL = new CategoriaDAL();

            objCategoria = cDAL.SelecionarPeloCodigo(codCategoria);

            if(objCategoria != null)
            {
                txtDescricao.Text = objCategoria.DsCategoria;

                btnAtualizar.Enabled = true;
                btnExcluir.Enabled = true;
                btnCancelar.Enabled = true;
                txtCodigo.Enabled = false;
                btnBuscar.Enabled = false;
            }
            else
            {
                LimparCampos();
                MessageBox.Show("Código não encontrado.");
            }
        }

        private void CarregarCategorias()
        {
            CategoriaDAL cDAL = new CategoriaDAL();
            dgvCategoria.DataSource = cDAL.SelecionarTodos();
        }

        private void frmCategoria_Load(object sender, EventArgs e)
        {
            CarregarCategorias();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Categoria objCategoria = new Categoria();

            objCategoria.CdCategoria = Convert.ToInt32(txtCodigo.Text);
            objCategoria.DsCategoria = txtDescricao.Text;

            CategoriaDAL cDAL = new CategoriaDAL();
            cDAL.AtualizarCategoria(objCategoria);

            LimparCampos();
            MessageBox.Show("Atualizado com Sucesso.");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int codCategoria = Convert.ToInt32(txtCodigo.Text);

            CategoriaDAL cDAL = new CategoriaDAL();

            cDAL.ExcluirCategoria(codCategoria);

            LimparCampos();
            MessageBox.Show("Categoria Excluida com Sucesso.");
        }

        private void LimparCampos()
        {
            btnAtualizar.Enabled = false;
            btnExcluir.Enabled = false;
            btnCancelar.Enabled = false;
            txtCodigo.Enabled = true;
            btnBuscar.Enabled = true;

            txtCodigo.Text = string.Empty;
            txtDescricao.Text = string.Empty;

            CarregarCategorias();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }
    }
}
