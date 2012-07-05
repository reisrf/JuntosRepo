using Framework;
using Juntos.IService;

namespace Juntos.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IAnuncianteService anuncianteService = typeof (IAnuncianteService).Fabricar();
        }
    }
}
