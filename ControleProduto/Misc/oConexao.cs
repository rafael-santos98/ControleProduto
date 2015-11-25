using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleProduto.Misc
{
    public class oConexao
    {
        public string getConnection()
        {
            string strConn = string.Empty;           
            
            //strConn = "Server=localhost;User Id=root;Pwd=4921;Database=produto;";
            strConn = "Server=mysql06.redehost.com.br;Port=41890;User Id=rafaelrsantos;Pwd=System@1;Database=ProdEstoque;";
            
            return strConn;
        }
    }
}