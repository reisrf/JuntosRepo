using System;
using System.Collections.Generic;
using System.Text;

namespace br.edu.infnet.juntos.model
{
    class TipoDePlano
    {
        private int fee;
        private string descricao;

        public int Fee
        {
            get { return fee; }
            set { fee = value; }
        }

        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }
    }
}
