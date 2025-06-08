using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PastaProgram
{
    internal class Seguranca 
    {
        public string? Nome_sg;
        public string? Sexo_sg;
        public string? Senha_sg; 
        public string? cpf_sg;
        public string? idade_sg ;
        public string? dia;
        public string? mes;
        public string? ano;

        public void DefinirLimiteMaximoSegurancas()
{
    Console.Write("Quantos seguranças podem ser cadastrados no sistema? ");
    int limiteMaximo = int.Parse(Console.ReadLine());

    ConexaoBD banco = new ConexaoBD();
    using (MySqlConnection conn = banco.Conectar())
    {
        conn.Open();

        // Verifica se já existe um limite cadastrado
        string checkQuery = "select count(*) from Configuracoes";
        MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

        if (count > 0)
        {
            Console.WriteLine("O limite já foi definido anteriormente e não pode ser alterado.");
            return;
        }

        // Insere o limite
        string insertQuery = "INSERT INTO Configuracoes (limiteMaximoSG) VALUES (@limite)";
        MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn);
        insertCmd.Parameters.AddWithValue("@limite", limiteMaximo);
        insertCmd.ExecuteNonQuery();

        Console.WriteLine("Limite cadastrado com sucesso.");
    }
}



        public void CadastrarSg()
        {
            Console.WriteLine("Você escolheu cadastrar um novo segurança");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Preencha as informações:");
            Console.Write("Nome:");
            Nome_sg = Console.ReadLine();
            this.Nome_sg = Nome_sg;
            Console.Write("Senha:");
            Senha_sg = Console.ReadLine();
            this.Senha_sg = Senha_sg;

            Console.Write("CPF:");
            cpf_sg = Console.ReadLine();
            this.cpf_sg = cpf_sg;

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

            Console.Write("Sexo(M - Masculino | F - Feminino):");
            this.Sexo_sg = Console.ReadLine();
            while (this.Sexo_sg.ToUpper() != "M" && this.Sexo_sg.ToUpper() != "F")
            {

                Console.Write("Você digitou errado. Digite 'F' ou 'M':");
                this.Sexo_sg = Console.ReadLine();
            }
            if (this.Sexo_sg.ToUpper() == "M")
            {
                Sexo_sg = "Masculino";
            }
            else if (this.Sexo_sg.ToUpper() == "F")
            {
                Sexo_sg = "Feminino";
            }
            this.idade_sg = $"{ano}-{mes}-{dia}";
            idade_sg = this.idade_sg;
        }

        public void Acesso_sg() {
           Console.Write("Digite seu nome:");
           Nome_sg = Console.ReadLine();
            Console.Write("Digite sua senha:");
           Senha_sg = Console.ReadLine();

            ConexaoBD banco =  new ConexaoBD();
            using (MySqlConnection conn = banco.Conectar()){
               string ChecarSenha = "select Senha_sg from SegurancaUser where Senha_sg = @Senha_sg";
                          MySqlCommand cmd = new MySqlCommand(ChecarSenha, conn);

               cmd.Parameters.AddWithValue("@senha_sg", Senha_sg);
               
                conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                conn.Close();
                if( count > 0){
                    Console.WriteLine("Agora Você pode acessar o conteudo avançado");
                }
            }
        }

        public void SalvarDados()
        {
            ConexaoBD banco = new ConexaoBD();
            using (MySqlConnection conn = banco.Conectar())
            {
                string query = "INSERT INTO SegurancaUser(Nome_sg,Sexo_sg,Senha_sg,cpf,data_nasc_sg) VALUES (@nome_sg,@sexo_sg,@senha_sg,@cpf_sg,@data_nasc_sg)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nome_sg", this.Nome_sg);
                cmd.Parameters.AddWithValue("@cpf_sg", this.cpf_sg);
                cmd.Parameters.AddWithValue("@sexo_sg", this.Sexo_sg);
                cmd.Parameters.AddWithValue("@senha_sg", this.Senha_sg);
                cmd.Parameters.AddWithValue("@data_nasc_sg", this.idade_sg);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
                public void ExcluirSG() {
                    
                }

        }
    }