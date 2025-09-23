using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez.Interface
{
    internal interface IPeca
    {
        public string Nome { get; set; }

        public string Cor { get; set; }

        public int Posicao_X { get; set; }

        public int Posicao_Y { get; set; }

        public string Icone { get; set; }

        public bool PreMovimento(int[] posicao, List<IPeca> Pecas);



    }
}
