using System;
using System.Collections.Generic;
using System.Linq;
using Juntos.Model.Enums;

namespace Juntos.Model
{
    public class Compra : Entidade
    {
        private decimal? _valorTotal;

        public Compra()
        {
            this.Cupons = new List<Cupom>();
            this.Pagamentos = new List<Pagamento>();
        }

        public Compra(Consumidor consumidor) : this()
        {
            this.Consumidor = consumidor;
        }

        public decimal ValorTotal
        {
            get { return this._valorTotal ?? this.Cupons.Sum(c => c.Valor); } 
            set { this._valorTotal = value; }
        }

        public DateTime DataCompra { get; set; }

        public Consumidor Consumidor { get; set; }

        public virtual List<Cupom> Cupons { get; set; }

        public virtual List<Pagamento> Pagamentos { get; set; }

        public bool IsPaga()
        {
            return this.Pagamentos.Any(p => p.Status == EnumStatusPagamento.Aprovado);
        }

        public void Pagar(EnumFormaPagamento formaPagamento)
        {
            if (this.IsPaga())
            {
                throw new Exception("A compra j� est� paga.");
            }

                 
            var novo = new Pagamento(formaPagamento)
                {
                    Status = EnumStatusPagamento.Aprovado,
                    Valor = this.ValorTotal,
                    DataPagamento = DateTime.Now
                };

                this.Pagamentos.Add(novo);
        }


        private void CancelarPagamentoPendente(EnumFormaPagamento formaPagamento)
        {
            var novo = new Pagamento(formaPagamento)
            {
                Status = EnumStatusPagamento.Cancelado,
                Valor = this.ValorTotal,
                DataPagamento = DateTime.Now
            };

            this.Pagamentos.Add(novo);
        }


        public void RejeitarPagamento(EnumFormaPagamento formaPagamento)
        {
            var novo = new Pagamento(formaPagamento)
            {
                Status = EnumStatusPagamento.Rejeitado,
                Valor = this.ValorTotal,
                DataPagamento = DateTime.Now
            };

            this.Pagamentos.Add(novo);
        }
    }
}