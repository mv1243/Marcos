using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez
{
    internal class Utils
    {
       public static string Square(string piece)
        {
            double n = 1.5;
            return piece.PadLeft(3).PadRight(1);
        }
    }
}
