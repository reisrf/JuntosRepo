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
    [ServiceContract]
    public interface IControladorPagamentoService
    {

        [OperationContract(IsOneWay = true)]
        void PaymentRequest(Pagamento pgto);

        [OperationContract]
        Pagamento GetPaymentResult(Guid pagtoid);

        // TODO: Add your service operations here
    }


   
}
