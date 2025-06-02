using System;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Drawing;
using PastaProgram;
using System.IO;

namespace PastaProgram{
    internal class Gravacoes : Arquivos
    {

        public string Titulo_GRV;
        public string gravacao;
        public string data_gravacao;
        public string? dia;
        public string? mes;
        public string? ano;
        public void InserirGrav() {
            Console.WriteLine("Preencha as informação:");
            this.gravacao = "/home/kaike0proprio/Imagens/Capturas de tela/mongo.png";
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

        public void ExecutarGrav() {
            Arquivos ARQ = new Arquivos();
            ConexaoBD banco =  new ConexaoBD();
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


        
        
    }
}