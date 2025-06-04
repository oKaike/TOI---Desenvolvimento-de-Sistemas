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
        public string? nivel_risco enum('baixo','medio','grande'),
        public string? data_hora_ocorrido;
        public string? envolvidos;
        public string? registradopor;

        public void RegistradoOcorrencia() {
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

            Console.Write("");
        }
    }
}