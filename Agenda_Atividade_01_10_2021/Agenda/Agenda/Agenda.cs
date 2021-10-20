using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agenda
{
    public partial class Agenda : Form
    {
        Contatos ctt = new Contatos();
        public Agenda()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            txtNome.Clear();
            txtEmail.Clear();
            txtTelefone.Clear();
            txtDia.Clear();
            txtMes.Clear();
            txtAno.Clear();
            lstResultados.Items.Clear();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            
            Contato c = new Contato();
            c.Email = txtEmail.Text;

            c = ctt.pesquisar(c);
            if (c.Email!=null)
            {
                c.Nome = txtNome.Text;
                c.Telefone = txtTelefone.Text;
                c.DtNasc = new DateTime(int.Parse(txtAno.Text), int.Parse(txtMes.Text), int.Parse(txtDia.Text));
                c.setData(int.Parse(txtDia.Text), int.Parse(txtMes.Text), int.Parse(txtAno.Text));
                if (ctt.alterar(c))
                {
                    MessageBox.Show("Contato atualizado com sucesso!");
                }
            } else
            {
                c.Email = txtEmail.Text;
                c.Nome = txtNome.Text;
                c.Telefone = txtTelefone.Text;
                c.DtNasc = new DateTime(int.Parse(txtAno.Text), int.Parse(txtMes.Text), int.Parse(txtDia.Text));
                c.setData(int.Parse(txtDia.Text), int.Parse(txtMes.Text), int.Parse(txtAno.Text));
                if (ctt.adicionar(c))
                {
                    MessageBox.Show("Contato incluído com sucesso!");
                }

            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Contato c = new Contato();
            c.Email = txtEmail.Text;

            c = ctt.pesquisar(c);
            if (c.Email.Equals(txtEmail.Text))
            {
                if (ctt.remover(c))
                {
                    MessageBox.Show("Contato excluído com sucesso!");
                }

            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            Contato c = new Contato();
            c.Email = txtEmail.Text;

            c = ctt.pesquisar(c);
            if (c.Email!=null)
            {
                txtNome.Text = c.Nome;
                txtTelefone.Text = c.Telefone;
                txtDia.Text = c.DtNasc.Day.ToString();
                txtMes.Text = c.DtNasc.Month.ToString();
                txtAno.Text = c.DtNasc.Year.ToString();
            } else
            {
                MessageBox.Show("Nenhum contato localizado com o e-mail informado!");
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            lstResultados.Items.Clear();
            if (ctt.Agenda.Count > 0)
            {
                for (int i = 0; i < ctt.Agenda.Count; i++)
                {
                    lstResultados.Items.Add(ctt.Agenda[i].ToString());
                }
            } else
            {
                MessageBox.Show("Nenhum contato registrado nesse momento!");
            }

        }
    }
}
