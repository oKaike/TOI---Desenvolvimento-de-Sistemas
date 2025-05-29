using System;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Drawing;

   public void ExecutarTOI() {
    Console.WriteLine("Bem vindo ao Sistema de segurança TOI");
    Console.WriteLine("-------------------------------------");
    Console.WriteLine("O que você gostaria de fazer no sistema\n C->Cadastrar Segurança\nL->Logar Como Segurança\n 1-> Cadastrar Funcionario\n 2-> Ver Gravações\n 3-> Ver Imagens\n 4-> Adcionar Video\n 5-> Adcionar Imagem\n 6-> Configurações\n 7-> Sair ");
    string opcao = Console.ReadLine();
    if (opcao != "Q")
    {
        if (opcao .ToUpper() = "C"=) {
            
        }
    }
   }

    string connStr = "server=localhost;user=root;database=TOI;port=3306;password=bfck2345";
        MySqlConnection conn = new MySqlConnection(connStr);

        Console.WriteLine("Hello World");
        try
        {
            
            conn.Open();
            Console.WriteLine("Conexão feita com sucesso");
            Console.WriteLine("Cadastrar Usuario");
            Console.ReadLine();
            string info_fun = "insert into funcionarios(nome_fun,cpf_fun,data_nasc_fun,setor_fun) values (@nome,@cpf,@data_nasc,@setor)";
            //AOD, 
            //Comando para a conexão
            MySqlCommand cmd = new MySqlCommand(info_fun, conn);
            //Substituindo Parametros
            //cmd.Parameters.AddWithValue("@nome", nome);
           // cmd.Parameters.AddWithValue("@cpf", "12345678910");
            //cmd.Parameters.AddWithValue("@data_nasc", "1999-03-20");
            //cmd.Parameters.AddWithValue("@setor", "Setor Alimenticio");
            //Checar linhas que foram afetadas
            int LinhasAfetadas = cmd.ExecuteNonQuery();
            Console.WriteLine($"{LinhasAfetadas} Linhas Inseridas com sucesso");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message.ToString());

        }
        finally
        {
       
        }

         string videoUrl = "/home/kaike0proprio/Imagens/Capturas de tela/mongo.png";


        Process.Start(new ProcessStartInfo
        {
            FileName = videoUrl,
            UseShellExecute = true
        });