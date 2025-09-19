using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez
{
    class Utils
    {
        public static string Coordenados_Para_Notaçao(int pos_x, int pos_y)
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
            return $"Campo Atual: {movimento}";

        }
    }
}
