using System;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Drawing;
using PastaProgram;
using System.IO;
namespace PastaProgram
{
    internal class CadastrarSetor
    {
        public string? nome_setor;
        public string? qtdade_funcionarios;
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

        public void ExcluirSetor()
        {
             ConexaoBD banco = new ConexaoBD();
            using (MySqlConnection conn = banco.Conectar())
            {
                Console.Write("Deletar Setor(Preencha as informações)\n");
                string nome_setorex = Console.ReadLine();
                
                string query = "delete from CadastrarSetor where nome_setor = @nome_setor";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nome_setor", nome_setorex);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}