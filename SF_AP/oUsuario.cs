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

        public DataTable CarregaUsuario(int ncdUsuario, string cdsUsuario, string cnmUsuario, Nullable<Boolean> bidAtivo, string ConnectionString)
        {
            try
            {

                SF_BLL.oUsuario oMetodo = new SF_BLL.oUsuario();
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

                SF_BLL.oUsuario oMetodo = new SF_BLL.oUsuario();
                DataTable dt = new DataTable();

                dt = oMetodo.IncluiAtualizaUsuario(ncdUsuario, cdsUsuario, cnmUsuario, bidAtivo, Acao, ConnectionString);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable AtualizaUsuarioSenha(int ncdUsuario, string cnmUsuario, string cdsSenha, string ConnectionString)
        {
            try
            {

                SF_BLL.oUsuario oMetodo = new SF_BLL.oUsuario();
                DataTable dt = new DataTable();

                dt = oMetodo.AtualizaUsuarioSenha(ncdUsuario, cnmUsuario, cdsSenha, ConnectionString);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable CarregaUsuarioPermissaoAcesso(string cnmUsuario, int Acao, string ConnectionString)
        {
            try
            {

                SF_BLL.oUsuario oMetodo = new SF_BLL.oUsuario();
                DataTable dt = new DataTable();

                dt = oMetodo.CarregaUsuarioPermissaoAcesso(cnmUsuario, Acao, ConnectionString);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable IncluiExcluiPermisssaoAcessoUsuario(int ncdPermissaoAcesso, string cnmUsuario, int ncdFuncionalidade, int ncdSubFuncionalide, int Acao, string ConnectionString)
        {
            try
            {

                SF_BLL.oUsuario oMetodo = new SF_BLL.oUsuario();
                DataTable dt = new DataTable();

                dt = oMetodo.IncluiExcluiPermisssaoAcessoUsuario(ncdPermissaoAcesso, cnmUsuario, ncdFuncionalidade, ncdSubFuncionalide, Acao, ConnectionString);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}