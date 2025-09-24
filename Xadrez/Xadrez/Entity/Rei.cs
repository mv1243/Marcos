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
            if (
                //MoverCima(posicao, Pecas) ||
                //MoverBaixo(posicao, Pecas) ||
                //MoverDireita(posicao, Pecas) ||
                //MoverEsquerda(posicao, Pecas) ||
                MoverDiagonalCimaEsquerda(posicao, Pecas)
                ) return true;
            return false;

            bool MoverCima(int[] posicao, List<IPeca> pecas)
            {

                var list_peca = Pecas.Where(p => p.Posicao_X == posicao[1] && p.Posicao_Y < this.Posicao_Y);
                var peca_mais_proxima = list_peca.OrderByDescending(p => p.Posicao_Y).FirstOrDefault();

                if (posicao[1] == this.Posicao_X && posicao[0] < this.Posicao_Y)
                {
                    if (peca_mais_proxima is not null)
                    {

                        if (posicao[0] >= peca_mais_proxima.Posicao_Y) return true;

                        else return false;

                    }
                    else return true;

                }
                return false;
            }
            bool MoverBaixo(int[] posicao, List<IPeca> pecas)
            {

                var list_peca = Pecas.Where(p => p.Posicao_X == posicao[1] && p.Posicao_Y > this.Posicao_Y);
                var peca_mais_proxima = list_peca.OrderByDescending(p => p.Posicao_Y).FirstOrDefault();

                if (posicao[1] == this.Posicao_X && posicao[0] > this.Posicao_Y)
                {
                    if (peca_mais_proxima is not null)
                    {

                        if (posicao[0] <= peca_mais_proxima.Posicao_Y) return true;

                        else return false;

                    }
                    else return true;

                }
                return false;
            }
            bool MoverDireita(int[] posicao, List<IPeca> pecas)
            {

                var list_peca = Pecas.Where(p => p.Posicao_Y == posicao[0] && p.Posicao_X > this.Posicao_X);
                var peca_mais_proxima = list_peca.OrderByDescending(p => p.Posicao_Y).FirstOrDefault();

                if (posicao[0] == this.Posicao_Y && posicao[1] > this.Posicao_X)
                {
                    if (peca_mais_proxima is not null)
                    {

                        if (posicao[1] <= peca_mais_proxima.Posicao_X) return true;

                        else return false;

                    }
                    else return true;

                }
                return false;
            }
            bool MoverEsquerda(int[] posicao, List<IPeca> pecas)
            {

                var list_peca = Pecas.Where(p => p.Posicao_Y == posicao[0] && p.Posicao_X < this.Posicao_X);
                var peca_mais_proxima = list_peca.OrderByDescending(p => p.Posicao_Y).FirstOrDefault();

                if (posicao[0] == this.Posicao_Y && posicao[1] < this.Posicao_X)
                {
                    if (peca_mais_proxima is not null)
                    {

                        if (posicao[1] >= peca_mais_proxima.Posicao_X) return true;

                        else return false;

                    }
                    else return true;

                }
                return false;
            }
            bool MoverDiagonalCimaEsquerda(int[] posicao, List<IPeca> pecas)
            {

                int resultado = this.Posicao_Y -  posicao[0];
                int resultado2 =  this.Posicao_X - posicao[1];                //quando é Diagonal direita 


                if ((this.Posicao_Y - posicao[0]) + (this.Posicao_X - posicao[1]) == 0)
                {                 
                    return true;
                }

                if (this.Posicao_Y - posicao[0] == (this.Posicao_X - posicao[1]))
                {
                    return true;
                }
               

              // && this.Posicao_Y > posicao[0] && this.Posicao_X > posicao[1]


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
