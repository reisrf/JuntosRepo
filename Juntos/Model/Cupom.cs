using System;

namespace Juntos.Model
{
    public class Cupom : Entidade
    {
        public Cupom()
        {
        }

        public Cupom(Oferta oferta)
        {
            this.Oferta = oferta;
        }

        public Oferta Oferta { get; set; }

        public DateTime DataValidade { get; set; }

        public DateTime? DataUtilizacao { get; set; }

        public decimal Valor { get; set; }

        public bool IsUtilizado()
        {
            return this.DataUtilizacao != null;
        }
    }
}