using System;
using System.Collections.Generic;
using System.Text;

namespace br.edu.infnet.juntos.model
{
    abstract class  Pessoa
    {
        private string nome;
        private string email;
        private Endereco endereco;
        private List<Compra> compras;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public Endereco Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }

        internal List<Compra> Compras
        {
            get { return compras; }
            set { compras = value; }
        }



    }
}
