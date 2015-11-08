using System;
using System.Text;
using System.Data;
using System.Data.SqlTypes;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace SF_DAL
{
    public class oUsuario
    {
        public DataTable CarregaUsuarioAcesso(string cnmUsuario, string cdsSenha, string ConnectionString)
        {
            try
            {

                StringBuilder strSQL = new StringBuilder();
                MySqlConnection conn = new MySqlConnection();
                MySqlCommand mysqlCmd = new MySqlCommand();
                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dt = new DataTable();

                conn = new MySqlConnection(ConnectionString);
                conn.Open();

                mysqlCmd = new MySqlCommand("SP_SG_UsuarioAcesso_Carrega");
                mysqlCmd.Parameters.AddWithValue("_CNMUSUARIO", cnmUsuario);
                mysqlCmd.Parameters.AddWithValue("_CDSSENHA", cdsSenha);

                mysqlCmd.Connection = conn;
                mysqlCmd.CommandTimeout = 500;
                mysqlCmd.CommandType = CommandType.StoredProcedure;

                da = new MySqlDataAdapter(mysqlCmd);
                da.Fill(dt);

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

                StringBuilder strSQL = new StringBuilder();
                MySqlConnection conn = new MySqlConnection();
                MySqlCommand mysqlCmd = new MySqlCommand();
                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dt = new DataTable();

                conn = new MySqlConnection(ConnectionString);
                conn.Open();

                mysqlCmd = new MySqlCommand("SP_SG_UsuarioAcessoPagina_Carrega");
                mysqlCmd.Parameters.AddWithValue("_CNMUSUARIO", cnmUsuario);
                mysqlCmd.Parameters.AddWithValue("_NCDFUNCIONALIDADE", ncdFuncionalidade > 0 ? ncdFuncionalidade : (object)DBNull.Value);
                mysqlCmd.Parameters.AddWithValue("_NCDSUBFUNCIONALIDADE", ncdSubFuncionalidade > 0 ? ncdSubFuncionalidade : (object)DBNull.Value);

                mysqlCmd.Connection = conn;
                mysqlCmd.CommandTimeout = 500;
                mysqlCmd.CommandType = CommandType.StoredProcedure;

                da = new MySqlDataAdapter(mysqlCmd);
                da.Fill(dt);

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

                StringBuilder strSQL = new StringBuilder();
                MySqlConnection conn = new MySqlConnection();
                MySqlCommand mysqlCmd = new MySqlCommand();
                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dt = new DataTable();

                conn = new MySqlConnection(ConnectionString);
                conn.Open();

                mysqlCmd = new MySqlCommand("SP_SG_Usuario_Carrega");
                mysqlCmd.Parameters.AddWithValue("_NCDUSUARIO", ncdUsuario);
                mysqlCmd.Parameters.AddWithValue("_CDSUSUARIO", cdsUsuario);
                mysqlCmd.Parameters.AddWithValue("_CNMUSUARIO", cnmUsuario);
                mysqlCmd.Parameters.AddWithValue("_BIDATIVO", bidAtivo != null ? bidAtivo : (object)DBNull.Value);

                mysqlCmd.Connection = conn;
                mysqlCmd.CommandTimeout = 500;
                mysqlCmd.CommandType = CommandType.StoredProcedure;

                da = new MySqlDataAdapter(mysqlCmd);
                da.Fill(dt);

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

                StringBuilder strSQL = new StringBuilder();
                MySqlConnection conn = new MySqlConnection();
                MySqlCommand mysqlCmd = new MySqlCommand();
                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dt = new DataTable();

                conn = new MySqlConnection(ConnectionString);
                conn.Open();

                mysqlCmd = new MySqlCommand("SP_SG_Usuario_IncluiAtualiza");
                mysqlCmd.Parameters.AddWithValue("_NCDUSUARIO", ncdUsuario);
                mysqlCmd.Parameters.AddWithValue("_CDSUSUARIO", cdsUsuario);
                mysqlCmd.Parameters.AddWithValue("_CNMUSUARIO", cnmUsuario);
                mysqlCmd.Parameters.AddWithValue("_BIDATIVO", bidAtivo);
                mysqlCmd.Parameters.AddWithValue("_ACAO", Acao);

                mysqlCmd.Connection = conn;
                mysqlCmd.CommandTimeout = 500;
                mysqlCmd.CommandType = CommandType.StoredProcedure;

                da = new MySqlDataAdapter(mysqlCmd);
                da.Fill(dt);

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

                StringBuilder strSQL = new StringBuilder();
                MySqlConnection conn = new MySqlConnection();
                MySqlCommand mysqlCmd = new MySqlCommand();
                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dt = new DataTable();

                conn = new MySqlConnection(ConnectionString);
                conn.Open();

                mysqlCmd = new MySqlCommand("SP_SG_UsuarioSenha_Atualiza");
                mysqlCmd.Parameters.AddWithValue("_NCDUSUARIO", ncdUsuario);
                mysqlCmd.Parameters.AddWithValue("_CNMUSUARIO", cnmUsuario);
                mysqlCmd.Parameters.AddWithValue("_CDSSENHA", cdsSenha);

                mysqlCmd.Connection = conn;
                mysqlCmd.CommandTimeout = 500;
                mysqlCmd.CommandType = CommandType.StoredProcedure;

                da = new MySqlDataAdapter(mysqlCmd);
                da.Fill(dt);

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

                StringBuilder strSQL = new StringBuilder();
                MySqlConnection conn = new MySqlConnection();
                MySqlCommand mysqlCmd = new MySqlCommand();
                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dt = new DataTable();

                conn = new MySqlConnection(ConnectionString);
                conn.Open();

                mysqlCmd = new MySqlCommand("SP_SG_UsuarioPermissaoAcesso_Carrega");
                mysqlCmd.Parameters.AddWithValue("_CNMUSUARIO", cnmUsuario);
                mysqlCmd.Parameters.AddWithValue("_ACAO", Acao);

                mysqlCmd.Connection = conn;
                mysqlCmd.CommandTimeout = 500;
                mysqlCmd.CommandType = CommandType.StoredProcedure;

                da = new MySqlDataAdapter(mysqlCmd);
                da.Fill(dt);

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

                StringBuilder strSQL = new StringBuilder();
                MySqlConnection conn = new MySqlConnection();
                MySqlCommand mysqlCmd = new MySqlCommand();
                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dt = new DataTable();

                conn = new MySqlConnection(ConnectionString);
                conn.Open();

                mysqlCmd = new MySqlCommand("SP_SG_UsuarioPermissaoAcesso_IncluiExclui");
                mysqlCmd.Parameters.AddWithValue("_NCDPERMISSAOACESSO", ncdPermissaoAcesso);
                mysqlCmd.Parameters.AddWithValue("_CNMUSUARIO", cnmUsuario);
                mysqlCmd.Parameters.AddWithValue("_NCDFUNCIONALIDADE", ncdFuncionalidade);
                mysqlCmd.Parameters.AddWithValue("_NCDSUBFUNCIONALIDADE", ncdSubFuncionalide > 0 ? ncdSubFuncionalide : (object)DBNull.Value);
                mysqlCmd.Parameters.AddWithValue("_ACAO", Acao);

                mysqlCmd.Connection = conn;
                mysqlCmd.CommandTimeout = 500;
                mysqlCmd.CommandType = CommandType.StoredProcedure;

                da = new MySqlDataAdapter(mysqlCmd);
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}