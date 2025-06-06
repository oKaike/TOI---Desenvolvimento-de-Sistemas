using System;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Drawing;

namespace PastaProgram
{
    internal class Ocorrencias
    {
        public string? tipo_oc;
        public string? descricao_oc;
        public string? local_caso;
        public int? nivel_risco;
        public string? data_hora_ocorrido;
        public string? dia_oc;
        public string? ano_oc;
        public string? mes_oc;
        public string? hora_oc;
        public string? min_oc;
        public string? seg_oc;
        public string? nome_envolvidos;
        public string? RegistradoPor;
        public string? val_nivel_risco;
        public int? a;
        public string?[] qtade_evolvidos;



        public void RegistrandoOcorrencia()
        {
            Console.WriteLine("Registrar Ocorrencia(Preencha as informações):");

            Console.Write("Tipo de Ocorrencia(Qual foi o crime):");
            tipo_oc = Console.ReadLine();
            this.tipo_oc = tipo_oc;

            Console.Write("Descrição(Breve resumo do que aconteceu):");
            descricao_oc = Console.ReadLine();
            this.descricao_oc = descricao_oc;

            Console.Write("Local do acotencido:");
            local_caso = Console.ReadLine();
            this.local_caso = local_caso;

            Console.Write("Nivel de risco(Escolha uma da opções):\n1->Baixo\n2->Medio\n3->Grande\n4->Auto Risco\nSua Resposta: ");
            nivel_risco = int.Parse(Console.ReadLine());
            this.nivel_risco = nivel_risco;

            while (nivel_risco != 1 && nivel_risco!= 2 && nivel_risco!= 3 && nivel_risco!= 4)
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
                else if(nivel_risco == 4)
                {
                    val_nivel_risco = "auto_risco";
                    this.val_nivel_risco = val_nivel_risco;
                }
            }
            Console.Write("Data do ocorrido(Preencha os todos os campos se possivel):\n");
            Console.Write("Ano:\n");
            ano_oc = Console.ReadLine();
            this.ano_oc = ano_oc;

            Console.Write("Mẽs:\n");
            mes_oc = Console.ReadLine();
            this.mes_oc = mes_oc;

            Console.Write("Dia:\n");
            dia_oc = Console.ReadLine();
            this.dia_oc = dia_oc;

            Console.Write("Horas(Opcional):\n");
            hora_oc = Console.ReadLine();
            this.hora_oc = hora_oc;
            if (string.IsNullOrWhiteSpace(hora_oc)) hora_oc = "00";

            Console.Write("Minutos(Opcional):\n");
            min_oc = Console.ReadLine();
            this.min_oc = min_oc;
            if (string.IsNullOrWhiteSpace(min_oc)) min_oc = "00";

            Console.Write("Segundos(Opcional):\n");
            seg_oc = Console.ReadLine();
            this.seg_oc = seg_oc;
            if (string.IsNullOrWhiteSpace(seg_oc)) seg_oc = "00";

            Console.Write("Quantos suspeitos:");
            a = int.Parse(Console.ReadLine()!);
            this.a = a;
            this.qtade_evolvidos = new string[(int)a];

            int preenchido = 0;
            for (string i = "S"; i.ToUpper() == "S";)
            {
                if (a >= preenchido)
                {
                    preenchido++;
                    Console.WriteLine("Nome dos suspeitos(pelo menos o nome de um dos supostos envolvidos):");
                    nome_envolvidos = Console.ReadLine();

                    Console.WriteLine("Gostaria de continuar adicionando suspeitos[S/N]:");
                    i = Console.ReadLine();
                    while (i.ToUpper() != "N" && i.ToUpper() != "S")
                    {
                        Console.WriteLine("Você digitou um valor invalido, digite S ou N");
                        i = Console.ReadLine();
                    }
                }
            }
            data_hora_ocorrido = $"{ano_oc}-{mes_oc.PadLeft(2, '0')}-{dia_oc.PadLeft(2, '0')} {hora_oc.PadLeft(2, '0')}:{min_oc.PadLeft(2, '0')}:{seg_oc.PadLeft(2, '0')}";
            this.data_hora_ocorrido = data_hora_ocorrido;

            Console.Write("Nome autor da ocorrencia(Campo não obrigatorio):");
            RegistradoPor = Console.ReadLine();

        }
        public void OcorrenciaBanco()
        {
            ConexaoBD banco = new ConexaoBD();
            using (MySqlConnection conn = banco.Conectar())
            {
                string query = "insert into ocorrencias(tipo_oc, descricao_oc, local_caso, nivel_risco, data_hora_ocorrido, nome_envolvido, registradopor, qtdade_envolvidos ) VALUES (@tipo_oc, @descricao_oc, @local_caso,@nivel_risco,@data_hora_ocorrido,@nome_envolvido,@registradopor,@qtdade_envolvidos)";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@tipo_oc", tipo_oc);
                cmd.Parameters.AddWithValue("@descricao_oc", descricao_oc);
                cmd.Parameters.AddWithValue("@local_caso", local_caso);
                cmd.Parameters.AddWithValue("@nivel_risco", val_nivel_risco);
                cmd.Parameters.AddWithValue("@data_hora_ocorrido", data_hora_ocorrido);
                cmd.Parameters.AddWithValue("@nome_envolvido", nome_envolvidos);
                cmd.Parameters.AddWithValue("@registradopor", RegistradoPor);
                cmd.Parameters.AddWithValue("@qtdade_envolvidos", qtade_evolvidos.Length);



                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }
    }
}


//create table problemas (
  //id_pl int auto_increment primary key,
  //titulo_pr varchar(255),
  //descricao text,
  //problemas_resolvidos text,
  //nivel_risco enum('baixo', 'medio', 'grande'),
  //data_ocorrencia date,
  //id_fun int,
  //setor_ocorrencia varchar(100),
  //foreign key (id_fun) references funcionarios(id_fun)
//);