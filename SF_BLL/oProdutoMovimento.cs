using System;
using System.Text;
using System.Data;
using System.Collections.Generic;

namespace SF_BLL
{
    public class oProdutoMovimento : SF_DAL.oProdutoMovimento
    {
        public DataTable CarregaProdutoMovimento(int ncdProdutoMovimento, Nullable<DateTime> DtEntrada, Nullable<DateTime> DtSaida, int ncdProduto, string cdsTipoMovimento, string ConnectionString)
        {
            try
            {
                SF_DAL.oProdutoMovimento oMetodo = new SF_DAL.oProdutoMovimento();
                DataTable dt = new DataTable();

                dt = oMetodo.CarregaProdutoMovimento(ncdProdutoMovimento, DtEntrada, DtSaida, ncdProduto, cdsTipoMovimento, ConnectionString);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable IncluiProdutoMovimento(int ncdProduto, float nvlQuantidade, string cdsObservacao, string cdsTipoMovimento, string ConnectionString) 
        {
            try
            {
                SF_DAL.oProdutoMovimento oMetodo = new SF_DAL.oProdutoMovimento();
                DataTable dt = new DataTable();

                dt = oMetodo.IncluiProdutoMovimento(ncdProduto, nvlQuantidade, cdsObservacao, cdsTipoMovimento, ConnectionString);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}