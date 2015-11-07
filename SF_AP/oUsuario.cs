using System;
using System.Text;
using System.Data;
using System.Collections.Generic;

namespace SF_AP
{
    public class oUsuario
    {
        public DataTable CarregaUsuarioAcesso(string cnmUsuario, string cdsSenha, string ConnectionString)
        {
            try
            {

                SF_BLL.oUsuario oMetodo = new SF_BLL.oUsuario();
                DataTable dt = new DataTable();

                dt = oMetodo.CarregaUsuarioAcesso(cnmUsuario, cdsSenha, ConnectionString);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable CarregaUsuarioAcessoPagina(string cnmUsuario, int ncdFuncionalidade, int ncdSubFuncionalidade, string ConnectionString)
        {
            try
            {

                SF_BLL.oUsuario oMetodo = new SF_BLL.oUsuario();
                DataTable dt = new DataTable();

                dt = oMetodo.CarregaUsuarioAcessoPagina(cnmUsuario, ncdFuncionalidade, ncdSubFuncionalidade, ConnectionString);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}