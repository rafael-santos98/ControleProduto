using System;
using System.Text;
using System.Data;
using System.Collections.Generic;

namespace SF_BLL
{
    public class oUsuario
    {
        public DataTable CarregaUsuarioLogin(string cnmUsuario, string cdsSenha, string ConnectionString)
        {
            try
            {

                SF_DAL.oUsuario oMetodo = new SF_DAL.oUsuario();
                DataTable dt = new DataTable();

                dt = oMetodo.CarregaUsuarioLogin(cnmUsuario, cdsSenha, ConnectionString);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}