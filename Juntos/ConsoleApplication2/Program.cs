using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleApplication2.proxy;

namespace ConsoleApplication2
{
    class Program
    {

        private static ConsumidorDTO consumidor = null;

        static void Main(string[] args)
        {
            InformarConsumidor();


            while (true)
            {

                bool sai = false;
                showmenu();
                string opcao = Console.ReadLine();

                switch (Convert.ToInt32(opcao))
                {
                    case 0:
                        ListarOfertaPorId();
                        break;
                    case 1:
                        ComprarOferta();
                        break;
                    case 2:
                        ListarCompras();
                        break;
                    case 3:
                        PagarCompra();
                        break;
                    case 4:
                        InformarConsumidor();
                        break;
                    case 5:
                        sai = true;
                        break;
                    default:
                        Console.WriteLine("Não conheço esta opção");
                        break;
                }

                if (sai)
                    break;

            }


        }



        private static void showmenu()
        {

            Console.WriteLine("(0) Listar Oferta por Id");
            Console.WriteLine("(1) Comprar Oferta");
            Console.WriteLine("(2) Listar Compras");
            Console.WriteLine("(3) Pagar Compra");
            Console.WriteLine("(4) Trocar de Consumidor");
            Console.WriteLine("(5) Sair");
        }

        private static void InformarConsumidor()
        {


            while (true)
            {
                Console.Write("Id Consumidor : ");
                string id = Console.ReadLine();

                using (var service = new JuntosServiceClient())
                {
                    consumidor = service.ConsultarConsumidorPeloId(Convert.ToInt32(id));
                }

                if (consumidor != null)
                {
                    Console.WriteLine(consumidor.Id + " / " + consumidor.Nome);

                    break;
                }
                else
                {
                    Console.WriteLine("Não Existe Consumidor com id " + id);
                    Console.WriteLine("Digite Tecle Algo para voltar");
                    Console.ReadLine();

                }
            }

        }
        private static void ListarOfertaPorId()
        {

            using (var service = new JuntosServiceClient())
            {
                Console.Write("Id da Oferta : ");
                string id = Console.ReadLine();
                OfertaDTO oferta = service.ConsultarOfertaPeloId(Convert.ToInt32(id));
                if (oferta != null)
                {
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine("Id : " + oferta.Id);
                    Console.WriteLine("Descricao : " + oferta.Descricao);
                    Console.WriteLine("Condicoes : " + oferta.Condicoes);
                    Console.WriteLine("Endereco : " + oferta.Endereco);
                    Console.WriteLine("Telefone : " + oferta.Telefone);
                    Console.WriteLine("Estado : " + oferta.Status);
                    Console.WriteLine("----------------------------------");
                }
                else
                {

                    Console.WriteLine("Não Existe Oferta com id " + id);
                    Console.WriteLine("Digite Tecle Algo para voltar ao menu");
                    Console.ReadLine();
                }

            }
        }

        private static void ComprarOferta()
        {
            List<OfertaDTO> ofertas = new List<OfertaDTO>();

            using (var service = new JuntosServiceClient())
            {
                bool imprimiu = false;
                ofertas = service.RetornarTodasOfertas();

                if (ofertas.Count > 0)
                {
                    Console.WriteLine("----------------------------------");
                    ofertas.ForEach(o =>
                    {

                        if (o.Status == EnumStatusOferta.Publicada)
                        {
                            imprimiu = true;
                            Console.WriteLine("Id : " + o.Id);
                            Console.WriteLine("Descricao : " + o.Descricao);
                            Console.WriteLine("Condicoes : " + o.Condicoes);
                            Console.WriteLine("Vlr : " + o.ValorCupons);
                            Console.WriteLine("nr.Max Cupons : " + o.NumeroMaximoCupons);

                            Console.WriteLine("----------------------------------");
                        } 
                    }); 

                    if (imprimiu)
                    {
                        Console.WriteLine("Digite o id da oferta que deseja comprar ou 0 para sair");
                        string id = Console.ReadLine();

                        if (!id.Equals("0"))
                        {

                            Console.Write("Numero de Cupons: ");
                            string cupons = Console.ReadLine();

                            service.ComprarOferta(consumidor.Id, Convert.ToInt32(id), Convert.ToInt32(cupons));
                        } 
                        else
                        {

                            Console.WriteLine("Não Existem Ofertas Cadastrados para este anunciante");
                            Console.WriteLine("Digite Tecle Algo para voltar ao menu");
                            Console.ReadLine();
                        } 

                    } 
                    else
                    {
                        Console.WriteLine("Oferta não publicada");
                        Console.WriteLine("Digite Tecle Algo para voltar ao menu");
                        Console.ReadLine();
                    } 
                } 

                else
                {
                    Console.WriteLine("Não Existem Ofertas Cadastrados para este anunciante");
                    Console.WriteLine("Digite Tecle Algo para voltar ao menu");
                    Console.ReadLine();
                } 
            } 
        }

        private static void ListarCompras()
        {
            List<CompraDTO> compras = new List<CompraDTO>();
            
            using (var service = new JuntosServiceClient())
            {
                compras = service.RetornarTodasComprasPorConsumidor(consumidor.Id);
            }

            if (compras.Count > 0)
            {
                Console.WriteLine("----------------------------------");
                compras.ForEach(c =>
                {
                    Console.WriteLine("Id : " + c.Id);
                    Console.WriteLine("Data : " + c.DataCompra);
                    Console.WriteLine("Valor : " + c.ValorTotal);
                    Console.WriteLine("Nr.Cupons : " + c.Cupons.Count);
                    Console.WriteLine("Pagamentos : " + c.Pagamentos.ElementAt(0).Status);
                    
                    Console.WriteLine("----------------------------------");
                });

                Console.WriteLine("Digite Tecle Algo para voltar ao menu");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Não Existem Compras Cadastrados para este Consumidor");
                Console.WriteLine("Digite Tecle Algo para voltar ao menu");
                Console.ReadLine();


            }


        }

        private static void PagarCompra()
        {

            Console.Write("Id Compra : ");
            string id = Console.ReadLine();

            Console.Write("Forma de Pagamento : (P)ayPal, Pa(g)Seguro ou (C)artao =>  ");
            string pagamento = Console.ReadLine();

            EnumFormaPagamento pagto;

            
            switch(pagamento) 
            {
                case "P": 
                case "p":    
                     pagto = EnumFormaPagamento.PayPal;
                     break;
                case "G":
                case "g":
                     pagto = EnumFormaPagamento.PagSeguro;
                     break;
                case "C":
                case "c":
                     pagto = EnumFormaPagamento.Cartão;
                     break;
                default:
                     pagto = EnumFormaPagamento.NaoDefinida;
                     break;
            
            }

            
            using (var service = new JuntosServiceClient())
            {
                service.PagarCompra(Convert.ToInt32(id), pagto);
            }
        }


    }
}
