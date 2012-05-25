using System;
using System.Collections.Generic;
using System.Text;

namespace br.edu.infnet.juntos.model
{
    abstract class Fisica : Pessoa 
    {
        private string cpf;
        private DateTime dtNascimento;

        public string Cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }

        public DateTime DtNascimento
        {
            get { return dtNascimento; }
            set { dtNascimento = value; }
        }
    }
}
