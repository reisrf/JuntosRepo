using System.Collections.Generic;
using System.Runtime.Serialization;
using Juntos.Model;

namespace Juntos.Apresentacao.WcfServiceApp.dto
{
    [DataContract(IsReference = true)]
    public class ConsumidorDTO : PessoaDTO
    {
        [DataMember]
        public List<CompraDTO> Compras { get; set; }
    }
}