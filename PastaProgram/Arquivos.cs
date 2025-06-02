using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PastaProgram{
public class Arquivos
{
    public string Nome_aq;
    public string Finalidade_aq;
    public string NovaPasta;

    public void CriacaoPasta()
    {
        Console.WriteLine("Criar Pasta (Preencha as informações abaixo):");
        Console.Write("Nome:");
        this.Nome_aq = Console.ReadLine();
        Nome_aq = this.Nome_aq;

        Console.Write("Finalidade:");
        this.Finalidade_aq = Console.ReadLine();
        Finalidade_aq = this.Finalidade_aq;
        string desktop = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));

        this.NovaPasta = Path.Combine(desktop, Nome_aq);
        NovaPasta = this.NovaPasta;

        if (!Directory.Exists(NovaPasta))
        {
            Directory.CreateDirectory(NovaPasta);
            Console.WriteLine("Pasta criada: " + NovaPasta);

        }
        else
        {
            Console.WriteLine("A pasta já existe.");
        }

    }

    public void CriarArquivo()
    {
        ConexaoBD banco = new ConexaoBD();
        using (MySqlConnection conn = banco.Conectar())
        {
            string query = "select Nome_fun, cpf_fun, sexo_fun from funcionarios";
 
            MySqlCommand cmd = new MySqlCommand(query, conn);
            conn.Open();
            using var reader = cmd.ExecuteReader();

            using StreamWriter escritor = new StreamWriter(NovaPasta);
            while (reader.Read())
            {
            string nome = reader.GetString("Nome_fun");
            string CPF = reader.GetString("cpf_fun");
                    escritor.WriteLine($"Nome:{nome} e CPF:{CPF}");
            }
            File.WriteAllText(Path.Combine(NovaPasta, "exemplo1.txt"), "Este é o primeiro arquivo.");
       
        cmd.ExecuteNonQuery();
        conn.Close();
        }

    }
}
}
