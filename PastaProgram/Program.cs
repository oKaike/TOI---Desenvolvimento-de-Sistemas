using System;
using MySql.Data.MySqlClient;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;

namespace PastaProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Arquivos arq = new Arquivos();

            arq.CriacaoArquivo();
        }
    }
}
