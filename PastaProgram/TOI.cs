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
            bool logado = false;
            Console.WriteLine("Bem vindo ao Sistema de segurança TOI");
            Console.WriteLine("-------------------------------------");
            string opcao ="";
            while (opcao.ToUpper() != "S")
            {
                Console.WriteLine("O que você gostaria de fazer no sistema\n C -> Cadastrar Segurança\n L -> Logar Como Segurança\n 1 -> Cadastrar Funcionario\n 2 -> Cadastrar Setor\n 3 -> Problemas\n 4 -> Ocorrencias\n 5 -> Adcionar Imagem\n 6 -> Configurações\n S -> Sair ");
                Console.Write("Escolha uma opção: ");
                opcao = Console.ReadLine();

                if (opcao.ToUpper() == "C")
                {
                    Seguranca sg = new Seguranca();
                    sg.DefinirLimiteMaximoSegurancas();
                    sg.CadastrarSg();
                    sg.SalvarDados();

                }
                else if (opcao.ToUpper() == "L")
                {
                    Seguranca sg = new Seguranca();
                    sg.Acesso_sg();
                    logado = true;
                }
                else if (logado == true) {
                if (opcao == "1" || opcao == "2" || opcao == "3" || opcao == "4" || opcao == "5" || opcao == "6")
                    {
                        if (opcao == "1")
                        {
                            Funcionario fun = new Funcionario();
                            fun.CadastrarFun();
                            fun.SalvarDados();
                        }
                        else if (opcao == "2")
                        {
                            CadastrarSetor Cd = new CadastrarSetor();
                            Cd.cadastrarsetor();
                            Cd.SalvarSetor();
                        }
                        else if (opcao == "3")
                        {
                            Problemas pl = new Problemas();
                            pl.RegistradoProblema();
                            pl.SalvarProblema();
                            Console.WriteLine("Adicionar gravacão do problema[S/N]");
                            string? Res = Console.ReadLine();

                            while (Res.ToUpper() != "S" && Res.ToUpper() != "N")
                            {
                                Console.WriteLine("Você digitou uma letra invalida, digite S ou N");
                                Res = Console.ReadLine();
                            }
                            if (Res.ToUpper() == "S")
                            {
                                Gravacoes Gr = new Gravacoes();
                                Gr.InserirGrav();
                                Gr.salvarGrav();
                            }
                            Console.WriteLine("Adicionar imagem do problema[S/N]");
                            string? Res2 = Console.ReadLine();

                            while (Res2.ToUpper() != "S" && Res2.ToUpper() != "N")
                            {

                                Console.WriteLine("Você digitou uma letra invalida, digite S ou N");
                                Res2 = Console.ReadLine();
                            }
                            if (Res2.ToUpper() == "S")
                            {
                                Imagens Img = new Imagens();
                                Img.InserirIMG();
                                Img.SalvarImagem();
                            }
                        }
                        else if (opcao == "4")
                        {
                            Ocorrencias Oc = new Ocorrencias();
                            Oc.RegistrandoOcorrencia();
                            Oc.OcorrenciaBanco();

                            Console.WriteLine("Adicionar gravacão da ocorrencia[S/N]");
                            string? Res = Console.ReadLine();

                            while (Res.ToUpper() != "S" && Res.ToUpper() != "N")
                            {
                                Console.WriteLine("Você digitou uma letra invalida, digite S ou N");
                                Res = Console.ReadLine();
                            }
                            if (Res.ToUpper() == "S")
                            {
                                Gravacoes Gr = new Gravacoes();
                                Gr.InserirGrav();
                                Gr.salvarGrav();
                            }
                            Console.WriteLine("Adicionar imagem do ocorrencia[S/N]");
                            string? Res2 = Console.ReadLine();

                            while (Res2.ToUpper() != "S" && Res2.ToUpper() != "N")
                            {

                                Console.WriteLine("Você digitou uma letra invalida, digite S ou N");
                                Res2 = Console.ReadLine();
                            }
                            if (Res2.ToUpper() == "S")
                            {
                                Imagens Img = new Imagens();
                                Img.InserirIMG();
                                Img.SalvarImagem();
                            }
                        }

                        if (opcao == "5")
                        {

                        }
                    }
                }
                else {
                    Console.Write("Você deve logar como segurança para ter acesso ao conteudo");
                    System.Threading.Thread.Sleep(2500);
                }
                }
            }
        }
    }