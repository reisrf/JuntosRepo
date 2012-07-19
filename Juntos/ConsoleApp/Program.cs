using System;
using Juntos.IService;
using Framework;
using Juntos.Model;
using Juntos.Model.Enums;

namespace Juntos.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IConsumidorService anuncianteService = typeof (IConsumidorService).Fabricar();
            IPagamentoService pagamentoService = typeof(IPagamentoService).Fabricar();
        }
    }
}