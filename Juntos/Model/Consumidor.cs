using System.Collections.Generic;
using Juntos.Model.Enums;

namespace Juntos.Model
{
    public class Consumidor : Pessoa
    {
        public Consumidor() : base()
        {
            this.Compras = new List<Compra>();
        }

        public Consumidor(EnumTipoPessoa tipo, string nome, long cpfCnpj, string email, string senha) : base(tipo, nome, cpfCnpj, email, senha)
        {
            this.Compras = new List<Compra>();
        }

        public virtual List<Compra> Compras { get; set; }
    }
}