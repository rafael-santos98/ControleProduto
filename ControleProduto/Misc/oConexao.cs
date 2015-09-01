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
            strConn = "server=localhost;User Id=root;password=4921;database=produto;";
            return strConn;
        }
    }
}