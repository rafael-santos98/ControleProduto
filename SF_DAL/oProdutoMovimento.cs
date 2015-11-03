using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace SF_DAL
{
    public class oProdutoMovimento
    {
        public DataTable CarregaProdutoMovimento(int ncdProdutoMovimento, Nullable<DateTime> dtMovimentoDe, Nullable<DateTime> dtMovimentoAte, int ncdProduto, string cdsTipoMovimento, string ConnectionString)
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

                mysqlCmd = new MySqlCommand("SP_Movimento_Produto_Carrega");
                mysqlCmd.Parameters.AddWithValue("_NCDPRODUTOMOVIMENTO", ncdProdutoMovimento);
                mysqlCmd.Parameters.AddWithValue("_DTMOVIMENTODE", dtMovimentoDe != null ? dtMovimentoDe : (object)DBNull.Value);
                mysqlCmd.Parameters.AddWithValue("_DTMOVIMENTOATE", dtMovimentoAte != null ? dtMovimentoAte : (object)DBNull.Value);
                mysqlCmd.Parameters.AddWithValue("_NCDPRODUTO", ncdProduto);
                mysqlCmd.Parameters.AddWithValue("_CDSTIPOMOVIMENTO", cdsTipoMovimento);

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

        public DataTable IncluiProdutoMovimento(int ncdProduto, float nqtProdutoMovimento, string cdsObservacao, string cdsTipoMovimento, string ConnectionString)
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

                mysqlCmd = new MySqlCommand("SP_Movimento_Produto_Inclui");
                mysqlCmd.Parameters.AddWithValue("_NCDPRODUTO", ncdProduto);
                mysqlCmd.Parameters.AddWithValue("_NQTPRODUTOMOVIMENTO", nqtProdutoMovimento);
                mysqlCmd.Parameters.AddWithValue("_CDSOBSERVACAO", cdsObservacao);
                mysqlCmd.Parameters.AddWithValue("_CDSTIPOMOVIMENTO", cdsTipoMovimento);

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