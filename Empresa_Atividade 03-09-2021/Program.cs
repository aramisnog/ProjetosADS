using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Empresa
{
    class Program
    {
        static void Main(string[] args)
        {
            Vendedores pvtVendedores;
            pvtVendedores = new Vendedores();

            int id = 0;
            string nome;
            double percComissao = 0;

            int opcao = -1;
            while (!opcao.Equals(0))
            {
                Console.Clear();
                Console.WriteLine("0.Sair");
                Console.WriteLine("1.Cadastrar Vendedor");
                Console.WriteLine("2.Consultar Vendedor");
                Console.WriteLine("3.Excluir Vendedor");
                Console.WriteLine("4.Registrar Venda");
                Console.WriteLine("5.Listar Vendedores");
                Console.WriteLine("");
                Console.Write("Escolha a sua opção: ");
                try
                {
                    opcao = int.Parse(Console.ReadLine());
                    
                } catch(Exception exc)
                {

                }

                switch (opcao)
                {
                    case 1:
                        Console.Clear();
                        if (pvtVendedores.osVendedores.Count < 10)
                        {
                            Console.WriteLine("Digite o nome do novo Vendedor: ");
                            nome = Console.ReadLine();
                            Console.WriteLine("Digite o percentual de comissão para {0}", nome);
                            try
                            {
                                percComissao = double.Parse(Console.ReadLine());
                            } catch(Exception exc)
                            {

                            }
                            id++;
                            pvtVendedores.addVendedor(new Vendedor(id, nome, percComissao));
                            opcao = -1;
                        } else
                        {
                            Console.WriteLine("Foi atingido o limite máximo de Vendedores!");
                            Console.ReadLine();
                        }
                    break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Lista de Vendedores\n\n\n");
                        for (int i=0; i<pvtVendedores.osVendedores.Count; i++)
                        {
                            Console.WriteLine("Vendedor {0}", pvtVendedores.osVendedores[i].id);
                            Console.WriteLine("Nome: {0}", pvtVendedores.osVendedores[i].nome);
                            Console.WriteLine("");
                        }
                        Console.ReadLine();
                        opcao = -1;
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Digite o Id do Vendedor para a exclusão: ");
                        int idExcluir = 0; 
                        try
                        {
                            idExcluir = int.Parse(Console.ReadLine());
                            for (int i = 0; i < pvtVendedores.osVendedores.Count; i++)
                            {
                                if (pvtVendedores.osVendedores[i].id.Equals(idExcluir))
                                {
                                    bool temVenda = false;
                                    for (int j = 0; j < pvtVendedores.osVendedores[i].asVendas.Length; j++)
                                    {
                                        if (!pvtVendedores.osVendedores[i].valorVendas().Equals(0))
                                        {
                                            temVenda = true;
                                            Console.WriteLine("Não é possível excluir o vendedor {0}, pois o mesmo possui registro de Vendas", pvtVendedores.osVendedores[i].nome);
                                            break;
                                        }
                                    } 

                                    if(!temVenda) {
                                        Console.WriteLine("Vendedor {0} excluído com sucesso", pvtVendedores.osVendedores[i].nome);
                                        pvtVendedores.osVendedores.RemoveAt(i);
                                    }
                                }
                            }
                            Console.ReadLine();
                            opcao = -1;
                        }
                        catch (Exception exc)
                        {

                        }
                        break;

                        case 4:
                            Console.Clear();
                            Console.WriteLine("Digite o Id do Vendedor: ");
                            int idVendedor = int.Parse(Console.ReadLine());
                            Console.WriteLine("Digite o Dia da Venda: ");
                            int diaVenda = int.Parse(Console.ReadLine());
                            Console.WriteLine("Digite o valor vendido: ");
                            double valorVenda = double.Parse(Console.ReadLine());
                            for (int i = 0; i < pvtVendedores.osVendedores.Count; i++)
                            {

                                if (pvtVendedores.osVendedores[i].id.Equals(idVendedor))
                                {
                                    Venda v = new Venda();
                                    v.valor = valorVenda;
                                    v.qtde++;
                                    if(pvtVendedores.osVendedores[i].asVendas[diaVenda]!=null)
                                    {
                                        v.valor += pvtVendedores.osVendedores[i].asVendas[diaVenda].valor;
                                        v.qtde = pvtVendedores.osVendedores[i].asVendas[diaVenda].qtde + 1;
                                    }
                                    pvtVendedores.osVendedores[i].registrarVenda(diaVenda, v);
                                    Console.WriteLine("Venda de {0}, registrada com sucesso!", valorVenda);
                                }
                            }
                        

                        opcao = -1;
                        Console.ReadLine();
                        break;

                        case 5:

                        Console.Clear();
                        Console.WriteLine("Lista de Vendedores\n\n\n");
                        double valorVendas = 0;
                        double valorComissao = 0;
                        double valorMedio = 0;
                        double totalVendas = 0;
                        double totalComissao = 0;
                        double totalMedio = 0
                            ;
                        for (int i = 0; i < pvtVendedores.osVendedores.Count; i++)
                        {
                            valorVendas = 0;
                            valorComissao = 0;
                            valorMedio = 0;
                            Console.WriteLine("Vendedor {0}", pvtVendedores.osVendedores[i].id);
                            Console.WriteLine("Nome: {0}", pvtVendedores.osVendedores[i].nome);
                            for (int j = 0; j < pvtVendedores.osVendedores[i].asVendas.Length; j++) {
                                if (pvtVendedores.osVendedores[i].asVendas[j] != null)
                                {
                                    valorVendas += pvtVendedores.osVendedores[i].asVendas[j].valor;
                                    valorComissao += pvtVendedores.osVendedores[i].asVendas[j].valor*pvtVendedores.osVendedores[i].percComissao/100.0;
                                    valorMedio = pvtVendedores.osVendedores[i].asVendas[j].valor/ pvtVendedores.osVendedores[i].asVendas[j].qtde;
                                    

                                }
                            }
                                    
                            totalVendas += valorVendas;
                            totalComissao += valorComissao;
                            totalMedio = totalVendas / pvtVendedores.osVendedores.Count;

                            Console.WriteLine("Valor de Vendas: {0:C2}", valorVendas);
                            Console.WriteLine("Comissão Devida: {0:C2}", valorComissao);
                            Console.WriteLine("");
                        }
                        Console.WriteLine("Valor de Vendas Total: {0:C2}", totalVendas);
                        Console.WriteLine("Comissão Devida Total: {0:C2}", totalComissao);
                        Console.ReadLine();
                        opcao = -1;

                        break;
                }
            }
        }

    }
}
