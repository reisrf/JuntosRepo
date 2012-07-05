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

        public EnumFormaPagamento FormaPagamento { get; set; }

        [Obsolete] //Será que não poderíamos usar o ID?
        public string Codigo { get; set; }

        public DateTime DataPagamento { get; set; }

        public decimal Valor { get; set; }

        public EnumStatusPagamento Status { get; set; }
    }
}