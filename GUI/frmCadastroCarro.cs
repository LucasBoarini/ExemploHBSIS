using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using DAL;

namespace GUI
{
    public partial class frmCadastroCarro : Form
    {
        public frmCadastroCarro()
        {
            InitializeComponent();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            Carro objCarro = new Carro();
            objCarro.DsMarca = txtMarca.Text;
            objCarro.DsModelo = txtModelo.Text;
            objCarro.DsCor = txtCor.Text;
            objCarro.Ano = Convert.ToInt32(txtAno.Text);

            //Enviar para camada de banco de dados
            CarroDAL cDAL = new CarroDAL();
            cDAL.InserirCarro(objCarro);           

            MessageBox.Show("Adicionado com sucesso");

            LimparCampos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int cdCarro = Convert.ToInt32(txtCodigo.Text);

            CarroDAL cDAL = new CarroDAL();
            Carro objCarro = cDAL.SelecionarCarroPeloCodigo(cdCarro);

            if (objCarro != null)
            {
                txtMarca.Text = objCarro.DsMarca;
                txtModelo.Text = objCarro.DsModelo;
                txtCor.Text = objCarro.DsCor;
                txtAno.Text = objCarro.Ano.ToString();

                txtCodigo.Enabled = false;
                btnBuscar.Enabled = false;
                btnAdicionar.Enabled = false;
                btnAtualizar.Enabled = true;
                btnExcluir.Enabled = true;
            }
            else
            {
                MessageBox.Show("Carro não encontrado.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }
 
        private void LimparCampos()
        {
            txtCodigo.Text = string.Empty;
            txtMarca.Text = string.Empty;
            txtModelo.Text = string.Empty;
            txtCor.Text = string.Empty;
            txtAno.Text = string.Empty;

            txtCodigo.Enabled = true;
            btnBuscar.Enabled = true;
            btnAdicionar.Enabled = true;
            btnAtualizar.Enabled = false;
            btnExcluir.Enabled = false;

            CarregarCarros();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Carro objCarro = new Carro();

            objCarro.CdCarro = Convert.ToInt32(txtCodigo.Text);
            objCarro.DsMarca = txtMarca.Text;
            objCarro.DsModelo = txtModelo.Text;
            objCarro.DsCor = txtCor.Text;
            objCarro.Ano = Convert.ToInt32(txtAno.Text);

            CarroDAL cDAL = new CarroDAL();
            cDAL.Atualizar(objCarro);

            MessageBox.Show("Carro atualizado com sucesso.");

            LimparCampos();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(txtCodigo.Text);

            CarroDAL cDAL = new CarroDAL();
            cDAL.Excluir(codigo);

            LimparCampos();
            MessageBox.Show("Carro excluido com sucesso.");
        }

        private void CarregarCarros()
        {
            CarroDAL cDAL = new CarroDAL();
            dgvCarros.DataSource = cDAL.SelecionarTodos();
        }

        private void frmCadastroCarro_Load(object sender, EventArgs e)
        {
            CarregarCarros();
        }
    }
}
