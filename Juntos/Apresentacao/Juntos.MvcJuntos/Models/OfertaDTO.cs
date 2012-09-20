using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Juntos.Model;
using Juntos.Model.Enums;

namespace Juntos.MvcJuntos.Models
{
    public class OfertaDTO
    {
        public long id { get; set; }

        public Anunciante Anunciante { get; set; }

        public EnumStatusOferta Status { get; set; }

        public DateTime? DataPublicacao { get; set; }

        public DateTime DataValidadeCupons { get; set; }

        public DateTime DataExpiracao { get; set; }

        public DateTime? DataInicioValidade { get; set; }

        public decimal ValorCupons { get; set; }

        public string Descricao { get; set; }

        public string Condicoes { get; set; }

        public string Endereco { get; set; }

        public string Telefone { get; set; }

        public virtual List<Cupom> CuponsGerados { get; set; }

        public int NumeroMaximoCupons { get; set; }
    }


}