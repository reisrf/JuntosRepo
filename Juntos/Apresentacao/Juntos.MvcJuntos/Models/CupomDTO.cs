using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Juntos.Model;
using Juntos.Model.Enums;

namespace Juntos.MvcJuntos.Models
{
    public class CupomDTO
    {
        public long id { get; set; }

        public Consumidor Consumidor { get; set; }

        public Oferta  Oferta { get; set; }

        public int DataValidade { get; set; }

        public int DataUtilizacao { get; set; }

        public int nrcupons { get; set; }

        public decimal Valor { get; set; }

        public EnumFormaPagamento FormaPagamento { get; set; }
    }


}