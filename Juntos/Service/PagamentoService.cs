using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Juntos.IService;
using Juntos.Model;
using Juntos.IRepository;
using Juntos.Model.Enums;

namespace Juntos.Service
{
    public class PagamentoService : BaseService<Pagamento>, IPagamentoService
    {
        
        
        public PagamentoService(IPagamentoRepository pagamentoRepository): base(pagamentoRepository)
        {
        
        }
        
       
       public void AtualizarPagamento(Juntos.Model.Pagamento pagamento)
        {
            if (pagamento.Status != EnumStatusPagamento.Pendente)
            {
                this.AtualizarPagamento(pagamento);
            }


        }

    }
}
