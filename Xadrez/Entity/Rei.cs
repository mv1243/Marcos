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

        public string Nome { get; set; }
        public string Tipo { get; set; }

        public string Icone { get; set; }

        public Rei(int cor)
        {
            Nome = "Rei";
            if (cor == 1) Cor = "Branco"; Icone = "♔";  
            if (cor == 2) Cor = "Preto"; Icone = "♔";

            Tipo = "Peça";
        }

        public bool PreMovimento(int y1, int x1, int y, int x)
        {
            if (y1 == y && x1 == x )
            {
                return false;
            }

           
            if ((y1- y) < 1 && (y1 - y) > -1 || (x1 - x) < 1 && (x1 - x) > -1)
            {
                return true;
            }


            //Movimento do Rei
            //if ((y1- y) <= 1 && (y1 - y) >= -1 && (x1 - x) <= 1 && (x1 - x) >= -1 )
            //{
            //    return true;
            //}
            //return false;

            //Movimento da torre
            //if ((y1- y) < 1 && (y1 - y) > -1 || (x1 - x) < 1 && (x1 - x) > -1)
            //{
            //    return true;
            //}

            return false;
        }
        public void MoverPeca()
        {
            
        }

    }
}
