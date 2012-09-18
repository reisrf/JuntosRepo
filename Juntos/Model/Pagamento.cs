using System;
using Juntos.Model.Enums;

namespace Juntos.Model
{
    public class Pagamento : Entidade
    {
        public Pagamento(EnumFormaPagamento formaPagamento)
        {
            this.FormaPagamento = formaPagamento;
        }

        public Pagamento()
        {
        }

        public virtual EnumFormaPagamento FormaPagamento { get; set; }

       
        public long Codigo { get; set; }

        public DateTime DataPagamento { get; set; }

        public decimal Valor { get; set; }

        public virtual EnumStatusPagamento Status { get; set; }
    }
}