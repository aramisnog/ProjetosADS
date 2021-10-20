using System;
using System.Collections.Generic;
using System.Text;

namespace Empresa
{
    class Venda
    {
        public int qtde { get; set; }
        public double valor { get; set; }

        public Venda()
        {
            this.valor = 0;
            this.qtde = 0;
        }
        public double valorMedio()
        {
            double ret = 0;
            ret = valor / qtde+0.0;
            return ret;
        }

    }
}
