using System;
using System.Collections.Generic;
using System.Text;

namespace br.edu.infnet.juntos.model
{
    class TipoOferta
    {
        private string descricao;
        private PeriodoDeTempo periodoDeTempo;


        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

        internal PeriodoDeTempo PeriodoDeTempo
        {
            get { return periodoDeTempo; }
            set { periodoDeTempo = value; }
        }

    }
}
