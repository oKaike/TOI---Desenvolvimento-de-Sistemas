using System;
using MySql.Data.MySqlClient;
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
            nome_fun = this.nome_fun ;
            Console.Write("CPF: ");
            this.cpf_fun = Console.ReadLine();
              cpf_fun = this.cpf_fun ;
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

            while(this.sexo_fun.ToUpper() != "M" && this.sexo_fun.ToUpper() != "F"){
        
                Console.Write("Você digitou errado. Digite 'F' ou 'M':");
                this.sexo_fun = Console.ReadLine();
            }
            if(this.sexo_fun.ToUpper() == "M"){
                sexo_fun = "Masculino";
            }
            else if(this.sexo_fun.ToUpper() == "F"){
                sexo_fun = "Feminino";
            }

            this.data_nasc_fun = $"{ano}-{mes}-{dia}";
            data_nasc_fun = this.data_nasc_fun; 

            Console.Write("Setor: ");
            this.setor_fun = Console.ReadLine();
            setor_fun = this.setor_fun ;



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
            ConexaoBD banco =  new ConexaoBD();
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
    }
}
