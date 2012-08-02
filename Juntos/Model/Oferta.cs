using System;
using System.Collections.Generic;
using Juntos.Model.Enums;
using System.Xml.Serialization;

namespace Juntos.Model
{
    public class Oferta : Entidade
    {
        public Oferta()
        {
            this.Status = EnumStatusOferta.Criada;
            this.CuponsGerados = new List<Cupom>();
        }

        public Oferta(Anunciante anunciante)
        {
            this.Status = EnumStatusOferta.Criada;
            this.CuponsGerados = new List<Cupom>();
            this.Anunciante = anunciante;
        }

        //Não lembrei o que era...
        //public EnumTipoOferta Tipo { get; set; }
        public Anunciante Anunciante { get; set; }

        public Endereco Endereco { get; set; }

        public EnumStatusOferta Status { get; set; }

        public DateTime? DataPublicacao { get; set; }

        public DateTime DataValidadeCupons { get; set; }

        public DateTime DataExpiracao { get; set; }

        public DateTime? DataInicioValidade { get; set; }

        public decimal ValorCupons { get; set; }

        public string Descricao { get; set; }

        public string Condicoes { get; set; }

        public List<Cupom> CuponsGerados { get; set; }

        public int NumeroMaximoCupons { get; set; }

        public IEnumerable<Cupom> GerarCupons(int quantidade)
        {
            if (this.Status != EnumStatusOferta.Publicada)
            {
                throw new Exception("Oferta não publicada.");
            }

            if (this.MaximoDeCuponsAtingidos(quantidade))
            {
                throw new Exception(string.Format("Número máximo de cupons atingidos. Cupons restantes: {0}", this.NumeroMaximoCuponsDisponiveis()));
            }

            for (var i = 0; i < quantidade; i++)
            {
                var cupom = new Cupom(this) {DataValidade = this.DataValidadeCupons, Valor = this.ValorCupons};
                this.CuponsGerados.Add(cupom);
                yield return cupom;
            }
            
        }
        
        public void Publicar()
        {
            if (this.Status != EnumStatusOferta.Criada)
            {
                throw new Exception("Oferta já publicada.");
            }

            this.Status = EnumStatusOferta.Publicada;
            this.DataPublicacao = DateTime.Now;
            this.DataInicioValidade = DateTime.Now.AddDays(1);
        }

        public void Finalizar()
        {
            if (this.Status == EnumStatusOferta.Finalizada)
            {
                throw new Exception("Oferta já finalizada.");
            }

            this.Status = EnumStatusOferta.Finalizada;
        }

        private bool MaximoDeCuponsAtingidos(int quantidade)
        {
            return (this.CuponsGerados.Count + quantidade) > this.NumeroMaximoCupons;
        }

        private int NumeroMaximoCuponsDisponiveis()
        {
            return this.NumeroMaximoCupons - this.CuponsGerados.Count;
        }
    }
}