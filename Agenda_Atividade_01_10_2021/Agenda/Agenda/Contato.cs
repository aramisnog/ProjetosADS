using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda
{
    class Contato
    {
        private string nome;
        private string email;
        private string telefone;
        private DateTime dtNasc;
        private Data dtNascInt;

        public string Nome { get => nome; set => nome = value; }
        public string Email { get => email; set => email = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public DateTime DtNasc { get => dtNasc; set => dtNasc = value; }

        public void setData(int dia, int mes, int ano)
        {
            dtNascInt = new Data();
            dtNascInt.setData(dia, mes, ano);
        }

        public Data getData()
        {
            return dtNascInt;
        }
        public int getIdade()
        {
            int ret = 0;
            ret = int.Parse((((DateTime.Now - this.DtNasc).Days) / 365.25).ToString()); 
            return ret;
        }

        public override string ToString()
        {
            string ret = "";
            ret = string.Format("Nome: {0}\nE-mail: {1}\nTelefone: {2}\nData de Nascimento: {3}", this.Nome, this.Email, this.Telefone, this.DtNasc.ToString()); 
            return ret;
        }
    }


}
