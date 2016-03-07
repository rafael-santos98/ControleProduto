using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace ControleProduto.Misc
{
    public class oConexao
    {
        public string getConnection()
        {
            string strConn = string.Empty;           
            
            strConn = "Server=localhost;User Id=root;Pwd=1234;Database=produto;";
            //strConn = "Server=mysql06.redehost.com.br;Port=41890;User Id=rafaelrsantos;Pwd=System@1;Database=ProdEstoque;";
            //strConn = "Server=mysql06.redehost.com.br;Port=3306;User Id=rafaelrsantos;Pwd=System@1;Database=ProdEstoque;";
            //strConn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            return strConn;
        }
    }
}