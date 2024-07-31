using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRABALHO_2
{    
    class People
    {
      
        public int index { get; set; }
        public string userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string sex { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string dateOfBirth { get; set; }
        public string jobTitle { get; set; }

        
        
        public People(int index = 0, string userId = "", string firstName = "", string lastName = "", string sex = "", string email = "", string phone = "", string dateOfBirth = "", string jobTitle = "")
        {
            this.index = index; 
            this.userId = userId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.sex = sex;
            this.email = email;
            this.phone = phone; 
            this.dateOfBirth = dateOfBirth;
            this.jobTitle = jobTitle;

        }

        
        
        public void LêDados()
        {
       
            this.userId = Guid.NewGuid().ToString().Substring(9, 18).Replace("-", "");
            Console.Write("Nome.................: ");
            this.firstName = Console.ReadLine();
            Console.Write("Sobrenome............: ");
            this.lastName = Console.ReadLine();
            Console.Write("Sexo................: ");
            this.sex = Console.ReadLine();
            Console.Write("E-mai...............: ");
            this.email = Console.ReadLine();
            Console.Write("Telefone............: ");
            this.phone = Console.ReadLine();
            Console.Write("Data de Nascimento..: ");
            this.dateOfBirth = Console.ReadLine();
            Console.Write("Profissão...........: ");
            this.jobTitle = Console.ReadLine();         
        }
        
      
        public override string ToString()
        {
            return $" {index} ## {userId} ## {firstName} ## {lastName} ## {sex} ## {email} ## {phone} ## {dateOfBirth} ## {jobTitle} \n";
        }
    }
}
