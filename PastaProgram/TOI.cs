using System;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Drawing;
namespace PastaProgram
{
    internal class TOI
    {
        public void ExecutarTOI()
        {
            Console.WriteLine("Bem vindo ao Sistema de segurança TOI");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("O que você gostaria de fazer no sistema\n C->Cadastrar Segurança\nL->Logar Como Segurança\n 1-> Cadastrar Funcionario\n 2-> Ver Gravações\n 3-> Ver Imagens\n 4-> Adcionar Video\n 5-> Adcionar Imagem\n 6-> Configurações\n 7-> Sair ");
            string opcao = Console.ReadLine();
            while(opcao.ToUpper() != "Q")
            {
                if (opcao.ToUpper() == "C")
                {
                    Seguranca sg = new Seguranca();
                    sg.DefinirLimiteMaximoSegurancas();
                    sg.CadastrarSg();
                    sg.SalvarDados();

                }
            }
        }
    }
}
    
