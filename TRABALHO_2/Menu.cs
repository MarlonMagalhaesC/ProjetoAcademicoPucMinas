using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TRABALHO_2
{
 
    class Menu
    {
   
        private Operações MinhaOperação;
        private Dados MeusDados;
        
        public Menu(Operações O, Dados D)
        {
            MinhaOperação = O;
            MeusDados = D;
        }

     
        public void MostraMenu()
        {
            Console.Clear();
            int Opção;
            do
            {
                Console.Clear();
                Console.WriteLine("===SISTEMA DE CADASTRO DE USUÁRIOS===\n");
                Console.WriteLine("1 - Inserir");
                Console.WriteLine("2 - Alterar");
                Console.WriteLine("3 - Excluir");
                Console.WriteLine("4 - Pesquisar");
                Console.WriteLine("5 - Exibir");
                Console.WriteLine("6 - Ordenar por Index");
                Console.WriteLine("7 - Ordenar por Nome");
                Console.WriteLine("8 - Salvar");
                Console.WriteLine("9 - Carregar");
                Console.WriteLine("0 - Sair");

                Console.Write("\nOpção: ");
                Opção = int.Parse(Console.ReadLine());
             
                switch (Opção)
                {
                    case 1:
                        do { 
                        Console.Clear();

                        Console.WriteLine("Cadastro de Usuário");
                        Console.WriteLine("===================\n");
                        MinhaOperação.Inserir(new People(), MeusDados);
                        Console.WriteLine("\nInserir outro Registro? (ESC Cancela...)");

                        } while (Console.ReadKey().Key != ConsoleKey.Escape);
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Alteração de Dados de Usuário");
                        Console.WriteLine("===========================\n");
                        MinhaOperação.Alterar(MeusDados);
                        Console.ReadKey();
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Exclusão de Usuário do Cadastro");
                        Console.WriteLine("=============================\n");
                        MinhaOperação.Excluir(MeusDados);
                        Console.ReadKey();
                        break;

                    case 4:
                        Console.Clear();

                        Console.WriteLine("Pesquisa de Usuário no Cadastro");
                        Console.WriteLine("===============================\n");
                        MinhaOperação.Pesquisar(MeusDados);
                        Console.ReadKey();


                        break;
                    case 5:
                        Console.Clear();

                        Console.WriteLine("Exibe Usuários Cadastrado");
                        Console.WriteLine("=========================\n");

                        MinhaOperação.Exibir(MeusDados);

                        break;
                    case 6:
                        Console.Clear();

                        Console.WriteLine("Ordenar Usuários por Index");
                        Console.WriteLine("=======================\n");

                        MeusDados.Cadastro.QuickSortPorId();
                        Console.WriteLine("Usuários ordenados por Index com sucesso.\n");
                        MinhaOperação.Exibir(MeusDados);
                        break;
                    case 7:
                        Console.Clear();
                        Console.WriteLine("Ordenar Usuários por Nome");
                        Console.WriteLine("=========================\n");

                        MeusDados.Cadastro.QuickSortPorNome();
                        Console.WriteLine("Usuários ordenados por Nome com sucesso.\n");
                        MinhaOperação.Exibir(MeusDados);
                        break;
                    case 8:
                        Console.Clear();
                        int OpçãoSave;

                        Console.WriteLine("Salvar Dados em Arquivo CSV");
                        Console.WriteLine("===========================\n");


                        Console.WriteLine("=== GERENCIAMENTO DE ARQUIVOS ===\n");
                        
                        Console.WriteLine("1 - Salvar em arquivo de 3 pessoas");
                        Console.WriteLine("2 - Salvar em arquivo de 5 pessoas");
                        Console.WriteLine("3 - Salvar em arquivo de 8 pessoas");
                        Console.WriteLine("4 - Salvar em arquivo de 10 pessoas");

                        Console.Write("\nEscolha uma opção: ");
                        OpçãoSave = int.Parse(Console.ReadLine());
                        
                        MeusDados.SalvarArquivoCSV(OpçãoSave);
                        break;
                    case 9:
                        Console.Clear();
                        int OpçãoCarrega;
                       
                        Console.WriteLine("Carrega Dados de Arquivo CSV");
                        Console.WriteLine("============================\n");

                        Console.WriteLine("=== GERENCIAMENTO DE ARQUIVOS ===\n");
                     
                        Console.WriteLine("1 - Carregar arquivo de 3 pessoas");
                        Console.WriteLine("2 - Carregar arquivo de 5 pessoas");
                        Console.WriteLine("3 - Carregar arquivo de 8 pessoas");
                        Console.WriteLine("4 - Carregar arquivo de 10 pessoas");

                        Console.Write("\nEscolha uma opção: ");
                        OpçãoCarrega = int.Parse(Console.ReadLine());
                        
                        MinhaOperação.LerCSV(MeusDados, OpçãoCarrega);
                        break;
                    case 0:
                        Console.Clear();

                        Console.Write("\nSaída do sistema...");
                        Thread.Sleep(3000);
                        break;
                }
            } while (Opção != 0);
        }
    }
}
