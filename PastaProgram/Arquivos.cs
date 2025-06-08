using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
                    string queryIMG = "select DadosIMG from imagens";

                    MySqlCommand cmd = new MySqlCommand(queryIMG, conn);
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
                    string queryGrav = "select gravacao from gravacoes";
                    MySqlCommand cmd = new MySqlCommand(queryGrav, conn);

                    conn.Open();
                    using var reader = cmd.ExecuteReader();
                    File.WriteAllText(Path.Combine(NovaPasta, $"{gravacao}"), "Este é o primeiro arquivo.");
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }


            }
        }
        public void DeletarArquivo()
        {

        }

        public void SalvarDados()
        {
             ConexaoBD banco = new ConexaoBD();
            using (MySqlConnection conn = banco.Conectar())
            {

                string query = "insert into arquivos(nome_aq, finalidade_aq) values(@nome_aq,@finalidade_aq)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nome_aq",Nome_aq );
                cmd.Parameters.AddWithValue("@finalidade_aq", Finalidade_aq);


                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            
            }
        }
    }
}