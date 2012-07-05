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

        public Consumidor(EnumTipoPessoa tipo, string nome, long cpfCnpj, string email) : base(tipo, nome, cpfCnpj, email)
        {
            this.Compras = new List<Compra>();
        }

        public List<Compra> Compras { get; set; }
    }
}