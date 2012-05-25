using System;
using System.Collections.Generic;
using System.Text;

namespace br.edu.infnet.juntos.model
{
    class PeriodoDeTempo
    {
        private DateTime inicio;
        private DateTime fim;

        public DateTime Inicio
        {
            get { return inicio; }
            set { inicio = value; }
        }

        public DateTime Fim
        {
            get { return fim; }
            set { fim = value; }
        }

    }
}
