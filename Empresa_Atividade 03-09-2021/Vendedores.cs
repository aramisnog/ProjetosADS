using System;
using System.Collections.Generic;
using System.Text;

namespace Empresa
{
    class Vendedores
    {
        public List<Vendedor> osVendedores = new List<Vendedor>();
        public int max { get; set; }
        public int qtde { get; set; }

        public Vendedores()
        {
            max = 10;
            qtde = 0;
        }
        public void addVendedor(Vendedor v)
        {
            osVendedores.Add(v);
            this.qtde++;
        }

        public void delVendedor(Vendedor v)
        {

        }

        public Vendedor searchVendedor(Vendedor v)
        {
            Vendedor ret = new Vendedor(v.id, v.nome, v.percComissao);
            return ret;
        }

        public double valorVendas()
        {
            double ret = 0;
            return ret;
        }

        public double valorComissao()
        {
            double ret = 0;
            return ret;
        }


    }
}
