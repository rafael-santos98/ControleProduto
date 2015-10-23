using System;
using System.Text;
using System.Data;
using System.Collections.Generic;

namespace SF_BLL
{
    public class oProduto : SF_DAL.oProduto
    {
        public DataTable CarregaProduto(int ncdProduto, string cdsProduto, Nullable<Boolean> BidAtivo, string ConnectionString)
        {
            try
            {
                SF_DAL.oProduto oMetodo = new SF_DAL.oProduto();
                DataTable dt = new DataTable();

                dt = oMetodo.CarregaProduto(ncdProduto, cdsProduto, BidAtivo, ConnectionString);

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
                SF_DAL.oProduto oMetodo = new SF_DAL.oProduto();
                DataTable dt = new DataTable();

                dt = oMetodo.IncluiAtualizaExcluiProduto(ncdProduto, cdsProduto, BidAtivo, Acao, ConnectionString);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}