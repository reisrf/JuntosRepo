using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFPagamentoService
{
    [ServiceContract]
    public interface IPagamentoWService
    {
        [OperationContract]
        bool Pagar(decimal valor);
    }
}
