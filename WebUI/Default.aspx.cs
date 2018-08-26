using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using DAL;

namespace WebUI
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadLivros();
            }
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            Livro objLivro = new Livro();

            objLivro.NomeLivro = txtNomeLivro.Text;
            objLivro.NomeAutor = txtAutorLivro.Text;

            LivroDAL lDAL = new LivroDAL();
            lDAL.InsertLivro(objLivro);

            lblMensagem.Text = "Livro adicionado com sucesso.";
            Clear();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            int idLivro = Convert.ToInt32(txtID.Text);

            LivroDAL lDAL = new LivroDAL();

            Livro objLivro = lDAL.SelectLivroPerCode(idLivro);
            if(objLivro != null)
            {
                txtNomeLivro.Text = objLivro.NomeLivro;
                txtAutorLivro.Text = objLivro.NomeAutor;

                lblMensagem.Text = string.Empty;
            }
            else
            {
                Clear();
                lblMensagem.Text = "O livro não foi encontrado";
            }

        }

        private void LoadLivros()
        {
            LivroDAL lDAL = new LivroDAL();

            gdvLivros.DataSource = lDAL.SelectAll();
            gdvLivros.DataBind();
        }

        private void Clear()
        {
            txtAutorLivro.Text = string.Empty;
            txtNomeLivro.Text = string.Empty;
            txtID.Text = string.Empty;

            LoadLivros();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Livro objLivro = new Livro();

            objLivro.IdLivro = Convert.ToInt32(txtID.Text);
            objLivro.NomeLivro = txtNomeLivro.Text;
            objLivro.NomeAutor = txtAutorLivro.Text;

            LivroDAL lDAL = new LivroDAL();
            lDAL.Update(objLivro);

            lblMensagem.Text = "Livro editado com sucesso.";
            Clear();
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            int idLivro = Convert.ToInt32(txtID.Text);

            LivroDAL lDAL = new LivroDAL();
            lDAL.Delete(idLivro);

            lblMensagem.Text = "Livro excluido com sucesso.";
            Clear();
        }
    }
}