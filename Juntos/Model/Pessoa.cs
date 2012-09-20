using System.Collections.Generic;
using Juntos.Model.Enums;

namespace Juntos.Model
{
    public abstract class Pessoa : Entidade
    {
        protected Pessoa()
        {
            this.enderecos = new List<Endereco>();
            this.telefones = new List<Telefone>();
        }

        protected Pessoa(EnumTipoPessoa tipo, string nome, long inscricao, string email, string senha)
        {
            this.Tipo = tipo;
            this.Nome = nome;
            this.Inscricao = inscricao;
            this.Email = email;
            this.Senha = senha;

            this.enderecos = new List<Endereco>();
            this.telefones = new List<Telefone>();
        }

        public string Email { get; set; }

        public long Inscricao { get; set; }

        public string Senha { get; set; }

        public string Nome { get; set; }

        public virtual EnumTipoPessoa Tipo { get; set; }

        public virtual int TipoPessoaId
        {
            get { return (int)Tipo; }
            set { Tipo = (EnumTipoPessoa)value; }
        }
       

        private List<Endereco> enderecos = new List<Endereco>();
        public virtual List<Endereco> Enderecos { get { return this.enderecos; } set {this.enderecos=value;} }

        private List<Telefone> telefones = new List<Telefone>();
        public virtual List<Telefone> Telefones { get { return this.telefones; } set { this.telefones = value; } }


        

        public void IncluirEndereco(Endereco endereco)
        {
            enderecos.Add(endereco);
        }

        public void IncluirTelefone(Telefone telefone)
        {
            telefones.Add(telefone);
        }

    }
}