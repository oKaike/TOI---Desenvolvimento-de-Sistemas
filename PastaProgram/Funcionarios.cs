using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using PastaProgram;
namespace PastaProgram
{
    public class Funcionario
    {
        public string? nome_fun;
        public string? cpf_fun;
        public string? data_nasc_fun;
        public string? sexo_fun;
        public string? setor_fun;
        public string? dia;
        public string? mes;
        public string? ano;

        public void CadastrarFun()
        {
            Console.WriteLine("Preencha as informações dos funcionários:");
            Console.Write("Nome: ");
            this.nome_fun = Console.ReadLine();
            nome_fun = this.nome_fun;
            Console.Write("CPF: ");
            this.cpf_fun = Console.ReadLine();
            cpf_fun = this.cpf_fun;
            Console.WriteLine("Data de Nascimento(Preencha os três campos): ");
            Console.Write("Dia:");
            this.dia = Console.ReadLine();
            dia = this.dia;

            Console.Write("Mês:");
            this.mes = Console.ReadLine();
            mes = this.mes;

            Console.Write("Ano:");
            this.ano = Console.ReadLine();
            ano = this.ano;

            Console.Write("Sexo(M = Masculino | F - Feminino):");
            this.sexo_fun = Console.ReadLine();

            while (this.sexo_fun.ToUpper() != "M" && this.sexo_fun.ToUpper() != "F")
            {

                Console.Write("Você digitou errado. Digite 'F' ou 'M':");
                this.sexo_fun = Console.ReadLine();
            }
            if (this.sexo_fun.ToUpper() == "M")
            {
                sexo_fun = "Masculino";
            }
            else if (this.sexo_fun.ToUpper() == "F")
            {
                sexo_fun = "Feminino";
            }

            this.data_nasc_fun = $"{ano}-{mes}-{dia}";
            data_nasc_fun = this.data_nasc_fun;

            Console.Write("Setor: ");
            ConexaoBD banco = new ConexaoBD();
        using (MySqlConnection conn = banco.Conectar())
        {
            string query = "select id_setor, nome_setor from CadastrarSetor";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            // Dicionário para guardar as opções
            Dictionary<int, string> opcoes = new Dictionary<int, string>();
            int opcaoNumero = 1;

            Console.WriteLine("Escolha um setor:");

            while (reader.Read())
            {
                int id = reader.GetInt32("id_setor");
                string nome = reader.GetString("nome_setor");

                Console.WriteLine($"{opcaoNumero} - {nome}");
                opcoes[opcaoNumero] = nome; // Guarda a relação opção -> id do setor
                opcaoNumero++;
            }

            reader.Close();
            conn.Close();

            Console.Write("Digite o número correspondente: ");
            int escolha = int.Parse(Console.ReadLine());

            if (opcoes.ContainsKey(escolha))
            {
                string SetorNome = opcoes[escolha];
                    this.setor_fun = SetorNome;
                Console.WriteLine($"Você escolheu o setor com ID: {SetorNome}");
                // Aqui você pode usar esse ID para fazer ações relacionadas ao funcionário
            }
            else
            {
                Console.WriteLine("Opção inválida.");
            }
        }



        }

        public void InfoFun()
        {
            Console.WriteLine($"Nome: {nome_fun}");
            Console.WriteLine($"CPF: {cpf_fun}");
            Console.WriteLine($"Idade: {data_nasc_fun}");
            Console.WriteLine($"Setor: {setor_fun}");
        }

        public void SalvarDados()
        {
            ConexaoBD banco = new ConexaoBD();
            using (MySqlConnection conn = banco.Conectar())
            {
                string query = "INSERT INTO funcionarios(nome_fun,cpf_fun,data_nasc_fun,sexo_fun,setor_fun) VALUES (@nome_fun,@cpf_fun,@data_nasc_fun,@sexo_fun,@setor_fun)";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@nome_fun", this.nome_fun);
                cmd.Parameters.AddWithValue("@cpf_fun", this.cpf_fun);
                cmd.Parameters.AddWithValue("@data_nasc_fun", this.data_nasc_fun);
                cmd.Parameters.AddWithValue("@sexo_fun", this.sexo_fun);
                cmd.Parameters.AddWithValue("@setor_fun", this.setor_fun);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        public void ExcluirFun()
        {
            Console.Write("Deletar funcionario(Preencha as informações)\n");
            Console.WriteLine("Nome:");
            string nome_funex = Console.ReadLine();
            
            ConexaoBD banco = new ConexaoBD();
            using (MySqlConnection conn = banco.Conectar())
            {
                string query = "delete funcionarios where nome_fun = @nome_fun";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nome_fun", nome_funex);
            }
        }

    }
}
