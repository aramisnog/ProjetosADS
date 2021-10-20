using System;

namespace Evento
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcao = -1;
            int idEventoGeral = 0;

            Eventos evt = new Eventos();

            while(opcao!=0)
            {

                Console.Clear();
                Console.WriteLine("0.Sair");
                Console.WriteLine("1.Adicionar evento");
                Console.WriteLine("2.Pesquisar evento");
                Console.WriteLine("3.Listar eventos");
                Console.WriteLine("4.Adicionar participante");
                Console.WriteLine("5.Pesquisar participante");
                Console.WriteLine("6.Informar quantidade total de participantes nos eventos da semana");

                Console.Write("Digite a opção desejada: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Evento ev = new Evento();
                        Console.Clear();
                        Console.WriteLine("Digite o dia da semana: ");
                        int diaEvento = int.Parse(Console.ReadLine());
                        Console.WriteLine("Digite a descrição do Evento: ");
                        string descrEvento = Console.ReadLine();
                        Console.WriteLine("Digite a quantidade máxima de participantes de {0}: ",descrEvento);
                        int qtdeMaxEvento = int.Parse(Console.ReadLine());

                        idEventoGeral++;
                        ev.id = idEventoGeral;
                        ev.descricao = descrEvento;
                        ev.qtdeMaxParticipantes = qtdeMaxEvento;

                        evt.adicionarEvento(ev, diaEvento-1);
                        Console.WriteLine("Evento {0} registrado com sucesso!", descrEvento);
                        Console.ReadLine();
                        opcao = -1;
                    break;

                    case 2:
                        Evento ev2 = new Evento();
                        Console.Clear();

                        Console.WriteLine("Digite o Id do Evento: ");
                        int idEvento = int.Parse(Console.ReadLine());
                        
                        for(int i=0; i < evt.osEventos.Length; i++)
                        {
                            if (evt.osEventos[i] != null)
                            {
                                if(evt.osEventos[i].Equals(idEvento)) {

                                    Console.WriteLine("Dados do Evento {0}", evt.osEventos[i].descricao);
                                    Console.WriteLine(evt.osEventos[i].ToString());
                                    Console.WriteLine("");
                                }
                            }
                        }

                        Console.ReadLine();
                        opcao = -1;
                        break;
                    case 3:
                        Console.Clear();

                        evt.listaEventos();
                        opcao = -1;
                        break;

                    case 4:
                        Console.Clear();

                        Participante p = new Participante();

                        Console.WriteLine("Digite o nome do participante: ");
                        string nomeParticipante = Console.ReadLine();
                        Console.WriteLine("Digite o e-mail do participante: ");
                        string emailParticipante = Console.ReadLine();

                        Console.WriteLine("Digite o Id do Evento que {0} deseja se inscrever: ",nomeParticipante);
                        int idEvento2 = int.Parse(Console.ReadLine());
                        int indexEvento = -1;
                        Evento e = new Evento();

                        p.nome = nomeParticipante;
                        p.email = emailParticipante;

                        int contadorEventos = 0;

                        for (int i = 0; i < evt.osEventos.Length; i++)
                        {
                            if (evt.osEventos[i] != null)
                            {
                                if (idEvento2.Equals(evt.osEventos[i].id))
                                {
                                    e = evt.osEventos[i];
                                    indexEvento = i;
                                }
                                for (int j = 0; j < evt.osEventos[i].participantes.Count; j++)
                                {
                                    if (evt.osEventos[i].participantes[j] != null)
                                    {
                                        if (p.email.Equals(evt.osEventos[i].participantes[j].email))
                                        {
                                            contadorEventos++;
                                        }
                                    }
                                }
                            }
                        }

                        if (e.participantes.Count >= e.qtdeMaxParticipantes)
                        {
                            Console.WriteLine("O número máximo de participante já foi atingido!\nNão é possível realizar novas inscrições para este evento.");
                        } else if (contadorEventos < 2 )
                        {
                            e.inscreverParticipante(p);
                            evt.osEventos[indexEvento] = e;
                            Console.WriteLine("Insicrição Efetuada com sucesso!");
                        } else
                        {
                            Console.WriteLine("O participante já efetuou o limite de inscrições em eventos desta semana!");
                        }

                        Console.ReadLine();

                            opcao = -1;
                        break;
                    case 5:
                        Console.Clear();

                        Participante p2 = new Participante();

                        Console.WriteLine("Digite o e-mail do participante: ");
                        string emailParticipante2 = Console.ReadLine();

                        bool semParticipante = true;


                        for (int i = 0; i < evt.osEventos.Length; i++)
                        {
                            if (evt.osEventos[i] != null)
                            {
                                for (int j = 0; j < evt.osEventos[i].participantes.Count; j++)
                                {
                                    if (evt.osEventos[i].participantes[j] != null)
                                    {
                                        p2 = evt.osEventos[i].participantes[j];
                                        if (emailParticipante2.Equals(evt.osEventos[i].participantes[j].email))
                                        {
                                            semParticipante = false;
                                            Console.WriteLine(p2.ToString());
                                            Console.WriteLine(evt.osEventos[i].ToString());
                                            
                                        }
                                    }
                                }
                            }
                        }
                        if (semParticipante)
                        {
                            Console.WriteLine("Nenhum participante registrado com o email: {0} !", emailParticipante2);
                        }
                        Console.ReadLine();
                        break;

                    case 6:
                        Console.Clear();

                        int totalParticipantes = 0;
                        System.Collections.Generic.List<string> emails = new System.Collections.Generic.List<string>();

                        for (int i = 0; i < evt.osEventos.Length; i++)
                        {
                            if (evt.osEventos[i] != null)
                            {
                                Evento e2 = evt.osEventos[i];
                                for (int j = 0; j < e2.participantes.Count; j++)
                                {
                                    if (!emails.Contains(e2.participantes[j].email))
                                    {
                                        emails.Add(e2.participantes[j].email);
                                        totalParticipantes++;
                                    }
                                }
                            }
                        }

                        Console.WriteLine("O número total de participantes de eventos da semana é {0}", totalParticipantes);
                        Console.ReadLine();
                       break;
                }
            }
        }
    }
}
