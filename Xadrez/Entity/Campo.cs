using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xadrez.Interface;

namespace Xadrez.Entity
{
    internal class Campo : IPeca
    {
        public string Cor { get; set; }
        public string Tipo { get; set; }

        public string Nome { get; set; }
        public string Icone { get; set; }

        public Campo() 
        {
            Nome = "Campo";
            Cor = null;
            Tipo = "Campo";
        }  

        public void MoverPeca()
        {
            throw new NotImplementedException();
        }

        public bool PreMovimento(int y1, int x1, int y2, int x2)
        {
            throw new NotImplementedException();
        }
    }
}
