using System.Collections.Generic;
using Juntos.Model.Enums;

namespace Juntos.Model
{
    public class Anunciante : Pessoa
    {
        public Anunciante() : base()
        {
            this.Ofertas = new List<Oferta>();
        }

        public Anunciante(EnumTipoPessoa tipo, string nome, long cpfCnpj, string email) : base(tipo, nome, cpfCnpj, email)
        {
            this.Ofertas = new List<Oferta>();
        }

        public List<Oferta> Ofertas { get; set; }

        public Oferta NovaOferta()
        {
            var oferta = new Oferta(this);
            this.Ofertas.Add(oferta);
            return oferta;
        }
    }
}