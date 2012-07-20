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

        public EnumFormaPagamento FormaPagamento { get; set; }

       
        public Guid Codigo { get; set; }

        public DateTime DataPagamento { get; set; }

        public decimal Valor { get; set; }

        public EnumStatusPagamento Status { get; set; }
    }
}