using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace SF_DAL
{
    public class oProdutoMovimento
    {
        public DataTable CarregaProdutoMovimento(int ncdProdutoMovimento, Nullable<DateTime> DtEntrada, Nullable<DateTime> DtSaida, int ncdProduto, string cdsTipoMovimento, string ConnectionString)
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

                mysqlCmd = new MySqlCommand("SP_Cadastro_ProdutoMovimentoCarrega");
                mysqlCmd.Parameters.AddWithValue("_NCDPRODUTOMOVIMENTO", ncdProdutoMovimento);
                mysqlCmd.Parameters.AddWithValue("_DTENTRADA", DtEntrada);
                mysqlCmd.Parameters.AddWithValue("_DTSAIDA", DtSaida);
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

        public DataTable IncluiProdutoMovimento(int ncdProdutoMovimento, Nullable<DateTime> DtEntrada, Nullable<DateTime> DtSaida, int ncdProduto, string cdsTipoMovimento, string ConnectionString) 
        { 
        
        }
    }
}