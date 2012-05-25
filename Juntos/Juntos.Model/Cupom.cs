using System;
using System.Collections.Generic;
using System.Text;

namespace br.edu.infnet.juntos.model
{
    class Cupom
    {
        private string codigo;
        private DateTime validade;

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public DateTime Validade
        {
            get { return validade; }
            set { validade = value; }
        }
    }
}
