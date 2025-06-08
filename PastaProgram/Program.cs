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
            TOI sistemaTOI = new TOI();
            sistemaTOI.ExecutarTOI();
            //Imagens IMG = new Imagens();
            //Arquivos SLV = new Arquivos();
            //Gravacoes GRV = new Gravacoes();
            //GRV.InserirGrav();
            //GRV.salvarGrav();
            //IMG.InserirIMG();
            //IMG.SalvarImagem();
            //SLV.CriacaoPasta();
            //SLV.CriarArquivo(IMG.DadosIMG, GRV.gravacao);
            //string videoUrl = "/home/kaike0proprio/Imagens/Capturas de tela/mongo.png";
            //Ocorrencias oc = new Ocorrencias();
            //oc.RegistrandoOcorrencia();
            //oc.OcorrenciaBanco();
            //CadastrarSetor cs = new CadastrarSetor();
            //cs.cadastrarsetor();
            //cs.SalvarSetor();
            // Process.Start(new ProcessStartInfo
            //{
            //FileName = videoUrl,
            // UseShellExecute = true
            //});
        }
    }
}
