using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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

        List<IPeca> Pecas = [new Rei("Branco", 7, 0), new Rei("Preto", 1, 1) ,new Rei("Preto", 2, 1)];

        public void MontarTabuleiro()
        {
            // Posição Y e X do cursor
            int[] posicao = [0, 0];
            int[] posicao_inicial = null;
            int[] posicao_final = null;
            bool peca_selecionada = false;

            while (true)
            {

                Console.Clear();




                Console.WriteLine("  ┌────────────────────────┐");
                int n = 8;
                for (int y = 0; y < 8; y++)
                {
                    Console.Write(n + " │");
                    for (int x = 0; x < 8; x++)
                    {
                        EsreverCampo(y, x, posicao, posicao_inicial, peca_selecionada);
                    }
                    n--;
                    Console.Write("│");
                    Console.WriteLine();
                }

                Console.WriteLine("  └────────────────────────┘");
                Console.WriteLine("    A  B  C  D  E  F  G  H");

                if (posicao_inicial != null)
                {
                    if (PecaSelecionada(posicao_inicial) == false)
                    {
                        posicao_inicial = null;
                    }
                    if (posicao_inicial != null)
                    {
                        DescreverProximoCampo(posicao);
                        peca_selecionada = true;
                    }
                }
                else
                {
                    DescreverCampo(posicao);
                }
                


                posicao = MenuMovimento(posicao, ref posicao_inicial, ref posicao_final);

                if (posicao_final != null)
                {
                    MoverPeca(posicao_inicial, posicao_final);
                    posicao_inicial = null;
                    posicao_final = null;
                    peca_selecionada = false;
                }
            }


        }

        private int[] MenuMovimento(int[] posicao, ref int[] posicao_inicial, ref int[] posicao_final)
        {
            var peca = Pecas.Find(p => p.Posicao_X == posicao[1] && p.Posicao_Y == posicao[0]);
            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.DownArrow: if (posicao[0] < 7) posicao[0]++; break;

                case ConsoleKey.UpArrow: if (posicao[0] > 0) posicao[0]--; break;

                case ConsoleKey.RightArrow: if (posicao[1] < 7) posicao[1]++; break;

                case ConsoleKey.LeftArrow: if (posicao[1] > 0) posicao[1]--; break;

                case ConsoleKey.Enter:
                    ;
                    if (posicao_inicial == null)
                    {
                        posicao_inicial = [posicao[0], posicao[1]];
                    }
                    else
                    {
                        if (posicao_inicial != null) posicao_final = [posicao[0], posicao[1]];
                    }

                    break;
            }
            return posicao;

        }

        private void EsreverCampo(int y, int x, int[] posicao, int[] posicao_inicial, bool peca_selecionada)
        {
            int[] campo = [y, x];
            if (peca_selecionada == true)
            {
                var pecaSelecionada = Pecas.Find(p => p.Posicao_X == posicao_inicial[1] && p.Posicao_Y == posicao_inicial[0]);
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
                    if (pecaSelecionada.PreMovimento(campo, Pecas))
                    {
                        if (peca != null)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            Console.Write($"[{peca.Icone}]");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
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
            }
            else
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


        }

        private void DescreverCampo(int[] posicao)
        {
            var peca = Pecas.Find(p => p.Posicao_Y == posicao[0] && p.Posicao_X == posicao[1]);
            string cor_do_campo = Campo[posicao[0], posicao[1]] == 1 ? "Clara" : "Escura";
            if (peca != null)
            {
                Console.WriteLine($"Cor da Casa:{cor_do_campo}");
                Console.WriteLine($"Ocupação:{peca.Nome} Cor:{peca.Cor}");
                Console.WriteLine($"Posição:{Utils.Coordenados_Para_Notaçao(peca.Posicao_X, peca.Posicao_Y)}");

            }
            else
            {

                Console.WriteLine($"Cor da Casa:{cor_do_campo}");
                Console.WriteLine($"Ocupação:Vazio");
                Console.WriteLine($"Posição:{Utils.Coordenados_Para_Notaçao(posicao[1], posicao[0])}");

            }
        }

        private void DescreverProximoCampo(int[] posicao)
        {
            var peca = Pecas.Find(p => p.Posicao_Y == posicao[0] && p.Posicao_X == posicao[1]);
            string cor_do_campo = Campo[posicao[0], posicao[1]] == 1 ? "Clara" : "Escura";
            Console.WriteLine();
            Console.WriteLine("Mover para...");
            Console.WriteLine();
            if (peca != null)
            {
                Console.WriteLine($"Cor da Casa:{cor_do_campo}");
                Console.WriteLine($"Ocupação:{peca.Nome} Cor:{peca.Cor}");
                Console.WriteLine($"Posição:{Utils.Coordenados_Para_Notaçao(peca.Posicao_X, peca.Posicao_Y)}");
            }
            else
            {
                Console.WriteLine($"Cor da Casa:{cor_do_campo}");
                Console.WriteLine($"Ocupação:Vazio");
                Console.WriteLine($"Posição:{Utils.Coordenados_Para_Notaçao(posicao[1], posicao[0])}");
            }
        }
        private bool PecaSelecionada(int[] posicao)
        {
            string cor_do_campo = Campo[posicao[0], posicao[1]] == 1 ? "Clara" : "Escura";
            var peca = Pecas.Find(p => p.Posicao_Y == posicao[0] && p.Posicao_X == posicao[1]);
            if (peca != null)
            {
                Console.WriteLine($"Cor da Casa:{cor_do_campo}");
                Console.WriteLine($"Peça Selecionada:{peca.Nome}");
                Console.WriteLine($"Cor:{peca.Cor}");
                Console.WriteLine($"Posição:{Utils.Coordenados_Para_Notaçao(peca.Posicao_X, peca.Posicao_Y)}");
                return true;
            }
            else
            {
                Console.WriteLine("Nenhuma peça foi selecionada");
                return false;
            }
        }

        private void MoverPeca(int[] posicao_inicial, int[] posicao_final)
        {
            //Para de dar a resposta
            var peca = Pecas.Find(p => p.Posicao_Y == posicao_inicial[0] && p.Posicao_X == posicao_inicial[1]);
            peca.Posicao_Y = posicao_final[0];
            peca.Posicao_X = posicao_final[1];
        }
    }
}
