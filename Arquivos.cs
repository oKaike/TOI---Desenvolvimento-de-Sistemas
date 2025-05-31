using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PastaProgram{
public class Arquivos{        
        public string Nome_aq;
        public string Finalidade_aq;

            public void CriacaoArquivo(byte[] dadosDoVideo, string Nome_aq){
            Console.WriteLine("Criação de arquivos (Preencha as informações abaixo):");
            Console.Write("Nome:");
            Nome_aq = Console.ReadLine();

             Console.Write("Finalidade:");
            finalidade_aq = Console.ReadLine();
            //string caminhoAreaDeTrabalho = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //string caminhoCompleto = Path.Combine(areaDeTrabalho, Nome_aq);
            //File.WriteAllBytes(caminhoCompleto, dadosDoVideo);
            }
            
            public void salvarGrav(string Titulo_GRV){
            salvarVideo = "Select titulo_grv where titulo_grv = @titulo_grv";
            cmd.Parameters.AddWithValue("@titulo_grv", Titulo_GRV);
            
            }
        }
}
