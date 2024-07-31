using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TRABALHO_2
{
    
    class Celula
    {

        public People Dado;
  
        public Celula proximo;
      
        public Celula anterior;
  
        public int indice;
        
        
        public Celula(int indice = 0, People Dado = null)
        {
            
            this.Dado = Dado;
            this.proximo = null;
            this.anterior = null;
            this.indice = indice;
        }
    }
}
