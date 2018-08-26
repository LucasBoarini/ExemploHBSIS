using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace GUI
{
    public partial class frmCadastroPessoa : Form
    {
        public frmCadastroPessoa()
        {
            InitializeComponent();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            Pessoa objPessoa = new Pessoa();
            objPessoa.Nome = txtNome.Text;
            objPessoa.DtNascimento = Convert.ToDateTime(dtpDtNacimento.Text);
            objPessoa.Email = txtEmail.Text;
            if (rbtnMasculino.Checked)
            {
                objPessoa.Sexo = "M";
            }
            else
            {
                objPessoa.Sexo = "F";
            }
            objPessoa.EstadoCivil = cbxEstadoCivil.Text;
            objPessoa.RecebeEmail = ckbEmail.Checked;
            objPessoa.RecebeSMS = ckbSMS.Checked;
            


            //Enviar para camada de banco de dados
            PessoaDAL pDAL = new PessoaDAL();
            pDAL.InserirPessoa(objPessoa);

            Limpar();
            MessageBox.Show("Adicionado com sucesso.");
        }

        private void btnPesquisaPessoa_Click(object sender, EventArgs e)
        {
            string nome = txtPesquisa.Text;

            PessoaDAL pDAL = new PessoaDAL();
            dgvPessoas.DataSource = pDAL.Pesquisar(nome);
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Pessoa objPessoa = new Pessoa();

            objPessoa.CdPessoa = Convert.ToInt32(txtCodigo.Text);
            objPessoa.Nome = txtNome.Text;
            objPessoa.DtNascimento = Convert.ToDateTime(dtpDtNacimento.Text);
            objPessoa.Email = txtEmail.Text;
            //if normal
            //if (rbtnMasculino.Checked)
            //{
            //    objPessoa.Sexo = "M";
            //}
            //else
            //{
            //    objPessoa.Sexo = "F";
            //}
            //if muito louco
            objPessoa.Sexo = (rbtnMasculino.Checked ? "M" : "F");

            objPessoa.EstadoCivil = cbxEstadoCivil.Text;
            objPessoa.RecebeEmail = ckbEmail.Checked;
            objPessoa.RecebeSMS = ckbSMS.Checked;

            PessoaDAL pDAL = new PessoaDAL();
            pDAL.Atualizar(objPessoa);

            Limpar();
            MessageBox.Show("Atualizado com sucesso.");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int cdPessoa = Convert.ToInt32(txtCodigo.Text);

            PessoaDAL pDAL = new PessoaDAL();
            Pessoa objPessoa = pDAL.SelecionarPessoaPeloCodigo(cdPessoa);

            if(objPessoa != null)
            {
                btnAtualizar.Enabled = true;
                btnExcluir.Enabled = true;

                txtNome.Text = objPessoa.Nome;
                dtpDtNacimento.Value = objPessoa.DtNascimento;
                txtEmail.Text = objPessoa.Email;
                rbtnMasculino.Checked = objPessoa.Sexo == "M";
                rbtnFeminino.Checked = objPessoa.Sexo == "F";
                cbxEstadoCivil.Text = objPessoa.EstadoCivil;
                ckbEmail.Checked = objPessoa.RecebeEmail;
                ckbSMS.Checked = objPessoa.RecebeSMS;
            }
            else
            {
                MessageBox.Show("Pessoa não encontrada.");
            }  
        }

        private void frmCadastroPessoa_Load(object sender, EventArgs e)
        {
            CarregarPessoas();
            cbxEstadoCivil.SelectedIndex = 0;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(txtCodigo.Text);

            PessoaDAL pDAL = new PessoaDAL();
            pDAL.Excluir(codigo);

            Limpar();
            MessageBox.Show("Pessoa excluida com sucesso.");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void Limpar()
        {
            txtCodigo.Text = string.Empty;
            txtNome.Text = string.Empty;
            dtpDtNacimento. Value = DateTime.Today;
            txtEmail.Text = string.Empty;
            cbxEstadoCivil.SelectedIndex = 0;
            ckbEmail.Checked = false;
            ckbSMS.Checked = false;

            btnAtualizar.Enabled = false;
            btnExcluir.Enabled = false;

            CarregarPessoas();
        }

        private void CarregarPessoas()
        {
            PessoaDAL pDAL = new PessoaDAL();
            dgvPessoas.DataSource = pDAL.SelecionarTodos();
        }
    }
}
