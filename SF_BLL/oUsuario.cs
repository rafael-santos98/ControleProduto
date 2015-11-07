using System;
using System.Text;
using System.Data;
using System.Collections.Generic;

namespace SF_BLL
{
    public class oUsuario
    {
        public DataTable CarregaUsuarioAcesso(string cnmUsuario, string cdsSenha, string ConnectionString)
        {
            try
            {

                SF_DAL.oUsuario oMetodo = new SF_DAL.oUsuario();
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

                SF_DAL.oUsuario oMetodo = new SF_DAL.oUsuario();
                DataTable dt = new DataTable();

                dt = oMetodo.CarregaUsuarioAcessoPagina(cnmUsuario, ncdFuncionalidade, ncdSubFuncionalidade, ConnectionString);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable CarregaUsuario(int ncdUsuario, string cdsUsuario, string cnmUsuario, Nullable<Boolean> bidAtivo, string ConnectionString)
        {
            try
            {

                SF_DAL.oUsuario oMetodo = new SF_DAL.oUsuario();
                DataTable dt = new DataTable();

                dt = oMetodo.CarregaUsuario(ncdUsuario, cdsUsuario, cnmUsuario, bidAtivo, ConnectionString);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable IncluiAtualizaUsuario(int ncdUsuario, string cdsUsuario, string cnmUsuario, bool bidAtivo, int Acao, string ConnectionString)
        {
            try
            {

                SF_DAL.oUsuario oMetodo = new SF_DAL.oUsuario();
                DataTable dt = new DataTable();

                dt = oMetodo.IncluiAtualizaUsuario(ncdUsuario, cdsUsuario, cnmUsuario, bidAtivo, Acao, ConnectionString);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}