using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TRABALHO_2
{

    class ListaDupla
    {
        
        public Celula primeiro;
        public Celula ultimo;

       
  
        public ListaDupla()
        {
          
            primeiro = new Celula();
            ultimo = primeiro;
        }
        
        
       
        public void InserirnoFim(People x)
        {
            if (primeiro == ultimo)
            {
                int indice = 0;
                Celula aux = new Celula(indice, x);
                primeiro.proximo = aux;
                aux.anterior = primeiro;
                ultimo = aux;
            }
            else
            {

                int indice = ultimo.indice + 1;
                Celula aux = new Celula(indice, x);
                ultimo.proximo = aux;
                aux.anterior = ultimo;
                ultimo = aux;
            }
        }


        public People Remover(int indice)
        {
            if (primeiro == ultimo)
            {
                throw new Exception("A lista está vazia.");
            }

            Celula atual = primeiro.proximo;
            while (atual != null && atual.indice != indice)
            {
                atual = atual.proximo;
            }

            if (atual == null)
            {
                throw new Exception("Índice não encontrado na lista.");
            }

            if (atual == ultimo)
            {
                ultimo = atual.anterior;
            }
            else
            {
                atual.proximo.anterior = atual.anterior;
            }

            atual.anterior.proximo = atual.proximo;

            People pessoaRemovida = atual.Dado;
            atual.proximo = atual.anterior = null;
            atual = null;

            return pessoaRemovida;
        }


        public void Clear()
        {
            this.primeiro = new Celula();
            this.ultimo = primeiro;
        }


       
        public void MostrarOrdenação()
        {
            for (Celula i = primeiro.proximo; i != null; i = i.proximo)
            {
                Console.WriteLine($"Indice da Lista:{i.indice} Indice da Pessoa:{i.Dado.index} Nome:{i.Dado.firstName}");
            }
        }

    
        public int Tamanho()
        {
            int tamanho = 0;
            Celula atual = primeiro.proximo;

            while (atual != null)
            {
                tamanho++;
                atual = atual.proximo;
            }

            return tamanho;
        }
        
     
        public Celula Pesquisa(string search)
        {
            Celula tmp = this.primeiro.proximo;
            while (tmp != null && tmp.Dado.firstName != search && tmp.Dado.userId != search)
            {
                tmp = tmp.proximo;
            }
            return tmp;
        }


        public Celula GetCelulaAt(int index)
        {
            Celula atual = primeiro.proximo;
            while (atual != null && atual.indice != index)
            {
                atual = atual.proximo;
            }
            return atual;
        }


        private void Swap(int i, int j)
        {
            Celula celulaI = GetCelulaAt(i);
            Celula celulaJ = GetCelulaAt(j);
            if (celulaI != null && celulaJ != null)
            {
                People temp = celulaI.Dado;
                celulaI.Dado = celulaJ.Dado;
                celulaJ.Dado = temp;
            }
        }

        public void QuickSortPorId()
        {
            QuickSortPorId(0, Tamanho() - 1);
        }


        private void QuickSortPorId(int esq, int dir)
        {
            int i = esq, j = dir;
            Celula pivoCelula = GetCelulaAt((esq + dir) / 2);
            int pivo = pivoCelula.Dado.index;
            while (i <= j)
            {
                while (GetCelulaAt(i).Dado.index < pivo) i++;
                while (GetCelulaAt(j).Dado.index > pivo) j--;
                if (i <= j)
                {
                    Swap(i, j);
                    i++;
                    j--;
                }
            }
            if (esq < j)
                QuickSortPorId(esq, j);
            if (i < dir)
                QuickSortPorId(i, dir);
        }

       
        public void QuickSortPorNome()
        {
            QuickSortPorNome(0, Tamanho() - 1);
        }


        private void QuickSortPorNome(int esq, int dir)
        {
            int i = esq, j = dir;
            Celula pivoCelula = GetCelulaAt((esq + dir) / 2);
            string pivo = pivoCelula.Dado.firstName;
            while (i <= j)
            {
                while (string.Compare(GetCelulaAt(i).Dado.firstName, pivo) < 0) i++;
                while (string.Compare(GetCelulaAt(j).Dado.firstName, pivo) > 0) j--;
                if (i <= j)
                {
                    Swap(i, j);
                    i++;
                    j--;
                }
            }
            if (esq < j)
                QuickSortPorNome(esq, j);
            if (i < dir)
                QuickSortPorNome(i, dir);
        }
    }
}
