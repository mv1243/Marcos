using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xadrez.Entity;
using Xadrez.Interface;

namespace Xadrez
{
    internal class Tabuleiro
    {
        int[,] Campo =
        {
            { 1, 0, 1, 0, 1, 0, 1, 0},
            { 0, 1, 0, 1, 0, 1, 0, 1},
            { 1, 0, 1, 0, 1, 0, 1, 0},
            { 0, 1, 0, 1, 0, 1, 0, 1},
            { 1, 0, 1, 0, 1, 0, 1, 0},
            { 0, 1, 0, 1, 0, 1, 0, 1},
            { 1, 0, 1, 0, 1, 0, 1, 0},
            { 0, 1, 0, 1, 0, 1, 0, 1}
        };

        List<Interface.IPeca> Pecas = [new Rei("Branco", 7, 4)];

        public void MontarTabuleiro()
        {
            // Posição Y e X do cursor
            int[] posicao = [0, 0];
            bool peca_selecionada = false;
           
            while (true)
            {
                Console.Clear();

                if (peca_selecionada) PecaSelecionada(posicao);


                Console.WriteLine("  ┌────────────────────────┐");
                int n = 8;
                for (int y = 0; y < 8; y++)
                {
                    Console.Write(n + " │");
                    for (int x = 0; x < 8; x++)
                    {
                        EsreverCampo(y, x, posicao);
                    }
                    n--;
                    Console.Write("│");
                    Console.WriteLine();
                }

                Console.WriteLine("  └────────────────────────┘");
                Console.WriteLine("    A  B  C  D  E  F  G  H");

                posicao = MenuMovimento(posicao, ref peca_selecionada);
            }

        }

        private int[] MenuMovimento(int[] posicao, ref bool peca_selecionada)
        {
            
            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.DownArrow: if (posicao[0] < 7) posicao[0]++; break;

                case ConsoleKey.UpArrow: if (posicao[0] > 0) posicao[0]--; break;

                case ConsoleKey.RightArrow: if (posicao[1] < 7) posicao[1]++; break;

                case ConsoleKey.LeftArrow: if (posicao[1] > 0) posicao[1]--; break;

                case ConsoleKey.Enter:
                    peca_selecionada = true;
                    break;
            }
            return posicao;

        }

        private void EsreverCampo(int y, int x, int[] posicao)
        {
            var peca = Pecas.Find(p => p.Posicao_X == x && p.Posicao_Y == y);
            if (posicao[0] == y && posicao[1] == x)
            {               
                if (peca != null)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.Write($"[{peca.Icone}]");
                    Console.ResetColor();
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.Write(Campo[y, x] == 1 ? "[■]" : "[□]");
                    Console.ResetColor();
                }               
            }
            else
            {                
                if (peca != null)
                {                    
                    Console.Write($"[{peca.Icone}]");                    
                }
                else
                {               
                    Console.Write(Campo[y, x] == 1 ? "[■]" : "[□]");                
                }
            }                       
        }

        private void PecaSelecionada(int[] posicao)
        {
            var peca = Pecas.Find(p => p.Posicao_Y == posicao[0] && p.Posicao_X == posicao[1]);
            if (peca != null)
            {
                Console.WriteLine($"Peça Selecionada:{peca.Nome}");
                Console.WriteLine($"Cor:{peca.Cor}");
                Console.WriteLine($"Posição:{Utils.Coordenados_Para_Notaçao(peca.Posicao_X, peca.Posicao_Y)}");

            }
            else
            {
                Console.WriteLine("Nenhuma Peça foi Selecionada");
            }
        }
    }
}
