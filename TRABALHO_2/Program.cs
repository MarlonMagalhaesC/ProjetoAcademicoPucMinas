using System;

namespace TRABALHO_2
{
    class Program
    {
        static void Main(string[] args)
        {
           Menu MeuMenu = new Menu(new Operações(), new Dados());
           MeuMenu.MostraMenu();
        }
    }
}
