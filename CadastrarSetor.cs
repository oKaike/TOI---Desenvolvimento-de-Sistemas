using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DLL
{
    public class CadastrarSetor
    {
        public string nome_setor;
        public string qtdade_funcionarios;
        public void cadastrarsetor()
        {
            Console.Write("Cadastrar Setor(Preencha as informações)\n");
            Console.Write("Nome:");
            nome_setor = Console.ReadLine();
            this.nome_setor = nome_setor;

            Console.Write("Quantidade de funcionario no setor:");
            qtdade_funcionarios = Console.ReadLine();
            this.qtdade_funcionarios = qtdade_funcionarios;
        }

        public void SalvarSetor()
        {
            ConexaoBD banco = new ConexaoBD();
            using (MySqlConnection conn = banco.Conectar())
            {
                string query = "insert into CadastrarSetor(nome_setor, qtade_fun) VALUES (@nome_setor, @qtade_fun)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nome_setor", nome_setor);
                cmd.Parameters.AddWithValue("@qtade_fun", qtdade_funcionarios);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void ListarEExcluirSetor()
        {
            ConexaoBD banco = new ConexaoBD();
            using (MySqlConnection conn = banco.Conectar())
            {
                try
                {
                    conn.Open();

                    // 1. Listar setores
                    string queryListar = "SELECT id_setor, nome_setor FROM CadastrarSetor";
                    MySqlCommand cmdListar = new MySqlCommand(queryListar, conn);

                    using (MySqlDataReader reader = cmdListar.ExecuteReader())
                    {
                        Console.WriteLine("Setores disponíveis:\n");
                        while (reader.Read())
                        {
                            int id = reader.GetInt32("id_setor");
                            string nome = reader.GetString("nome_setor");
                            Console.WriteLine($"ID: {id} | Nome: {nome}");
                        }
                    }

                    // 2. Solicitar ID para exclusão
                    Console.Write("\nDigite o ID do setor que deseja excluir: ");
                    string input = Console.ReadLine();
                    if (!int.TryParse(input, out int idSetor))
                    {
                        Console.WriteLine("ID inválido. Operação cancelada.");

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao listar ou excluir: {ex.Message}");
                }
                finally
                {
                    conn.Close();
                }
            }
        } 
       }
} 