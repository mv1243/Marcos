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

        public string Icone { get; set; }

        public Campo() 
        {
            Cor = null;
            Tipo = "Campo";
        }  

        public void MoverPeca(IPeca entity)
        {
            throw new NotImplementedException();
        }
    }
}
