using System;
using MySql.Data.MySqlClient;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using System.Diagnostics;
using System.Drawing;

namespace PastaProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Gravacoes Grav = new Gravacoes();

            Grav.ExecutarGrav();
            //string videoUrl = "/home/kaike0proprio/Imagens/Capturas de tela/mongo.png";


            // Process.Start(new ProcessStartInfo
            //{
            //FileName = videoUrl,
            // UseShellExecute = true
            //});
        }
    }
}
