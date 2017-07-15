using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4CodeGenerator.EntityFramework.EntityFramework
{
    public static class SqlHelper
    {
        private static string _connectionString;

        public static string ConnectionString
        {
            get { return SqlHelper._connectionString; }
            set { SqlHelper._connectionString = value; }
        }
        public static DataTable SqlQueryForDataTatable(this Database db, string sql, params SqlParameter[] parameters)
        {
            SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            conn.ConnectionString = db.Connection.ConnectionString;
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;

            if (parameters != null && parameters.Length > 0)
            {
                foreach (var item in parameters)
                {
                    cmd.Parameters.Add(item);
                }
            }


            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public static DataTable SqliteQueryForDataTatable(this Database db, string sql, params SqlParameter[] parameters)
        {
            DataTable table = new DataTable();
            using (SQLiteConnection conn = new SQLiteConnection(db.Connection.ConnectionString))
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    if (parameters != null && parameters.Length > 0)
                    {
                        foreach (var item in parameters)
                        {
                            cmd.Parameters.Add(item);
                        }
                    }
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                    adapter.Fill(table);
                }
            }
            return table;
        }
    }
}
