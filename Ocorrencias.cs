using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
namespace DLL
{
    public class Ocorrencias
    {
        public string tipo_oc;
        public string descricao_oc;
        public string local_caso;
        public int nivel_risco;
        public string data_hora_ocorrido;
        public string dia_oc;
        public string ano_oc;
        public string mes_oc;
        public string hora_oc;
        public string min_oc;
        public string seg_oc;
        public string nome_envolvidos;
        public string RegistradoPor;
        public string val_nivel_risco;
        public int a;
        public string[] qtade_evolvidos;



        public void RegistrandoOcorrencia()
        {
            Console.WriteLine("Registrar Ocorrencia(Preencha as informações):");

            Console.Write("Tipo de Ocorrencia(Crime):");
            tipo_oc = Console.ReadLine();
            this.tipo_oc = tipo_oc;

            Console.Write("Descrição(Breve resumo do que aconteceu):");
            descricao_oc = Console.ReadLine();
            this.descricao_oc = descricao_oc;

            Console.Write("Local do acotencido:");
            local_caso = Console.ReadLine();
            this.local_caso = local_caso;

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
            a = int.Parse(Console.ReadLine());
            this.a = a;
            this.qtade_evolvidos = new string[(int)a];

            int preenchido = 0;
            string nome_envolvidos = "";
            string resposta = "S";

            while (resposta.ToUpper() == "S")
            {
                Console.Write("Nome dos suspeitos (pelo menos um): ");
                string nome = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(nome))
                {
                    Console.WriteLine("Você deve digitar pelo menos um nome!");
                    continue;
                }

                if (string.IsNullOrEmpty(nome_envolvidos))
                    nome_envolvidos = nome;
                else
                    nome_envolvidos += "," + nome;

                Console.Write("Deseja continuar adicionando suspeitos? [S/N]: ");
                resposta = Console.ReadLine();

                while (resposta.ToUpper() != "S" && resposta.ToUpper() != "N")
                {
                    Console.Write("Valor inválido! Digite apenas S ou N: ");
                    resposta = Console.ReadLine();
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
        public void ListarEExcluirOcorrencia()
        {
            ConexaoBD banco = new ConexaoBD();
            using (MySqlConnection conn = banco.Conectar())
            {
                conn.Open();

                // 1. Listar ocorrências
                string listarQuery = "SELECT id_oc, tipo_oc, data_hora_ocorrido FROM ocorrencias";
                MySqlCommand listarCmd = new MySqlCommand(listarQuery, conn);

                Console.WriteLine("\nOcorrências registradas:\n");

                using (MySqlDataReader reader = listarCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32("id_oc");
                        string tipo = reader.GetString("tipo_oc");
                        DateTime data = reader.GetDateTime("data_hora_ocorrido");

                        Console.WriteLine($"ID: {id} | Tipo: {tipo} | Data/Hora: {data}");
                    }
                }

                // 2. Escolher ID para exclusão
                Console.Write("\nDigite o ID da ocorrência que deseja excluir (ou 0 para cancelar): ");
                if (int.TryParse(Console.ReadLine(), out int idExcluir) && idExcluir != 0)
                {
                    Console.Write("Tem certeza que deseja excluir? (s/n): ");
                    string confirmacao = Console.ReadLine().ToLower();

                    if (confirmacao == "s")
                    {
                        string deleteQuery = "DELETE FROM ocorrencias WHERE id_oc = @id_oc";
                        MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, conn);
                        deleteCmd.Parameters.AddWithValue("@id_oc", idExcluir);

                        int resultado = deleteCmd.ExecuteNonQuery();

                        if (resultado > 0)
                            Console.WriteLine("Ocorrência excluída com sucesso!");
                        else
                            Console.WriteLine("Nenhuma ocorrência encontrada com esse ID.");
                    }
                    else
                    {
                        Console.WriteLine("Exclusão cancelada.");
                    }
                }
                else
                {
                    Console.WriteLine("Operação cancelada ou ID inválido.");
                }

                conn.Close();
            }
        }

    }
}
