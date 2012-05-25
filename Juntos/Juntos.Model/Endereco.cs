using System;
using System.Collections.Generic;
using System.Text;

namespace br.edu.infnet.juntos.model
{
    public class Endereco
    {
        private string logradouro;
        private int numero;
        private string complemento;
        private string bairro;
        private string cidade;
        private int cep;
        private string pais;


        public string Logradouro
        {
            get { return logradouro; }
            set { logradouro = value; }
        }

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public string Complemento
        {
            get { return complemento; }
            set { complemento = value; }
        }
        public string Bairro
        {
            get { return bairro; }
            set { bairro = value; }
        }

        public string Cidade
        {
            get { return cidade; }
            set { cidade = value; }
        }
        public int Cep
        {
            get { return cep; }
            set { cep = value; }
        }

        public string Pais
        {
            get { return pais; }
            set { pais = value; }
        }



    }
}
