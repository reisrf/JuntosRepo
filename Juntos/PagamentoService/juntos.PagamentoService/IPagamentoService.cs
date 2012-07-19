using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using juntos.PagamentoService.model;

namespace juntos.PagamentoService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IPagamentoService
    {

        [OperationContract(IsOneWay = true)]
        void PaymentRequest(Pagamento pgto);

        [OperationContract]
        Pagamento GetPaymentResult(string pagtoid);

        // TODO: Add your service operations here
    }


   
}
