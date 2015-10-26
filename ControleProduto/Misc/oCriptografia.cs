using System;
using System.Text;
using System.Security.Cryptography;
using System.Linq;
using System.Drawing;
using System.Data;
using System.Configuration;
using System.ComponentModel;
using System.Collections.Generic;

namespace ControleProduto.Misc
{
    public class oCriptografia
    {
        public string SHA512(string valor)
        {
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] HashValue, MessageBytes = UE.GetBytes(valor);
            SHA512Managed SHhash = new SHA512Managed();
            string strHex = "";

            HashValue = SHhash.ComputeHash(MessageBytes);

            foreach (byte b in HashValue)
            {
                strHex += String.Format("{0:x2}", b);
            }
            return strHex;
        }
    }
}