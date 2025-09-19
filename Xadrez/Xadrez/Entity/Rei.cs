using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xadrez.Interface;

namespace Xadrez.Entity
{
    internal class Rei : IPeca
    {
        public string Nome { get; set; }
        public string Cor { get; set; }
        public int Posicao_X { get; set; }
        public int Posicao_Y { get; set; }
        public string Icone { get; set; }

        public Rei(string Cor, int Posicao_Y, int Posicao_X)
        {
            Nome = "Rei";
            this.Cor = Cor;
            this.Posicao_X = Posicao_X;
            this.Posicao_Y = Posicao_Y;

            if (Cor == "Branco")
            {
                Icone = "♚";
            }
            else
            {
                Icone = "♔";
            }
        }

    }
}
