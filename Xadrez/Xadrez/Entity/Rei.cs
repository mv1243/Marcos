using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

        public bool PreMovimento(int[] posicao, List<IPeca> Pecas)
        {
            if (MoverCima(posicao, Pecas)) return true;
            return false;

             bool MoverCima(int[] posicao, List<IPeca> pecas)
            {
              
                var list_peca = Pecas.Where(p => posicao[0] < this.Posicao_Y && p.Posicao_X == posicao[1] && p != this);
                var peca_mais_proxima = list_peca.OrderByDescending(p => p.Posicao_Y).FirstOrDefault();

                if (posicao[1] == this.Posicao_X && posicao[0] < this.Posicao_Y)
                {                  
                        if (peca_mais_proxima is not null)
                        {
                            
                            if (posicao[0] >= peca_mais_proxima.Posicao_Y && posicao[0] >=) return true;

                            else return false;

                        }
                        else return true;
                   
                }
                return false;
            }

        }

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
