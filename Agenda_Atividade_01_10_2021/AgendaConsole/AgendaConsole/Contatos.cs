using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaConsole
{
    class Contatos
    {
        List<Contato> agenda = new List<Contato>();

        internal List<Contato> Agenda { get => agenda; set => agenda = value; }

        public bool adicionar(Contato c)
        {
            bool ret = false;
            try
            {
                Agenda.Add(c);
                ret = true;
            }catch(Exception exc)
            {
                ret = false;
            }


            return ret;
        }

        public Contato pesquisar(Contato c)
        {
            Contato ret = new Contato();
            if (c.Email != null)
            {

                for(int i=0; i<this.Agenda.Count; i++)
                {
                    if (this.Agenda[i].Email.Equals(c.Email))
                    {
                        ret = this.Agenda[i];
                        break;
                    }
                }
            }
            return ret;
        }

        public bool alterar(Contato c)
        {
            bool ret = false;
            for (int i = 0; i < Agenda.Count; i++)
            {
                if (Agenda[i].Email.Equals(c.Email))
                {
                    Agenda[i] = c;
                    ret = true;
                    break;
                }
            }
            return ret;
        }

        public bool remover(Contato c)
        {
            bool ret = false;
            int idx = -1;
            for (int i = 0; i < Agenda.Count; i++)
            {
                if (Agenda[i].Email.Equals(c.Email))
                {
                    idx = i;
                    ret = true;
                    break;
                }
            }
            if (ret)
            {
                Agenda.RemoveAt(idx);
            }
            return ret;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}
