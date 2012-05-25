using System;
using System.Collections.Generic;
using System.Text;

namespace br.edu.infnet.juntos.model
{
    class Player : Juridica
    {
        private string marca;
        private string site;
        private Endereco endereco;
        private List<TipoDePlano> planos;

        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }

        public string Site
        {
            get { return site; }
            set { site = value; }
        }

        public Endereco Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }

        internal List<TipoDePlano> Planos
        {
            get { return planos; }
            set { planos = value; }
        }


    }
}
