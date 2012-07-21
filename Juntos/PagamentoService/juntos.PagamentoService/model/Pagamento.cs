using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace juntos.PagamentoService.model
{
    public class Pagamento
    {
        
        public FormaPagamento FormaPagamento { get; set; }

        public long Codigo { get; set; }

        public DateTime DataPagamento { get; set; }

        public decimal Valor { get; set; }

        public StatusPagamento Status { get; set; }
    }
}