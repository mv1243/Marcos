// See https://aka.ms/new-console-template for more information


int pos_y = 0;
int pos_x = 0;

int altura = 8;
int largura = 8;
while (true)
{
    Console.Clear();
    for (int y = 0; y < altura; y++)
    {
        for (int x = 0; x < largura; x++)
        {
            if (pos_y == y && pos_x == x)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Write("[x]");
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.Write("[ ]");
            }          
        }
        Console.WriteLine();
    }

    ConsoleKeyInfo key = Console.ReadKey(true);

    switch (key.Key)
    {
        case ConsoleKey.UpArrow: if (pos_y > 0) pos_y--; break;

        case ConsoleKey.DownArrow: if (pos_y < altura - 1) pos_y++; break;

        case ConsoleKey.RightArrow: if (pos_x < largura - 1) pos_x++; break;

        case ConsoleKey.LeftArrow: if (pos_x > 0) pos_x--; break;

        case ConsoleKey.Enter: Console.WriteLine($"Selecionou ({pos_x}, {pos_y})"); Console.ReadKey(); break;

    }
}



