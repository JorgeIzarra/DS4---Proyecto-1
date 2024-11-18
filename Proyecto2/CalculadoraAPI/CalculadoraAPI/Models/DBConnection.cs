using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CalculadoraAPI.Models
{
    public class DBConnection
    {
        private static readonly string connectionString = @"Data Source=DESKTOP-3IOUQVC\SQLEXPRESS;Initial Catalog=CalculadoraDB;Integrated Security=True;TrustServerCertificate=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}