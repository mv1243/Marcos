using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using Xadrez.Entity;
using Xadrez.Interface;

namespace Xadrez;
public class Tabuleiro : ITabuleiro
{
    int[,] Campo =
     {
      { 1, 0, 1, 0, 1, 0, 1, 0 },
      { 0, 1, 0, 1, 0, 1, 0, 1 },
      { 1, 0, 1, 0, 1, 0, 1, 0 },
      { 0, 1, 0, 1, 0, 1, 0, 1 },
      { 1, 0, 1, 0, 1, 0, 1, 0 },
      { 0, 1, 0, 1, 0, 1, 0, 1 },
      { 1, 0, 1, 0, 1, 0, 1, 0 },
      { 0, 1, 0, 1, 0, 1, 0, 1 },
    };

    IPeca[,] Pecas =
    {
     {new Campo(), new Campo(), new Campo(),new Campo(), new Campo(), new Campo(), new Campo(), new Campo()},
     {new Campo(), new Campo(), new Campo(),new Campo(), new Campo(), new Campo(), new Campo(), new Campo()},
     {new Campo(), new Campo(), new Campo(),new Campo(), new Campo(), new Campo(), new Campo(), new Campo()},
     {new Campo(), new Campo(), new Campo(),new Campo(), new Campo(), new Campo(), new Campo(), new Campo()},
     {new Campo(), new Campo(), new Campo(),new Rei(1), new Campo(), new Campo(), new Campo(), new Campo()},
     {new Campo(), new Campo(), new Campo(),new Campo(), new Campo(), new Campo(), new Campo(), new Campo()},
     {new Campo(), new Campo(), new Campo(),new Campo(), new Campo(), new Campo(), new Campo(), new Campo()},
     {new Campo(), new Campo(), new Campo(),new Campo(), new Campo(), new Campo(), new Campo(), new Campo()},
    };


    string ITabuleiro.Tipo => "Campo";

    private void Montar_Campo(int y, int x, int pos_y, int pos_x, bool pre_movimento = false, int y1 = 0, int x1 = 0)
    {
        if (pre_movimento)
        {

            if (pos_y == y && pos_x == x)
            {
                if (Pecas[y, x].Tipo == "Campo")
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.Write($"[{Definir_Campo(Campo[y, x])}]");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                if (Pecas[y, x].Tipo == "Peça")
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.Write($"[{Pecas[y, x].Icone}]");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }
            else
            {
                if (Pecas[y1, x1].PreMovimento(y1, x1, y, x))
                {
                    if (Pecas[y, x].Tipo == "Campo")
                    {
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.Write($"[{Definir_Campo(Campo[y, x])}]");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    if (Pecas[y, x].Tipo == "Peça")
                    {
                        
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.Write($"[{Pecas[y, x].Icone}]");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }

                }
                else
                {
                    if (Pecas[y, x].Tipo == "Campo")
                    {
                        Console.Write($"[{Definir_Campo(Campo[y, x])}]");
                    }
                    if (Pecas[y, x].Tipo == "Peça")
                    {
                        if (Pecas[y, x] == Pecas[y1, x1])
                        {
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.Write($"[{Pecas[y, x].Icone}]");
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.Write($"[{Pecas[y, x].Icone}]");
                        }
                        
                    }
                }


            }
        }
        else
        {
            if (pos_y == y && pos_x == x)
            {
                if (Pecas[y, x].Tipo == "Campo")
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.Write($"[{Definir_Campo(Campo[y, x])}]");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                if (Pecas[y, x].Tipo == "Peça")
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.Write($"[{Pecas[y, x].Icone}]");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }
            else
            {
                if (Pecas[y, x].Tipo == "Campo")
                {
                    Console.Write($"[{Definir_Campo(Campo[y, x])}]");
                }
                if (Pecas[y, x].Tipo == "Peça")
                {
                    Console.Write($"[{Pecas[y, x].Icone}]");
                }

            }

        }

    }
    private string Definir_Campo(int valor)
    {
        if (valor == 1) return "■";
        if (valor == 0) return "□";
        return "";
    }
    private string CasaCor(int y, int x)
    {
        string campo = Definir_Campo(Campo[y, x]);
        if (campo == "⬛") return "Casa Clara";
        if (campo == "⬜") return "Casa Escura";
        return null;
    }
    public void Implimentar_Tabuleiro()
    {
        int pos_y = 0;
        int pos_x = 0;

        int y1 = 0;
        int x1 = 0;

        int y2 = 0;
        int x2 = 0;

        bool primeiro_movimento = true;
        bool pre_movimento = false;
        bool segundo_movimento = false;

        while (true)
        {
            Console.Clear();

            if (primeiro_movimento) Console.WriteLine("Selecionar Campo");

            if (segundo_movimento)
            {
                if (Pecas[y1, x1].Tipo == "Peça")
                {
                    Console.WriteLine($"Peça:{Pecas[y1, x1].Nome} {Pecas[y1, x1].Cor} Mover para...");
                    pre_movimento = true;
                }
                if (Pecas[y1, x1].Tipo == "Campo")
                {
                    Console.WriteLine("Nenhuma Peça foi selecionada");
                    segundo_movimento = false;
                }

            }


            DescricaoMovimento(pos_x, pos_y);
            Console.WriteLine(CasaCor(pos_y, pos_x));
            ConsoleKeyInfo key = default;

            Console.WriteLine("  ┌────────────────────────┐");
            int n = 8;
            for (int y = 0; y < 8; y++)
            {

                Console.Write(n + " │");


                for (int x = 0; x < 8; x++)
                {
                    if (segundo_movimento && pre_movimento)
                    {
                        Montar_Campo(y, x, pos_y, pos_x, pre_movimento, y1, x1);
                    }
                    else
                    {
                        Montar_Campo(y, x, pos_y, pos_x);
                    }


                }
                n--;
                Console.Write("│");
                Console.WriteLine();

            }

            Console.WriteLine("  └────────────────────────┘");
            Console.WriteLine("    A  B  C  D  E  F  G  H");
            key  = Console.ReadKey();
            MenuMovimento(ref pos_x, ref pos_y, key, ref primeiro_movimento, ref segundo_movimento, ref y1, ref x1, ref y2, ref x2);



            Console.WriteLine();


            void MenuMovimento(ref int pos_x, ref int pos_y, ConsoleKeyInfo key, ref bool primeiro_movimento, ref bool segundo_movimento, ref int y1, ref int x1, ref int y2, ref int x2)
            {


                switch (key.Key)
                {
                    case ConsoleKey.DownArrow: if (pos_y < 7) pos_y++; break;

                    case ConsoleKey.UpArrow: if (pos_y > 0) pos_y--; break;

                    case ConsoleKey.RightArrow: if (pos_x < 7) pos_x++; break;

                    case ConsoleKey.LeftArrow: if (pos_x > 0) pos_x--; break;

                    case ConsoleKey.Enter:
                        if (primeiro_movimento)
                        {
                            primeiro_movimento = false;
                            segundo_movimento = true;
                            y1 = pos_y;
                            x1 = pos_x;
                        }
                        else
                        {
                            primeiro_movimento = true;
                            segundo_movimento = false;
                            y2 = pos_y;
                            x2 = pos_x;
                        }
                        break;
                }

            }

            static void DescricaoMovimento(int pos_x, int pos_y)
            {
                string letra = "?";
                int numero = 0;
                switch ((pos_x))
                {
                    case 0: letra = "A"; break;
                    case 1: letra = "B"; break;
                    case 2: letra = "C"; break;
                    case 3: letra = "D"; break;
                    case 4: letra = "E"; break;
                    case 5: letra = "F"; break;
                    case 6: letra = "G"; break;
                    case 7: letra = "H"; break;
                }
                switch ((pos_y))
                {
                    case 0: numero = 8; break;
                    case 1: numero = 7; break;
                    case 2: numero = 6; break;
                    case 3: numero = 5; break;
                    case 4: numero = 4; break;
                    case 5: numero = 3; break;
                    case 6: numero = 2; break;
                    case 7: numero = 1; break;
                }
                string movimento = letra + numero.ToString();
                Console.WriteLine($"Campo Atual: {movimento}");

            }

        }
    }
}