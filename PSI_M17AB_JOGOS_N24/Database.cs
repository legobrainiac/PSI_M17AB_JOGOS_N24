using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PSI_M17AB_JOGOS_N24
{
    public class Database
    {
        string connectionString;
        SqlConnection con;

        private static Database instance;

        public static Database Instance
        {
            get
            {
                if (instance == null)
                    instance = new Database();
                return instance;
            }
        }

        public Database()
        {
            connectionString = ConfigurationManager.ConnectionStrings["sql"].ToString();
            con = new SqlConnection(connectionString);
            con.Open();
        }

        ~Database()
        {
            try
            {
                con.Close();
                con.Dispose();
            }
            catch (Exception erro)
            {
                Console.Write("Erro: " + erro.Message);
            }
        }

        public DataTable returnQResult(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, con);
            DataTable reg = new DataTable();
            SqlDataReader data = cmd.ExecuteReader();
            reg.Load(data);
            reg.Dispose();
            cmd.Dispose();
            return reg;
        }
        public DataTable returnQResult(string sql, List<SqlParameter> parameters)
        {
            SqlCommand cmd = new SqlCommand(sql, con);
            DataTable reg = new DataTable();
            cmd.Parameters.AddRange(parameters.ToArray());
            SqlDataReader data = cmd.ExecuteReader();
            reg.Load(data);
            reg.Dispose();
            cmd.Dispose();
            return reg;
        }

        public DataTable returnQResult(string sql, List<SqlParameter> parameters, SqlTransaction transaction)
        {
            SqlCommand comando = new SqlCommand(sql, con);
            comando.Transaction = transaction;
            DataTable registos = new DataTable();
            comando.Parameters.AddRange(parameters.ToArray());
            SqlDataReader dados = comando.ExecuteReader();
            registos.Load(dados);
            registos.Dispose();
            comando.Dispose();
            return registos;
        }

        public bool executeQ(string sql)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception error)
            {
                Console.Write(error.Message);
                return false;
            }
            return true;
        }
        public bool executeQ(string sql, List<SqlParameter> parameters)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddRange(parameters.ToArray());
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception error)
            {
                Console.Write(error.Message);
                return false;
            }
            return true;
        }
        public bool executeQ(string sql, List<SqlParameter> parameters, SqlTransaction transaction)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddRange(parameters.ToArray());
                cmd.Transaction = transaction;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception error)
            {
                Console.Write(error.Message);
                return false;
            }
            return true;
        }
    }
}