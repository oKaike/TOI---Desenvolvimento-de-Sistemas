using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DLL
{
    public class ConexaoBD
    {
        private static string connStr = "server=localhost;user=root;database=TOI;port=3306;password=root";
        MySqlConnection conn = new MySqlConnection(connStr);
        public MySqlConnection Conectar()
        {
            return new MySqlConnection(connStr);
        }
    }
}
