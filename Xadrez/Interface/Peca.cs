using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez.Interface
{
    public interface IPeca
    {
        public string Cor { get; set; }

        public string Nome { get; set; }
        public string Tipo { get; set; }

        public string Icone { get; set; }
        public abstract void MoverPeca();

        public abstract bool PreMovimento(int y1, int x1, int y2, int x2);
    }
}
