using System;
using System.Collections.Generic;
using System.Text;

namespace Evento
{
    class Participante
    {
        public string email;
        public string nome;

        public bool podeInscrever(Evento e)
        {
            bool ret = false;

            return ret;
        }

        public override bool Equals(object obj)
        {
            return this.email.Equals(obj:email);
        }

        public override string ToString()
        {
            return "Nome: "+this.nome+"\nE-mail: " +this.email;
        }
    }
}
