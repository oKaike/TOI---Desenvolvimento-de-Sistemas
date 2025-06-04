using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PastaProgram
{
    public class Arquivos
    {
        public string Nome_aq;
        public string Finalidade_aq;
        public string NovaPasta;

        public void CriacaoPasta()
        {
            Console.WriteLine("Criar Pasta (Preencha as informações abaixo):");
            Console.Write("Nome:");
            this.Nome_aq = Console.ReadLine();
            Nome_aq = this.Nome_aq;

            Console.Write("Finalidade:");
            this.Finalidade_aq = Console.ReadLine();
            Finalidade_aq = this.Finalidade_aq;
            string desktop = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));

            this.NovaPasta = Path.Combine(desktop, Nome_aq);
            NovaPasta = this.NovaPasta;

            if (!Directory.Exists(NovaPasta))
            {
                Directory.CreateDirectory(NovaPasta);
                Console.WriteLine("Pasta criada: " + NovaPasta);

            }
            else
            {
                Console.WriteLine("A pasta já existe.");
            }

        }

        public void CriarArquivo(string DadosIMG, string gravacao)
        {
            ConexaoBD banco = new ConexaoBD();
            using (MySqlConnection conn = banco.Conectar())
            {
                //Passar conteudo para a pasta
                if (!string.IsNullOrWhiteSpace(DadosIMG))
                {
                    string query = "select DadosIMG from imagens";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    using var reader = cmd.ExecuteReader();

                    using StreamWriter escritor = new StreamWriter(NovaPasta);
                    while (reader.Read())
                    {
                        string Dados = reader.GetString("id");
                    }

                    File.WriteAllText(Path.Combine(NovaPasta, $"{DadosIMG}"), "Este é o primeiro arquivo.");

                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (!string.IsNullOrWhiteSpace(gravacao))
                {
                    string query = "select gravacao from gravacoes";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
       
                    conn.Open();
                    using var reader = cmd.ExecuteReader();
                    File.WriteAllText(Path.Combine(NovaPasta, $"{gravacao}"), "Este é o primeiro arquivo.");
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

            }
        }
    }
}