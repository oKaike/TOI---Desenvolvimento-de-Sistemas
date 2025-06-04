using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace PastaProgram
{
    internal class ConexaoBD
    {
        private static string connStr = "server=localhost;user=root;database=TOI;port=3306;password=bfck2345";
        MySqlConnection conn = new MySqlConnection(connStr);
       public MySqlConnection Conectar(){
        return new MySqlConnection(connStr);
       }
    
            }


}