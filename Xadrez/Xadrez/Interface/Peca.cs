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

        public string Tipo { get; set; }
        public abstract void MoverPeca(IPeca entity);
    }
}
