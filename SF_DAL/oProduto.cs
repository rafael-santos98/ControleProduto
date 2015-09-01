using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace SF_DAL
{
    public class oProduto
    {
        public DataTable CarregaProduto(int ncdProduto, string cdsProduto, int BidAtivo, string ConnectionString)
        {
            try
            {

                StringBuilder strSQL = new StringBuilder();
                MySqlConnection conn = new MySqlConnection();
                MySqlCommand mysqlCmd = new MySqlCommand();
                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dt = new DataTable();

                conn = new MySqlConnection(ConnectionString);
                conn.Open();

                mysqlCmd = new MySqlCommand("SP_Cadastro_ProdutoCarrega");
                mysqlCmd.Parameters.AddWithValue("_NCDPRODUTO", ncdProduto);
                mysqlCmd.Parameters.AddWithValue("_CDSPRODUTO", cdsProduto);
                mysqlCmd.Parameters.AddWithValue("_BIDATIVO", BidAtivo);

                mysqlCmd.Connection = conn;
                mysqlCmd.CommandTimeout = 500;
                mysqlCmd.CommandType = CommandType.StoredProcedure;

                da = new MySqlDataAdapter(mysqlCmd);
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable IncluiAtualizaExcluiProduto(int ncdProduto, string cdsProduto, bool BidAtivo, int Acao, string ConnectionString)
        {
            try
            {

                StringBuilder strSQL = new StringBuilder();
                MySqlConnection conn = new MySqlConnection();
                MySqlCommand mysqlCmd = new MySqlCommand();
                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dt = new DataTable();

                conn = new MySqlConnection(ConnectionString);
                conn.Open();

                mysqlCmd = new MySqlCommand("SP_Cadastro_ProdutoIncluiAtualizaExclui");
                mysqlCmd.Parameters.AddWithValue("_NCDPRODUTO", ncdProduto);
                mysqlCmd.Parameters.AddWithValue("_CDSPRODUTO", cdsProduto);
                mysqlCmd.Parameters.AddWithValue("_BIDATIVO", BidAtivo);
                mysqlCmd.Parameters.AddWithValue("_ACAO", Acao);

                mysqlCmd.Connection = conn;
                mysqlCmd.CommandTimeout = 500;
                mysqlCmd.CommandType = CommandType.StoredProcedure;

                da = new MySqlDataAdapter(mysqlCmd);
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}