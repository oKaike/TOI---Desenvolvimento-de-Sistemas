using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;

namespace DLL
{
    public class Imagens
    {
        public string NomeIMG;
        public string NomeIMG_ART;
        public string DadosIMG;
        public string dia;
        public string mes;
        public string ano;
        public string data_gravacao;
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

            Console.WriteLine("Data que a imagem foi enviada será salva automaticamente");
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
      
        public void ListarEExcluirImagem()
        {
            ConexaoBD banco = new ConexaoBD();
            using (MySqlConnection conn = banco.Conectar())
            {
                conn.Open();

                // 1. Lista todas as imagens com ID e título
                string listarQuery = "SELECT id, titulo_IMG FROM imagens";
                MySqlCommand listarCmd = new MySqlCommand(listarQuery, conn);

                using (MySqlDataReader reader = listarCmd.ExecuteReader())
                {
                    Console.WriteLine("\n📷 Imagens disponíveis no banco:\n");

                    while (reader.Read())
                    {
                        int id = reader.GetInt32("id");
                        string titulo = reader.GetString("titulo_IMG");

                        Console.WriteLine($"ID: {id} | Título: {titulo}");
                    }
                }

                Console.Write("\nDigite o ID da imagem que deseja excluir (ou 0 para cancelar): ");
                if (int.TryParse(Console.ReadLine(), out int idExcluir) && idExcluir != 0)
                {
                    // 3. Confirma exclusão
                    Console.Write("Tem certeza que deseja excluir? (s/n): ");
                    string confirmacao = Console.ReadLine().ToLower();

                    if (confirmacao == "s")
                    {
                        string deleteQuery = "DELETE FROM imagens WHERE id = @id";
                        MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, conn);
                        deleteCmd.Parameters.AddWithValue("@id", idExcluir);

                        int resultado = deleteCmd.ExecuteNonQuery();

                        if (resultado > 0)
                        {
                            Console.WriteLine("Imagem excluída com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Nenhuma imagem encontrada com esse ID.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Exclusão cancelada.");
                    }
                }
                else
                {
                    Console.WriteLine("Operação cancelada ou ID inválido.");
                }

                conn.Close();
            }
        }

    }
}
