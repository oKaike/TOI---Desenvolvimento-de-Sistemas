using System;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Drawing;
namespace PastaProgram
{
    internal class Problemas
    {
        public string? titulo_pr;
        public string? descricao_pr;
        public int? problemas_resolvidos;
        public int? nivel_risco;
        public string? data_problema;
        public string? dia_pr;
        public string? ano_pr;
        public string? mes_pr;
        public string? DataRegistro;
        public string? setor_pr;
        public string? local_problema;
        public string? RegistradoPor;
        public string? val_nivel_risco;
        public void RegistradoProblema()
        {
            Console.WriteLine("Registrar problemas(Preencha as informações):");

            Console.Write("Tipo de problemas:");
            titulo_pr = Console.ReadLine();
            this.titulo_pr = titulo_pr;

            Console.Write("Descrição(Breve resumo do que aconteceu):");
            descricao_pr = Console.ReadLine();
            this.descricao_pr = descricao_pr;

            Console.Write("Local do acotencido:");
            local_problema = Console.ReadLine();
            this.local_problema = local_problema;

            Console.Write("Nivel de risco(Escolha uma da opções):\n1->Baixo\n2->Medio\n3->Grande\n4->Auto Risco\nSua Resposta: ");
            nivel_risco = int.Parse(Console.ReadLine());
            this.nivel_risco = nivel_risco;

            while (nivel_risco != 1 && nivel_risco != 2 && nivel_risco != 3 && nivel_risco != 4)
            {
                if (nivel_risco == 1)
                {
                    val_nivel_risco = "baixo";
                    this.val_nivel_risco = val_nivel_risco;

                }
                else if (nivel_risco == 2)
                {
                    val_nivel_risco = "medio";
                    this.val_nivel_risco = val_nivel_risco;

                }
                else if (nivel_risco == 3)
                {
                    val_nivel_risco = "grande";
                    this.val_nivel_risco = val_nivel_risco;

                }
                else if (nivel_risco == 4)
                {
                    val_nivel_risco = "auto_risco";
                    this.val_nivel_risco = val_nivel_risco;
                }
            }
            Console.Write("Data do ocorrido(Preencha os todos os campos se possivel):\n");
            Console.Write("Ano:\n");
            ano_pr = Console.ReadLine();
            this.ano_pr = ano_pr;

            Console.Write("Mẽs:\n");
            mes_pr = Console.ReadLine();
            this.mes_pr = mes_pr;

            Console.Write("Dia:\n");
            dia_pr = Console.ReadLine();
            this.dia_pr = dia_pr;


            data_problema = $"{ano_pr}-{mes_pr.PadLeft(2, '0')}-{dia_pr.PadLeft(2, '0')}";
            this.data_problema = data_problema;

            Console.Write("Nome autor da problema(Campo não obrigatorio):");
            RegistradoPor = Console.ReadLine();

        }
        public void SalvarProblema()
        {
             ConexaoBD banco = new ConexaoBD();
            using (MySqlConnection conn = banco.Conectar())
            {
                string query = "insert into problemas(titulo_pr, descricao, nivel_risco, data_pr, setor_pr ) VALUES (@titulo_pr, @descricao_pr, @local_caso,@nivel_risco,@data_pr,@setor_pr, @registradopor)";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@titulo_pr", titulo_pr);
                cmd.Parameters.AddWithValue("@descricao_pr", descricao_pr);
                cmd.Parameters.AddWithValue("@local_problema", local_problema);
                cmd.Parameters.AddWithValue("@nivel_risco", val_nivel_risco);
                cmd.Parameters.AddWithValue("@data_pr", data_problema);
                cmd.Parameters.AddWithValue("@setor_pr", setor_pr);
                cmd.Parameters.AddWithValue("@registradopor", RegistradoPor);


                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }
        }

}