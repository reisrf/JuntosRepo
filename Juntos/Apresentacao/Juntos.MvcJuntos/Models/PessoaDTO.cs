using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Juntos.MvcJuntos.Models
{
    public class PessoaDTO
    {
        public string Nome { get; set; }
        public long CpfCnpj { get; set; }
        public string Email { get; set; }
        public string Logradouro { get; set; }
        public int LogradouroNumero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string Cep { get; set; }
        public short DDD { get; set; }
        public short DDI { get; set; }
        public int NumeroTelefone { get; set; }
    }
}