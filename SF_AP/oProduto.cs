﻿using System;
using System.Text;
using System.Data;
using System.Collections.Generic;

namespace SF_AP
{
    public class oProduto : SF_BLL.oProduto
    {
        public DataTable CarregaProduto(int ncdProduto, string cdsProduto, Nullable<Boolean> BidAtivo, string ConnectionString)
        {
            try
            {
                SF_BLL.oProduto oMetodo = new SF_BLL.oProduto();
                DataTable dt = new DataTable();

                dt = oMetodo.CarregaProduto(ncdProduto, cdsProduto, BidAtivo, ConnectionString);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable IncluiAtualizaProduto(int ncdProduto, string cdsProduto, bool BidAtivo, int Acao, string ConnectionString)
        {
            try
            {
                SF_BLL.oProduto oMetodo = new SF_BLL.oProduto();
                DataTable dt = new DataTable();

                dt = oMetodo.IncluiAtualizaProduto(ncdProduto, cdsProduto, BidAtivo, Acao, ConnectionString);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}