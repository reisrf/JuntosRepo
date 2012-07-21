using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFPagamentoService
{
    public class PagamentoService : IPagamentoService
    {
        public bool Pagar(decimal valor)
        {
            if (valor <= 0)
            {
                throw new Exception("Valor inválido para pagamento");
            }

            return true;
        }
    }
}
