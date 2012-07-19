using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace juntos.PagamentoService.model
{
    [DataContract]
    public enum StatusPagamento
    {
        [EnumMember]
        Pendente,
        [EnumMember]
        Aprovado,
        [EnumMember]
        Rejeitado,
        [EnumMember]
        Cancelado
    }
}