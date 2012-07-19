using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Juntos.Model;

namespace Juntos.IService
{
    public interface IPagamentoService
    {
        void ProcessarPagamento(Pagamento pagamento);
        void AtualizarPagameto(Pagamento pagamento);
    }
}
