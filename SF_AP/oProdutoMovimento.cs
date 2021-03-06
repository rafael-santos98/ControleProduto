﻿using System;
using System.Text;
using System.Data;
using System.Collections.Generic;

namespace SF_AP
{
    public class oProdutoMovimento : SF_BLL.oProduto
    {
        public DataTable CarregaProdutoMovimento(int ncdProdutoMovimento, Nullable<DateTime> dtMovimentoDe, Nullable<DateTime> dtMovimentoAte, int ncdProduto, string cdsTipoMovimento, string ConnectionString)
        {
            try
            {
                SF_BLL.oProdutoMovimento oMetodo = new SF_BLL.oProdutoMovimento();
                DataTable dt = new DataTable();

                dt = oMetodo.CarregaProdutoMovimento(ncdProdutoMovimento, dtMovimentoDe, dtMovimentoAte, ncdProduto, cdsTipoMovimento, ConnectionString);

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
                SF_BLL.oProdutoMovimento oMetodo = new SF_BLL.oProdutoMovimento();
                DataTable dt = new DataTable();

                dt = oMetodo.IncluiProdutoMovimento(ncdProduto, nqtProdutoMovimento, cdsObservacao, cdsTipoMovimento, ConnectionString);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}