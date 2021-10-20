using System;
using System.Collections.Generic;
using System.Text;

namespace Evento
{
    class Eventos
    {
        public Evento[] osEventos = new Evento[6];
        
        public void adicionarEvento(Evento e, int dia)
        {
            osEventos[dia] = e;
        }

        public string pesquisarParticipantes(Participante p)
        {
            string ret = "";
            return ret;
        }

        public string listaEventos()
        {
            string ret = "";

            for (int i = 0; i < this.osEventos.Length; i++)
            {
                if (this.osEventos[i] != null)
                {
                    Console.WriteLine("Dados do Evento {0}", this.osEventos[i].descricao);
                    Console.WriteLine(this.osEventos[i].ToString());
                    this.osEventos[i].listaParticipantes();
                }
            }
            Console.ReadLine();
            
             return ret;
        }
    }
}
