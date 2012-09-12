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

        public Anunciante(string nome, long cnpj, string email) : base(EnumTipoPessoa.Juridica, nome, cnpj, email)
        {
            this.Ofertas = new List<Oferta>();
        }

        //public List<Oferta> Ofertas { get; set; }

        private List<Oferta> ofertas = new List<Oferta>();
        public virtual List<Oferta> Ofertas { get { return this.ofertas; } set { this.ofertas = value; } }

        public Oferta NovaOferta()
        {
            var oferta = new Oferta(this);
            this.Ofertas.Add(oferta);
            return oferta;
        }

        public void IncluirOferta(Oferta o)
        {
            this.Ofertas.Add(o);
           
        }

    }
}