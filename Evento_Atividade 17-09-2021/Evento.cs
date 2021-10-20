using System;
using System.Collections.Generic;
using System.Text;

namespace Evento
{
    class Evento
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public int qtdeMaxParticipantes { get; set; }
        public List<Participante> participantes = new List<Participante>();

        public int inscreverParticipante(Participante p)
        {
            int ret = 0;
            this.participantes.Add(p);
            return ret;
        }

        public int qtdeParticipantes()
        {
            int ret = 0;

            ret = participantes.Count;
            return ret;
        }

        public string listaParticipantes()
        {
            string ret = "";
            for(int i=0; i < this.participantes.Count; i++)
            {
                Console.WriteLine(this.participantes[i].ToString() + "\n");
            }
            return ret;
        }

        public bool Equals(int i)
        {
            return this.id.Equals(i);

        }

        public override string ToString()
        {
            return "Id: "+this.id+"\n"+"Descrição: "+this.descricao+"\n"+"Limite de Participantes: "+this.qtdeMaxParticipantes+"\nNúmero de Participantes atual: "+participantes.Count;
        }
    }
}
