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



        public void RegistradoOcorrencia()
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

            Console.Write("Nivel de risco(Escolha uma da opções):\n1->Baixo\n2->Medio\n3->Grande\n4->Auto Risco ");
            nivel_risco = int.Parse(Console.ReadLine());
            this.nivel_risco = nivel_risco;

            while (nivel_risco == 1 || nivel_risco == 2 || nivel_risco == 3)
            {
                if (nivel_risco == 1)
                {
                    string val_nivel_risco = "baixo";
                }
                if (nivel_risco == 2)
                {
                    string val_nivel_risco = "medio";
                }
                if (nivel_risco == 3)
                {
                    string val_nivel_risco = "grande";
                    this.val_nivel_risco = val_nivel_risco;

                }
                if (nivel_risco == 4)
                {
                    string val_nivel_risco = "auto Risco";
                    this.val_nivel_risco = val_nivel_risco;
                }
            }
            Console.Write("Data do ocorrido(Preencha os todos os campos se possivel):");
            Console.Write("Ano:");
            ano_oc = Console.ReadLine();
            this.ano_oc = ano_oc;

            Console.Write("Mẽs:");
            mes_oc = Console.ReadLine();
            this.mes_oc = mes_oc;

            Console.Write("Dia:");
            dia_oc = Console.ReadLine();
            this.dia_oc = dia_oc;

            Console.Write("Horas:");
            hora_oc = Console.ReadLine();
            this.hora_oc = hora_oc;

            Console.Write("Minutos(Opcional):");
            min_oc = Console.ReadLine();
            this.min_oc = min_oc;
            if (string.IsNullOrWhiteSpace(min_oc)) min_oc = "00";

            Console.Write("Segundos(Opcional):");
            seg_oc = Console.ReadLine();
            this.seg_oc = seg_oc;
            if (string.IsNullOrWhiteSpace(seg_oc)) seg_oc = "00";

            Console.Write("Quantos Envolvidos:");
            a = int.Parse(Console.ReadLine()!);
            this.a = a;
            this.qtade_evolvidos = new string[(int)a]; ;

            data_hora_ocorrido = $"{ano_oc}-{mes_oc.PadLeft(2, '0')}-{dia_oc.PadLeft(2, '0')} {hora_oc.PadLeft(2, '0')}:{min_oc.PadLeft(2, '0')}:{seg_oc.PadLeft(2, '0')}";
            this.data_hora_ocorrido = data_hora_ocorrido;

            
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