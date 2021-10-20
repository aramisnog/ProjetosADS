
using System;
using System.Collections.Generic;

namespace AgendaConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcao = -1;                
            Contatos ctt = new Contatos();
            Contato c = new Contato();
            while (opcao != 0)
            {
                Console.Clear();
                Console.WriteLine("0.Sair");
                Console.WriteLine("1.Adicionar contato");
                Console.WriteLine("2.Pesquisar contato");
                Console.WriteLine("3.Alterar contato");
                Console.WriteLine("4.Remover contato");
                Console.WriteLine("5.Listar contatos");
                opcao = int.Parse(Console.ReadLine());
                string email = "";

                switch (opcao)
                {
                    case 1:
                        c = new Contato();
                        Console.Clear();
                        Console.WriteLine("Digite o nome do novo contato: ");
                        c.Nome = Console.ReadLine();

                        Console.WriteLine("Digite o e-mail de {0}: ", c.Nome);
                        c.Email = Console.ReadLine();

                        Console.WriteLine("Digite o telefone de {0}: ", c.Nome);
                        c.Telefone = Console.ReadLine();

                        Console.WriteLine("Digite a data de nascimento de {0} (no formato dd/mm/yyyy): ", c.Nome);
                        string data = Console.ReadLine();
                        string[] dataAux = data.Split("/");
                        c.DtNasc = new DateTime(int.Parse(dataAux[2]),int.Parse(dataAux[1]), int.Parse(dataAux[0]));
                        c.setData(int.Parse(dataAux[0]), int.Parse(dataAux[1]), int.Parse(dataAux[2]));

                        ctt.adicionar(c);
                        Console.WriteLine("Contato incluído com sucesso!");
                        Console.ReadLine();
                        opcao = -1;
                    break;

                    case 2:
                        Console.Clear();
                        c = new Contato();
                        Console.WriteLine("Digite o e-mail do contato: ");
                        email = Console.ReadLine();
                        c.Email = email;
                        c = ctt.pesquisar(c);
                        if (c.Email!=null && c.Email.Equals(email))
                        {
                            Console.WriteLine("Segue os dados do contato:");
                            Console.WriteLine(c.ToString());
                        } else
                        {
                            Console.WriteLine("Nenhum contato localizado!");
                        }
                        Console.ReadLine();
                        opcao = -1;
                        break;


                    case 3:
                        Console.Clear();
                        c = new Contato();
                        Console.WriteLine("Digite o e-mail do contato: ");
                        email = Console.ReadLine();
                        c.Email = email;
                        c = ctt.pesquisar(c);
                        if (c.Email != null && c.Email.Equals(email))
                        {
                            Console.WriteLine("Digite o nome do novo contato (atual-{0}): ", c.Nome);
                            c.Nome = Console.ReadLine();

                            Console.WriteLine("Digite o telefone de {0} (atual-{1}): ", c.Nome,c.Telefone);
                            c.Telefone = Console.ReadLine();

                            Console.WriteLine("Digite a data de nascimento de {0} (no formato dd/mm/yyyy): ", c.Nome);
                            string data2 = Console.ReadLine();
                            string[] dataAux2 = data2.Split("/");
                            c.DtNasc = new DateTime(int.Parse(dataAux2[2]), int.Parse(dataAux2[1]), int.Parse(dataAux2[0]));
                            c.setData(int.Parse(dataAux2[0]), int.Parse(dataAux2[1]), int.Parse(dataAux2[2]));
                            Console.WriteLine("Contato atualizado com sucesso!");
                        }
                        Console.ReadLine();
                        opcao = -1;
                            break;

                    case 4:
                        Console.Clear();
                        c = new Contato();
                        Console.WriteLine("Digite o e-mail do contato: ");
                        email = Console.ReadLine();
                        c.Email = email;
                        c = ctt.pesquisar(c);
                        if (c.Email != null && c.Email.Equals(email))
                        {
                            if (ctt.remover(c))
                            {
                                Console.WriteLine("Contato excluído com sucesso!");

                            } else
                            {
                                Console.WriteLine("Falha na tentativa de exclusão!");

                            }

                        }
                        else
                        {
                            Console.WriteLine("Nenhum contato localizado!");
                        }
                        Console.ReadLine();
                        opcao = -1;
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Dados dos Contatos cadastrados:\n");
                        if (ctt.Agenda.Count > 0)
                        {
                            for(int i=0; i < ctt.Agenda.Count; i++)
                            {
                                Console.WriteLine(ctt.Agenda[i].ToString() + "\n");
                            }
                        } else
                        {
                            Console.WriteLine("Nenhum contato localizado!");
                        }
                        Console.ReadLine();
                        opcao = -1;
                        break;
                }

            }
        }
    }
}
