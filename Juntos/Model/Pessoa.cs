using System.Collections.Generic;
using Juntos.Model.Enums;

namespace Juntos.Model
{
    public abstract class Pessoa : Entidade
    {
        protected Pessoa()
        {
            
        }

        protected Pessoa(EnumTipoPessoa tipo, string nome, long cpfCnpj, string email)
        {
            this.Tipo = tipo;
            this.Nome = nome;
            this.CpfCnpj = cpfCnpj;
            this.Email = email;

            this.Enderecos = new List<Endereco>();
            this.Telefones = new List<Telefone>();
        }

        public string Email { get; set; }

        public long CpfCnpj { get; set; }

        public string Nome { get; set; }

        public EnumTipoPessoa Tipo { get; set; }

        public List<Telefone> Telefones { get; set; }

        public List<Endereco> Enderecos { get; set; }
    }
}