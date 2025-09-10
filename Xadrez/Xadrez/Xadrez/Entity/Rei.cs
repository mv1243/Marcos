using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xadrez.Interface;

namespace Xadrez.Entity
{
    public class Rei : IPeca
    {
        public string Cor { get; set; }
        
        public string Tipo { get; set; }

        public string Icone { get; set; }

        public Rei(int cor)
        {
            
            if (cor == 1) Cor = "Branco"; Icone = "♔";  
            if (cor == 2) Cor = "Preto"; Icone = "♔";

            Tipo = "Peça";
        }

        public void MoverPeca(IPeca rei)
        {
            static bool ValidarMovimento(int y1, int x1, int y2, int x2)
            {
                int[] localatual = { y1, x1 };

                int[] localfuturo = { y2, x2 };

                if (y1 - y2 <= 1 && y1 - y2 >= -1 && x1 <= 1 && x1 >= -1)
                {
                    return true;
                }
                return false;
            }
        }

    }
}
