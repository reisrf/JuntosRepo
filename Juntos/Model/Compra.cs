using System;
using System.Collections.Generic;
using System.Linq;
using Juntos.Model.Enums;

namespace Juntos.Model
{
    public class Compra : Entidade
    {
        private decimal? _valorTotal;

        public DateTime DataCompra { get; set; }

        public Consumidor Consumidor { get; set; }

        public virtual List<Cupom> Cupons { get; set; }

        public virtual List<Pagamento> Pagamentos { get; set; }

        public decimal ValorTotal
        {
            get { return this._valorTotal ?? this.Cupons.Sum(c => c.Valor); }
            set { this._valorTotal = value; }
        }

        public bool IsPaga()
        {
            return this.Pagamentos.Any(p => p.Status == EnumStatusPagamento.Aprovado);
        }

        public Compra()
        {
            this.Cupons = new List<Cupom>();
            this.Pagamentos = new List<Pagamento>();
        }

        public Compra(Consumidor consumidor) : this()
        {
            this.Consumidor = consumidor;
        }

        public Pagamento Pagar(EnumFormaPagamento formaPagamento)
        {
            if (this.IsPaga())
            {
                throw new Exception("A compra já está paga.");
            }

            this.CancelarPagamentoPendente();

            var pagamento = new Pagamento(formaPagamento)
                                {
                                    Status = EnumStatusPagamento.Pendente,
                                    Valor = this.ValorTotal,
                                    DataPagamento = DateTime.Now
                                };

            this.Pagamentos.Add(pagamento);

            return pagamento;
        }

        private void CancelarPagamentoPendente()
        {
            var pagamento = this.Pagamentos.FirstOrDefault(p => p.Status == EnumStatusPagamento.Pendente);
            if (pagamento != null) pagamento.Status = EnumStatusPagamento.Cancelado;
        }
    }
}