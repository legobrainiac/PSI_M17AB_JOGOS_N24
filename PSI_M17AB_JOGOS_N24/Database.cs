using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

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

        public int add_product(string name, string description, decimal price)
        {
            var q = "insert into products(product_name, product_description, price) values(@name, @description, @price);SELECT CAST(SCOPE_IDENTITY() AS INT);";
            List<SqlParameter> args = new List<SqlParameter>
            {
                new SqlParameter("@name", name),
                new SqlParameter("@description", description),
                new SqlParameter("@price", price),
            };

            SqlCommand cmd = new SqlCommand(q, con);
            cmd.Parameters.AddRange(args.ToArray());
            cmd.Dispose();

            return (int)cmd.ExecuteScalar();
        }

        public DataTable get_products()
        {
            var q = "select * from products";
            return returnQResult(q);
        }

        public void delete_product(int id)
        {
            var q = "delete from products where id = @id";

            List<SqlParameter> args = new List<SqlParameter>
            {
                new SqlParameter("@id", id),
            };

            //TODO(legobrainiac): delete image too, ez but i dont feel like doing it now eksdee
            executeQ(q, args);
        }

        public bool edit_product(int id, string name, string description, int price)
        {
            var q = "update products set product_name = @name, product_description = @description, price = @price where id = @id";

            List<SqlParameter> args = new List<SqlParameter>
            {
                new SqlParameter("@id", id),
                new SqlParameter("@name", name),
                new SqlParameter("@description", description),
                new SqlParameter("@price", price)
            };

            //TODO(legobrainiac): Edit image, ez but i dont feel like doing it now eksdee
            return executeQ(q, args);
        }

        public bool review_product(int id_user, int id_product, string title, string body)
        {
            var q = "insert into products_reviews(id_user, id_product, title, body) values(@id_user, @id_product, @title, @body)";

            List<SqlParameter> args = new List<SqlParameter>
            {
                new SqlParameter("@id_user", id_user),
                new SqlParameter("@id_product", id_product),
                new SqlParameter("@title", title),
                new SqlParameter("@body", body)
            };

            return executeQ(q, args);
        }

        public DataTable reviews_product(int id)
        {
            var q = "select * from products_reviews where id_product like @id";

            List<SqlParameter> args = new List<SqlParameter>
            {
                new SqlParameter("@id", id),
            };

            return returnQResult(q, args);
        }

        public DataTable reviews_user(int id)
        {
            var q = "select * from products_reviews where id_user like @id";

            List<SqlParameter> args = new List<SqlParameter>
            {
                new SqlParameter("@id", id),
            };

            return returnQResult(q, args);
        }

        public DataTable get_users()
        {
            var q = "select username, email, tipo from users";
            return returnQResult(q);
        }

        public DataTable get_product_with_id(int id)
        {
            var q = "select * from products where id like @id";

            List<SqlParameter> args = new List<SqlParameter>
            {
                new SqlParameter("@id", id),
            };

            return returnQResult(q, args);
        }

        public bool add_user(string username, string pass, string email, int tipo)
        {
            var q = "insert into users(username, pass, email, tipo) values(@username, HASHBYTES('SHA2_512',@password), @email, @tipo)";

            List<SqlParameter> args = new List<SqlParameter>
            {
                new SqlParameter("@username", username),
                new SqlParameter("@password", pass),
                new SqlParameter("@email", email),
                new SqlParameter("@tipo", tipo),
            };

            return executeQ(q, args);
        }

        public bool check_user_login(string username, string pass, out DataTable
            user)
        {
            var q = "select * from users where username like @username and pass like HASHBYTES('SHA2_512',@password)";

            List<SqlParameter> args = new List<SqlParameter>
            {
                new SqlParameter("@username", username),
                new SqlParameter("@password", pass),
            };

            var res = returnQResult(q, args);
            user = res;

            if (res.Rows.Count > 0)
                return true;
            return false;
        }
    }
}