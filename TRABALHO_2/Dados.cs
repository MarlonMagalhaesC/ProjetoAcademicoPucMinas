using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TRABALHO_2
{    
   
    class Dados
    {
        public ListaDupla Cadastro;
        
        
      
        public Dados()
        {
            Cadastro = new ListaDupla();
        }
       
        
      
        public void InserirUsuário(People x)
        {
            Cadastro.InserirnoFim(x);
            
        }
       
        
      
        public ListaDupla Listar()
        {
            return Cadastro;
        }
        
        
       
        public void LerArquivo(int dado)
        {
            string arquivo = $"people-{dado}.csv";

            if (File.Exists(arquivo))
            {
                Cadastro.Clear();
               
                Stream entrada = File.Open(arquivo, FileMode.Open);
                StreamReader leitor = new StreamReader(entrada);

                
                string linha;
                leitor.ReadLine();

          
                while ((linha = leitor.ReadLine()) != null)
                {
                    string[] Dados = linha.Split(',');
                    int index = int.Parse(Dados[0]);
                    string userId = Dados[1];
                    string firstName = Dados[2];
                    string lastName = Dados[3];
                    string sex = Dados[4];
                    string email = Dados[5];
                    string phone = Dados[6];
                    string dateOfBirth = Dados[7];
                    string jobTitle = Dados[8];

                    People pessoa = new People(index, userId, firstName, lastName, sex, email,phone, dateOfBirth, jobTitle);
                    Cadastro.InserirnoFim(pessoa);

                }
              
                leitor.Close();
                entrada.Close();

                Console.WriteLine("Arquivo CSV carregado com sucesso...");
            }
            else
            {
                Console.WriteLine("Arquivo CSV não localizado...");
            }
           }
        
        
      
        public void InserirPeople(People x)
        {

            if (Cadastro.Tamanho() == 0)
            {
                x.index = 1; 
            }
            else
            {
                int ultimo = Cadastro.Tamanho();
                x.index = ultimo + 1;
            }

            Cadastro.InserirnoFim(x);
        }
        public void SalvarArquivoCSV(int dado)
        {
            string arquivo = $"people-{dado}.csv";
            
            using (StreamWriter escritor = new StreamWriter(arquivo))
            {
               
                escritor.WriteLine("Index,UserId,FirstName,LastName,Sex,Email,DateOfBirth,JobTitle");

                for (Celula atual = Cadastro.primeiro.proximo; atual != null; atual = atual.proximo)
                {
                    People pessoa = atual.Dado;
                    string linha = $"{pessoa.index},{pessoa.userId},{pessoa.firstName},{pessoa.lastName},{pessoa.sex},{pessoa.email},{pessoa.phone},{pessoa.dateOfBirth},{pessoa.jobTitle}";
                    escritor.WriteLine(linha);
                }
            }
            Console.WriteLine("Dados salvos em arquivo CSV com sucesso...");
            Console.ReadKey();
        }
    }
 }
