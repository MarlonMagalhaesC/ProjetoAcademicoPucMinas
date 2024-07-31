using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRABALHO_2
{ 
    class Operações
    {
      
        public void Exibir(Dados MeusDados)
        {
          
            ListaDupla Lista;
      
            Lista = MeusDados.Listar();
        
            Celula i = Lista.primeiro.proximo;
       
            while (i != null)
            {
                Console.WriteLine(i.Dado.ToString());
                i = i.proximo;
            }
            
            Console.ReadKey();
            Console.Clear();
        }
        
        

        public void LerCSV(Dados MeusDados, int dado)
        {
           
            MeusDados.LerArquivo(dado);
            Console.ReadKey();
        }
        
        
     
        public void Inserir(People x, Dados MeusDados)
        {
            
            x.LêDados();
            
            MeusDados.InserirPeople(x);
        }

        public void Alterar(Dados MeusDados)
        {
          
            ListaDupla listaDuplaAlterar = MeusDados.Listar();
        
          
            Console.Write("Digite o 'Index' do usuário que você quer alterar: ");
     
            int indiceUsuarioAlteracao = int.Parse(Console.ReadLine());

            int indiceParaAlterar = indiceUsuarioAlteracao - 1;

            
            Celula celulaParaAlterar = listaDuplaAlterar.GetCelulaAt(indiceParaAlterar);

          
            if (celulaParaAlterar != null)
            {
              
                Console.WriteLine($"\nDados atuais do usuário:\n{celulaParaAlterar.Dado}");

               
                Console.WriteLine("Digite os novos dados do usuário:");
             
                People novosDadosUsuario = new People();
               
                novosDadosUsuario.LêDados();

                celulaParaAlterar.Dado.firstName = novosDadosUsuario.firstName;
                celulaParaAlterar.Dado.lastName = novosDadosUsuario.lastName;
                celulaParaAlterar.Dado.sex = novosDadosUsuario.sex;
                celulaParaAlterar.Dado.email = novosDadosUsuario.email;
                celulaParaAlterar.Dado.dateOfBirth = novosDadosUsuario.dateOfBirth;
                celulaParaAlterar.Dado.jobTitle = novosDadosUsuario.jobTitle;

              
                Console.WriteLine("\nDados do usuário alterados com sucesso!");
            }
            else
            {
               
                Console.WriteLine("\nErro ao alterar dados: Index não encontrado..");
            }

            Console.WriteLine("===============================\n");
        }

        public void Excluir(Dados MeusDados)
        {
          
            ListaDupla listaDupla = MeusDados.Listar();

          
            Console.Write("Digite o número do 'Index' para excluir a respectiva pessoa: ");

            try
            {
                
                int indiceUsuario = int.Parse(Console.ReadLine());

                
                int indiceParaExcluir = indiceUsuario - 1;

              
                People pessoaRemovida = listaDupla.Remover(indiceParaExcluir);

              
                listaDupla.primeiro.indice -= 1;

                
                Celula celulaAtual = listaDupla.primeiro.proximo;
                while (celulaAtual != null)
                {
                    if (celulaAtual.indice >= indiceParaExcluir)
                    {
                        celulaAtual.indice -= 1;
                        celulaAtual.Dado.index -= 1; 
                    }
                    celulaAtual = celulaAtual.proximo;
                }

                
                Console.WriteLine($"\nPessoa removida: {pessoaRemovida.firstName} {pessoaRemovida.lastName}");
                Console.WriteLine("===============================\n");
            }
            catch 
            {
                
                Console.WriteLine($"\nErro ao excluir pessoa: Index não encontrado.");
                Console.WriteLine("===============================\n");
            }
        }

       
        public void Pesquisar(Dados MeusDados)
        {
            int opcaoPesquisa;
            string search;
            Celula MeuDadoPesquisa;
       
            Console.Clear();
            Console.WriteLine("===SELEÇÃO MÉTODO DE PESQUISA===\n");
            Console.WriteLine("1 - ID");
            Console.WriteLine("2 - NOME");

            Console.Write("\nOpção: ");
            opcaoPesquisa = int.Parse(Console.ReadLine());


            switch (opcaoPesquisa)
            {
                case 1:
                    Console.Write("\nINFORME O ID DESEJADO: ");
                    search = Console.ReadLine();
                    MeuDadoPesquisa = MeusDados.Cadastro.Pesquisa(search);
                    if (MeuDadoPesquisa != null)
                    {
                        Console.Write("\nPESSOA ENCONTRADA: ");
                        Console.WriteLine(MeuDadoPesquisa.Dado.ToString());
                    }

                    else
                        Console.WriteLine("\nO ID DESEJADO NÃO FOI ENCONTRADO");
                    break;

                case 2:
                    Console.Write("\nINFORME O NOME DESEJADO: ");
                    search = Console.ReadLine();
                    MeuDadoPesquisa = MeusDados.Cadastro.Pesquisa(search);
                    if (MeuDadoPesquisa != null)
                    {
                        Console.Write("\nPESSOA ENCONTRADA: ");
                        Console.WriteLine(MeuDadoPesquisa.Dado.ToString());
                    }

                    else
                        Console.WriteLine("\nO NOME DESEJADO NÃO FOI ENCONTRADO");

                    break;
                
                }
            }

         }
}
