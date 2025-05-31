using System;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.IO;


namespace PastaProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Seguranca p1 = new Seguranca();

            p1.Acesso_sg();
        }
    }
}
