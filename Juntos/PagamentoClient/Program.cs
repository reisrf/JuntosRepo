using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Juntos.IService;



namespace Juntos.Aplicacao.PagamentoClient
{
    class Program
    {
        static void Main(string[] args)
        {


            IPagamentoService pagamentoService = typeof(IPagamentoService).Fabricar();


           
        }
    }
}
