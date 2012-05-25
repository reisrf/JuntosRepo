using System;
using System.Collections.Generic;
using System.Text;

namespace br.edu.infnet.juntos.model
{
    class Compra
    {
        private DateTime dtCompra;
        private double valor;
        private string numeroCartaoCredito;
        private string comprovantePagamento;
        private List<Cupom> cupoms;


        public DateTime DtCompra
        {
            get { return dtCompra; }
            set { dtCompra = value; }
        }
        public double Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        public string NumeroCartaoCredito
        {
            get { return numeroCartaoCredito; }
            set { numeroCartaoCredito = value; }
        }

        public string ComprovantePagamento
        {
            get { return comprovantePagamento; }
            set { comprovantePagamento = value; }
        }

        internal List<Cupom> Cupoms
        {
            get { return cupoms; }
            set { cupoms = value; }
        }

    }
}
