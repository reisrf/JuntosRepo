using System;
using System.Collections.Generic;
using System.Text;

namespace br.edu.infnet.juntos.model
{
    class Oferta
    {
        private TipoOferta tipoOferta;
        private List<Cupom> cupoms;

        public TipoOferta TipoOferta
        {
            get { return tipoOferta; }
            set { tipoOferta = value; }
        }
        private PeriodoDeTempo periodo;

        public PeriodoDeTempo Periodo
        {
            get { return periodo; }
            set { periodo = value; }
        }
        internal List<Cupom> Cupoms
        {
            get { return cupoms; }
            set { cupoms = value; }
        }

    }
}
