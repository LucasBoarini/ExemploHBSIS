using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Data.SqlClient;


namespace DAL
{
    public class LivroDAL
    {
        string connectionString = "Data Source=localhost; Initial Catalog=BDLivraria; User ID=Lucas;Password=P@ssw0rd";

        public void InsertLivro(Livro objLivro)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            string sql = "INSERT INTO TblLivros VALUES (@nomelivro, @nomeautor)";
            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@nomelivro", objLivro.NomeLivro);
            cmd.Parameters.AddWithValue("@nomeautor", objLivro.NomeAutor);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public Livro SelectLivroPerCode(int idLivro)
        {
            Livro objLivro = null;

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            string sql = "SELECT * FROM TblLivros WHERE IdLivro = @idlivro";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@idlivro", idLivro);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                if (dr.Read())
                {
                    objLivro = new Livro();
                    objLivro.IdLivro = idLivro;
                    objLivro.NomeLivro = dr["NomeLivro"].ToString();
                    objLivro.NomeAutor = dr["NomeAutor"].ToString();
                }
            }

            conn.Close();

            return objLivro;
        }

        public void Update(Livro objLivro)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            string sql = "UPDATE TblLivros SET NomeLivro = @nomelivro, NomeAutor = @nomeautor WHERE IdLivro = @idlivro";
            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@idlivro", objLivro.IdLivro);
            cmd.Parameters.AddWithValue("@nomelivro", objLivro.NomeLivro);
            cmd.Parameters.AddWithValue("@nomeautor", objLivro.NomeAutor);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Delete(int idLivro)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            string sql = "DELETE FROM TblLivros WHERE IdLivro = @idlivro";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@idlivro", idLivro);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public List<Livro> SelectAll()
        {
            List<Livro> listLivros = new List<Livro>();

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            string sql = "SELECT * FROM TblLivros";
            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                Livro objLivro;
                while (dr.Read())
                {
                    objLivro = new Livro();
                    objLivro.IdLivro = Convert.ToInt32(dr["IdLivro"]);
                    objLivro.NomeLivro = dr["NomeLivro"].ToString();
                    objLivro.NomeAutor = dr["NomeAutor"].ToString();

                    listLivros.Add(objLivro);
                }
            }

            conn.Close();
            return listLivros;
        }
    }
}
