using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Juntos.Model;
using Juntos.IRepository;
using Juntos.IDAL;
using Juntos.Model.Enums;

namespace Juntos.Repository
{
    public class PagamentoRepository : BaseRepository<Pagamento>, IPagamentoRepository
    {

   
        
        public PagamentoRepository (IPagamentoDAO pagamentoDAO) : base(pagamentoDAO)
        {
       
        } 
        
        public void AtualizarPagamento(Pagamento pagamento) 
       {
           Pagamento pagamentoArmazenado = this.BuscarPorId(pagamento.Id);

           if (pagamentoArmazenado.Status == EnumStatusPagamento.Pendente)
           {
               pagamentoArmazenado.Status = pagamento.Status;
           }

           this.Atualizar(pagamentoArmazenado);
         
       }
        
    }
}
