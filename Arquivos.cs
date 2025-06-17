using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;

namespace DLL
{
    public class Arquivos
    {
        public string Nome_aq;
        public string Finalidade_aq;
        public string NovaPasta;

        public void CriacaoPasta()
        {
            Console.WriteLine("Criar Pasta (Preencha as informações abaixo):");
            Console.Write("Nome: ");
            this.Nome_aq = Console.ReadLine();

            Console.Write("Finalidade: ");
            this.Finalidade_aq = Console.ReadLine();

            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            this.NovaPasta = Path.Combine(desktop, Nome_aq);

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

        public void CriarArquivo(string nomeArquivo, string tipo)
        {
            ConexaoBD banco = new ConexaoBD();
            using (MySqlConnection conn = banco.Conectar())
            {
                conn.Open();

                if (tipo == "imagem")
                {
                    string query = "SELECT id, DadosIMG FROM imagens LIMIT 1"; // ajustar se tiver múltiplas imagens
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            byte[] dados = (byte[])reader["DadosIMG"];
                            string caminho = Path.Combine(NovaPasta, $"{nomeArquivo}.png");
                            File.WriteAllBytes(caminho, dados);
                            Console.WriteLine("Imagem salva em: " + caminho);
                        }
                    }
                }
                else if (tipo == "gravacao")
                {
                    string query = "SELECT id, gravacao FROM gravacoes LIMIT 1";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            byte[] dados = (byte[])reader["gravacao"];
                            string caminho = Path.Combine(NovaPasta, $"{nomeArquivo}.mp4");
                            File.WriteAllBytes(caminho, dados);
                            Console.WriteLine("Gravação salva em: " + caminho);
                        }
                    }
                }

                conn.Close();
            }
        }

        public void SalvarDados()
        {
            ConexaoBD banco = new ConexaoBD();
            using (MySqlConnection conn = banco.Conectar())
            {
                string query = "INSERT INTO arquivos(nome_aq, finalidade_aq) VALUES(@nome_aq, @finalidade_aq)";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@nome_aq", Nome_aq);
                cmd.Parameters.AddWithValue("@finalidade_aq", Finalidade_aq);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Console.WriteLine("Dados salvos com sucesso!");
            }
        }

        public void DeletarArquivo()
        {
            ConexaoBD banco = new ConexaoBD();
            using (MySqlConnection conn = banco.Conectar())
            {
                try
                {
                    conn.Open();
                    string queryListar = "SELECT id, Titulo_GRV FROM gravacoes";
                    using (MySqlCommand cmdListar = new MySqlCommand(queryListar, conn))
                    using (MySqlDataReader reader = cmdListar.ExecuteReader())
                    {
                        Console.WriteLine("Gravações disponíveis:");
                        while (reader.Read())
                        {
                            int id = reader.GetInt32("id");
                            string titulo = reader.GetString("Titulo_GRV");
                            Console.WriteLine($"ID: {id} | Título: {titulo}");
                        }
                    }

                    Console.Write("\nDigite o ID da gravação que deseja excluir: ");
                    string input = Console.ReadLine();
                    if (!int.TryParse(input, out int idEscolhido))
                    {
                        Console.WriteLine("ID inválido.");
                        return;
                    }

                    string queryExcluir = "DELETE FROM gravacoes WHERE id = @id";
                    using (MySqlCommand cmdExcluir = new MySqlCommand(queryExcluir, conn))
                    {
                        cmdExcluir.Parameters.AddWithValue("@id", idEscolhido);
                        int rows = cmdExcluir.ExecuteNonQuery();
                        Console.WriteLine(rows > 0 ? "Gravação excluída com sucesso!" : "Nenhuma gravação com esse ID.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Erro: {ex.Message}");
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
