using System;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Drawing;
using PastaProgram;
using System.IO;

namespace PastaProgram
{
    internal class Painel_Ests
    {
        public int qtdade_problemas;
        public int qtdade_ocorrencias;
        public string? setorcommaisocorrencia;
        public string? setorcommaisproblemas;
        public string? ultimo_registro;

        public void qtd_problemas()
        {
            int totalProblemas = 0;
            ConexaoBD banco = new ConexaoBD();

            using (MySqlConnection conn = banco.Conectar())
            {
                conn.Open();
                string queryCount = "select count(id_oc) from ocorrencias";
                using (MySqlCommand cmd = new MySqlCommand(queryCount, conn))
                {
                    totalProblemas = Convert.ToInt32(cmd.ExecuteScalar());
                    this.qtdade_problemas = totalProblemas;
                }
            }
        }
        public void qtd_ocorrencias()
        {
            int totalOcorrencias = 0;
            ConexaoBD banco = new ConexaoBD();

            using (MySqlConnection conn = banco.Conectar())
            {
                conn.Open();
                string queryCount = "SELECT COUNT(id_pl) FROM problemas";

                using (MySqlCommand cmd = new MySqlCommand(queryCount, conn))
                {
                    totalOcorrencias = Convert.ToInt32(cmd.ExecuteScalar());
                    this.qtdade_ocorrencias = totalOcorrencias;
                }
            }

        }
        public void Estatiscas()
        {
            Console.Write("-----Estatisticas-----\n");
            Console.Write("Quantidade de problemas:{0}", qtdade_ocorrencias);
            Console.Write("\nQuantidade de ocorrencias:{0}", qtdade_problemas);

        }

        public void setorComMaisOC(){

            ConexaoBD banco = new ConexaoBD();
            using (MySqlConnection conn = banco.Conectar())
            {
                conn.Open();
                string querySetoresOC = @"
                SELECT setor_pr, COUNT(*) 
                FROM problemas 
                GROUP BY setor_pr 
                ORDER BY total DESC 
                LIMIT 1";
                using (MySqlCommand cmd = new MySqlCommand(querySetoresOC, conn))
                {

                }
            }
        }
    }
}

