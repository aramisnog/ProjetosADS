using System;
using System.Collections.Generic;
using System.Text;

namespace Empresa
{
    class Vendedor
    {
        public int id { get; set; }
        public string nome { get; set; }
        public double percComissao { get; set; }

        public Venda[] asVendas;

        public Vendedor(int id, string nome, double perc)
        {
            this.asVendas = new Venda[31];
            this.id = id;
            this.nome = nome;
            this.percComissao = perc;
        }
        public void registrarVenda( int dia, Venda venda)
        {
            this.asVendas[dia] = venda;
        }

        public double valorVendas()
        {
            double ret = 0;
            for (int j = 0; j < this.asVendas.Length; j++)
            {
                if(this.asVendas[j]!=null)
                    ret += this.asVendas[j].valor;
            }
                return ret;
        }
        public double valorComissao()
        {
            double ret = 0;
            ret = this.valorVendas() * this.percComissao;
            return ret;
        }
    }
}
