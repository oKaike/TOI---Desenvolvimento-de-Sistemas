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

        public void CriacaoArquivo()
        {
            Console.WriteLine("Criar Pasta (Preencha as informações abaixo):");
            Console.Write("Nome:");
            Nome_aq = Console.ReadLine();

            Console.Write("Finalidade:");
            Finalidade_aq = Console.ReadLine();

           // Caminho da área de trabalho
            string desktop = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));

            // Caminho da nova pasta
            string NovaPasta = Path.Combine(desktop, Nome_aq);

            // Cria a pasta se ela não existir
            if (!Directory.Exists(NovaPasta))
            { 
                Directory.CreateDirectory(NovaPasta);
                Console.WriteLine("Pasta criada: " + NovaPasta);

                // Cria arquivos de exemplo (opcional)
                File.WriteAllText(Path.Combine(NovaPasta, "exemplo1.txt"), "Este é o primeiro arquivo.");
            }
            else
            {
                Console.WriteLine("A pasta já existe.");
            }

            }
            

        }
}
