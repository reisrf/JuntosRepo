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

        public virtual int FormaPagamentoId
        {
            get { return (int)FormaPagamento; }
            set { FormaPagamento = (EnumFormaPagamento)value; }
        }
       
        public long Codigo { get; set; }

        public DateTime DataPagamento { get; set; }

        public decimal Valor { get; set; }

        public virtual EnumStatusPagamento Status { get; set; }

        public virtual int StatusPagamentoId
        {
            get { return (int)Status; }
            set { Status = (EnumStatusPagamento)value; }
        }
    }
}