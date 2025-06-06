using System;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Drawing;

namespace PastaProgram
{
    internal class Imagens
    {
        public string? NomeIMG;
        public string? NomeIMG_ART;
        public string? DadosIMG;
        public string? dia;
        public string? mes;
        public string? ano;
        public string? data_gravacao;
        public void InserirIMG()
        {
            Console.WriteLine("Preencha as informação(OBS: deixe a imagem que vc deseja colocar no banco, na Área de trabalho/Desktop):");
            Console.Write("Digite o nome da imagem:");
            this.NomeIMG_ART = Console.ReadLine();
            this.DadosIMG = $"/home/kaike0proprio/Pasta pessoal/Área de trabalho/{NomeIMG_ART}";
            DadosIMG = this.DadosIMG;

            Console.Write("Titulo:");
            this.NomeIMG = Console.ReadLine();
            NomeIMG = this.NomeIMG;

            Console.WriteLine("Data que a imagem foi enviada sera salva automaticamente");
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();

        }
        public void SalvarImagem()
        {
            ConexaoBD banco = new ConexaoBD();
            using (MySqlConnection conn = banco.Conectar())
            {
                byte[] DadosB = File.ReadAllBytes(DadosIMG);
                string query = "insert into imagens(titulo_IMG, dadosimg) VALUES (@TituloIMG,@dadosIMG)";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@TituloIMG", NomeIMG);
                cmd.Parameters.AddWithValue("@dadosIMG", DadosB);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }

        public void EnviarArquivo()
        {
            
        }
    
            }


}