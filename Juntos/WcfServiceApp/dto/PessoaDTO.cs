using System.Collections.Generic;
using System.Runtime.Serialization;
using Juntos.Model;
using Juntos.Model.Enums;

namespace Juntos.Apresentacao.WcfServiceApp.dto
{
    [DataContract(IsReference = true)]
    public abstract class PessoaDTO : EntidadeDTO
    {
        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public long CpfCnpj { get; set; }

        [DataMember]
        public string Nome { get; set; }

        [DataMember]
        public EnumTipoPessoa Tipo { get; set; }

        [DataMember]
        public List<TelefoneDTO> Telefones { get; set; }

        [DataMember]
        public List<EnderecoDTO> Enderecos { get; set; }
    }
}