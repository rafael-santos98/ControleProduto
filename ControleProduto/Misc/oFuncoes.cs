using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleProduto.Misc
{
    public class oFuncoes
    {
        public string CarregaSenhaPadrao()
        {
            oCriptografia oCriptografia = new oCriptografia();
            string cdsSenha =  oCriptografia.SHA512("admin");
            return cdsSenha;
        }
    }
}