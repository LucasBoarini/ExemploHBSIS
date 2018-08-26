using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace GUI
{
    public partial class frmTesteExcecao : Form
    {
        public frmTesteExcecao()
        {
            InitializeComponent();
        }

        private void btnTeste_Click(object sender, EventArgs e)
        {
            string palavra = "Batata";
            int numero;

            try
            {
                numero = Convert.ToInt32(palavra);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Aconteceu um erro. " + ex.Message);
            }
        }

        private void btnTeste2_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=localhost; Initial Catalog=BDSistemaExemplo2; User ID=sa; Password=3s4mc";

            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                string sql = "INSERT INTO Jogos VALUES (@nmJogo)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nmJogo", txtJogo.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Inserido com Sucesso.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    MessageBox.Show("Conexão fechada.");
                }
            }

            
        }
    }
}
