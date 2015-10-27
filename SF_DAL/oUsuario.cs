﻿using System;
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
        public DataTable CarregaUsuarioLogin(string cnmUsuario, string cdsSenha, string ConnectionString)
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

                mysqlCmd = new MySqlCommand("SP_SG_UsuarioLogin_Carrega");
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
    }
}