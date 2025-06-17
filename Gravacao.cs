using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;

namespace DLL
{
    public class Gravacao
    {
        public string Titulo_GRV;
        public string nome_grav;
        public string gravacao;
        public string data_gravacao;
        public string dia;
        public string mes;
        public string ano;
        public void InserirGrav()
        {
            Console.WriteLine("Preencha as informação sobre a grvação(OBS: Deixe a gravação na area de trabalho/desktop antes de passa-la para o banco de dados):");
            Console.Write("Nome da gravação:");
            nome_grav = Console.ReadLine();

            this.gravacao = $"/home/kaike0proprio/Imagens/Capturas de tela/{nome_grav}";
            gravacao = this.gravacao;

            Console.Write("Titulo:");
            this.Titulo_GRV = Console.ReadLine();
            Titulo_GRV = this.Titulo_GRV;

            Console.WriteLine("Data de Gravação(Preencha os três campos abaixo): ");
            Console.Write("Dia:");
            this.dia = Console.ReadLine();
            dia = this.dia;

            Console.Write("Mês:");
            this.mes = Console.ReadLine();
            mes = this.mes;

            Console.Write("Ano:");
            this.ano = Console.ReadLine();
            ano = this.ano;

            this.data_gravacao = $"{ano}-{mes}-{dia}";
            data_gravacao = this.data_gravacao;


        }

        public void salvarGrav()
        {

            ConexaoBD banco = new ConexaoBD();
            using (MySqlConnection conn = banco.Conectar())
            {
                byte[] gravB = File.ReadAllBytes(gravacao);
                string query = "insert into gravacoes(Titulo_GRV, gravacao, data_gravacao) VALUES (@Titulo_GRV,@gravacao,@data_gravacao)";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Titulo_GRV", Titulo_GRV);
                cmd.Parameters.AddWithValue("@gravacao", gravB);
                cmd.Parameters.AddWithValue("@data_gravacao", data_gravacao);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }

        public void ExecutarGrav()
        {
            Arquivos ARQ = new Arquivos();
            ConexaoBD banco = new ConexaoBD();
            using (MySqlConnection conn = banco.Conectar())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("select gravacao from gravacoes where id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", 2);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string desktop = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));

                            byte[] dados = (byte[])reader["gravacao"];
                            File.WriteAllBytes("/home/kaike0proprio/Imagens/Capturas de tela/mongo.png", dados);
                            Console.WriteLine("Vídeo recuperado e salvo com sucesso!");
                            Process.Start(new ProcessStartInfo
                            {
                                FileName = "/home/kaike0proprio/Imagens/Capturas de tela/mongo.png",
                                UseShellExecute = true
                            });
                        }
                    }
                }
            }
        }

        public void ListarEExcluirGravacoes()
        {
            ConexaoBD banco = new ConexaoBD();

            using (MySqlConnection conn = banco.Conectar())
            {
                string queryListar = "SELECT id, Titulo_GRV, data_gravacao FROM gravacoes";
                MySqlCommand cmdListar = new MySqlCommand(queryListar, conn);

                conn.Open();
                using (MySqlDataReader reader = cmdListar.ExecuteReader())
                {
                    Console.WriteLine("\n🎥 Gravações Cadastradas:");
                    Console.WriteLine("--------------------------------------------------");
                    while (reader.Read())
                    {
                        int id = reader.GetInt32("id");
                        string titulo = reader.GetString("Titulo_GRV");
                        DateTime data = reader.GetDateTime("data_gravacao");

                        Console.WriteLine($"ID: {id} | Título: {titulo} | Data: {data.ToShortDateString()}");
                    }
                }
                conn.Close();

                Console.Write("\nDigite o ID da gravação que deseja excluir (ou ENTER para cancelar): ");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("❎ Operação cancelada.");
                    return;
                }

                int idExcluir;
                if (!int.TryParse(input, out idExcluir))
                {
                    Console.WriteLine("⚠️ ID inválido.");
                    return;
                }

                Console.Write($"Tem certeza que deseja excluir a gravação ID {idExcluir}? (s/n): ");
                string confirmacao = Console.ReadLine();

                if (confirmacao.ToLower() != "s")
                {
                    Console.WriteLine("❎ Exclusão cancelada.");
                    return;
                }

                string queryExcluir = "DELETE FROM gravacoes WHERE id = @id";
                MySqlCommand cmdExcluir = new MySqlCommand(queryExcluir, conn);
                cmdExcluir.Parameters.AddWithValue("@id", idExcluir);

                conn.Open();
                int rows = cmdExcluir.ExecuteNonQuery();
                conn.Close();

                if (rows > 0)
                    Console.WriteLine("Gravação excluída com sucesso!");
                else
                    Console.WriteLine("Nenhuma gravação encontrada com esse ID.");
            }
        }

    }
}
