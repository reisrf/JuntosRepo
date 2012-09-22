using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Juntos.Apresentacao.ConsoleTest.proxy;


namespace Juntos.Apresentacao.ConsoleTest
{
    class Program
    {
        private static JuntosServiceClient client;
       
        static void Main(string[] args)
        {
            start();
            try
            {
                Console.WriteLine("Criando Anunciantes");
                AnuncianteDTO empresaA = CriarAnunciante("Empresa A LTDA", EnumTipoPessoa.Juridica, 11111111111111, "empresa_A@servidor.com");
                AnuncianteDTO empresaB = CriarAnunciante("Empresa B LTDA", EnumTipoPessoa.Juridica, 22222222222222, "empresa_B@servidor.com");
                AnuncianteDTO empresaC = CriarAnunciante("Empresa C LTDA", EnumTipoPessoa.Juridica, 33333333333333, "empresa_C@servidor.com");

                Console.WriteLine("Salvando Anunciantes");
                client.SalvarAnunciante(empresaA);
                client.SalvarAnunciante(empresaB);
                client.SalvarAnunciante(empresaC);

                Console.WriteLine("Criando Consumidores");
                ConsumidorDTO consumidorA = CriarConsumidor("Genesio Orlando", EnumTipoPessoa.Fisica, 30030030030, "genesio@servidor.com");
                ConsumidorDTO consumidorB = CriarConsumidor("Gervasio Andre", EnumTipoPessoa.Fisica, 12345678909, "gervasio@servidor.com");
                ConsumidorDTO consumidorC = CriarConsumidor("Geroncio Bernardo", EnumTipoPessoa.Fisica, 11111111111, "geroncio@servidor.com");

                Console.WriteLine("Salvando Anunciantes");
                client.SalvarConsumidor(consumidorA);
                client.SalvarConsumidor(consumidorB);
                client.SalvarConsumidor(consumidorC);

                Console.WriteLine("Gerando Ofertas");
                //Anunciante anunciante = ObterAnunciante();
                AnuncianteDTO anunciante = ObterAnunciantePorEmail("empresa_A@servidor.com");
                //anunciante.Ofertas = new List<Oferta>();
                Console.WriteLine(">");
                OfertaDTO ofertaA = GerarOferta("Cha completo para duas pessoas", anunciante, "So nos dias de semana ate as 18 horas", 120, 100);
                client.SalvarOferta(ofertaA, anunciante.Id);

                Console.WriteLine(">>");
                OfertaDTO ofertaB = GerarOferta("Jantar Pink Fleet", anunciante, "Tercas e quintas", 100, 30);
                client.SalvarOferta(ofertaB, anunciante.Id);


                Console.WriteLine(">>>");
                OfertaDTO ofertaC = GerarOferta("Rodizio de Pizza", anunciante, "Segundas e Tercas", 150, 10);
                client.SalvarOferta(ofertaC, anunciante.Id);

                Console.WriteLine("Publicando Oferta");

                PublicarOferta(anunciante.Id);

                Console.WriteLine("Comprando Oferta");

                ConsumidorDTO consumidor = ObterConsumidor();
                OfertaDTO oferta = ObterOferta(anunciante.Id);

                ComprarOfertas(consumidor, oferta, 5);

                Console.WriteLine("Pagar Compra");

                PagarCompras(consumidor, EnumFormaPagamento.PayPal);


                Console.WriteLine("Comprando Oferta de novo");
                ComprarOfertas(consumidor, oferta, 10);

                Console.WriteLine("Pagar nova Compra");
                PagarCompras(consumidor, EnumFormaPagamento.PagSeguro);

                Console.WriteLine("Informar utilizacao Cupom");
                InformarCupom(oferta);

                Console.WriteLine("Consolidar Oferta");
                ConsolidarOferta(oferta);
            }
            finally
            {
                stop();
            }
        }


        private static void start()
        {
            client = new JuntosServiceClient();
        }


        private static void stop()
        {
            client.Close();
        }

        private static AnuncianteDTO CriarAnunciante(string nome, EnumTipoPessoa tipopessoa, long inscricao, string email)
        {
            AnuncianteDTO anunciante = new AnuncianteDTO();

            anunciante.Nome = nome;
            anunciante.Email = email;
            anunciante.Inscricao = inscricao;
            anunciante.Tipo = tipopessoa;
            
            EnderecoDTO endereco = new EnderecoDTO();
            endereco.Logradouro = "Rua A";
            endereco.Numero = 30;
            endereco.Complemento = "Apto 607";
            endereco.Bairro = "Cantao";
            endereco.Cidade = "Malnicipio";
            endereco.Estado = "RJ";
            endereco.Cep = "11111-111";
            endereco.Pais = "Brasil";
            
            TelefoneDTO telefone = new TelefoneDTO();
            telefone.DDI = 51;
            telefone.DDD = 21;
            telefone.Numero = 22757643;

            anunciante.Telefones = new List<TelefoneDTO>();
            anunciante.Enderecos = new List<EnderecoDTO>();
            anunciante.Telefones.Add(telefone);
            anunciante.Enderecos.Add(endereco);

            return anunciante;
        }

        private static ConsumidorDTO CriarConsumidor(string nome, EnumTipoPessoa tipopessoa, long inscricao, string email)
        {
            ConsumidorDTO consumidor = new ConsumidorDTO();

            consumidor.Nome = nome;
            consumidor.Email = email;
            consumidor.Inscricao = inscricao;
            consumidor.Tipo = tipopessoa;

            
            EnderecoDTO endereco = new EnderecoDTO();
            endereco.Logradouro = "Rua A";
            endereco.Numero = 30;
            endereco.Complemento = "Apto 607";
            endereco.Bairro = "Cantao";
            endereco.Cidade = "Malnicipio";
            endereco.Estado = "RJ";
            endereco.Cep = "11111-111";
            endereco.Pais = "Brasil";

            TelefoneDTO telefone = new TelefoneDTO();
            telefone.DDI = 51;
            telefone.DDD = 21;
            telefone.Numero = 22757643;

            consumidor.Telefones = new List<TelefoneDTO>();
            consumidor.Enderecos = new List<EnderecoDTO>();

            consumidor.Telefones.Add(telefone);
            consumidor.Enderecos.Add(endereco);
            
            return consumidor;
        }

        private static AnuncianteDTO ObterAnunciante()
        {

            List<AnuncianteDTO> anunciantes = client.RetornarTodosAnunciantes();
            AnuncianteDTO anunciante=null;

            if (anunciantes.Count > 0)
            {

                anunciante = anunciantes.ElementAt(0);
            }
            else
            {
                throw new Exception("Não existem anunciantes cadastrados");
            }


            return anunciante;
        }

        private static AnuncianteDTO ObterAnunciantePorEmail(string email)
        {

            AnuncianteDTO anunciante = client.ConsultarAnunciantePeloEmail(email);

            if (anunciante!=null)
            {

                return anunciante;
            }
            else
            {
                throw new Exception("Anunciante não cadastrado");
            }

        }
        private static OfertaDTO GerarOferta(string descricao, AnuncianteDTO anunciante, string condicao, int nrcupons, decimal valor)
        {
            OfertaDTO ofertaA = new OfertaDTO();

           // ofertaA.Anunciante = anunciante;
            ofertaA.Condicoes = condicao;
            ofertaA.Descricao = descricao;
            ofertaA.DataInicioValidade = DateTime.Now;
            ofertaA.DataExpiracao = DateTime.Now.AddDays(7);
            ofertaA.DataValidadeCupons = DateTime.Now.AddDays(30);
            ofertaA.ValorCupons = valor;
            ofertaA.NumeroMaximoCupons = nrcupons;


            ofertaA.Endereco = "Rua Oferta numero 10";
          

            return ofertaA;
        }


        private static void PublicarOferta(long id)
        {
            Console.WriteLine("Publicando Oferta");
            List<OfertaDTO> ofertas = client.RetornarTodasOfertasPorAnunciante(id);
            Console.WriteLine("Obter ofertas");

            if (ofertas == null)
            {
                Console.WriteLine("Eh null");
            }
            else
            {
                Console.WriteLine("Pussui {0} membros", ofertas.Count);
            }

            ofertas.ForEach(o =>
            {
                Console.WriteLine("Publicando Oferta : " + o.Id);

                if (o.Status == EnumStatusOferta.Criada)
                    client.PublicarOferta(o.Id);

            });
        }


        private static ConsumidorDTO ObterConsumidor()
        {
            List<ConsumidorDTO> consumidores = client.RetornarTodosConsumidores();

            ConsumidorDTO consumidor = null;

            if (consumidores.Count > 0)
            {

                consumidor = consumidores.ElementAt(0);
            }
            else
            {
                throw new Exception("Não existem anunciantes cadastrados");
            }


            return consumidor;
        }

        private static OfertaDTO ObterOferta(long id) {

            List<OfertaDTO> ofertas = client.RetornarTodasOfertasPorAnunciante(id);

            OfertaDTO oferta = null;

            if (ofertas.Count > 0)
            {
                oferta = ofertas.ElementAt(0);
                
            }
            else
            {
                throw new Exception("Não existem anunciantes cadastrados");
            }



            return client.ConsultarOfertaPeloId(oferta.Id);
        
        }


        private static void ComprarOfertas(ConsumidorDTO consumidor, OfertaDTO oferta, int nrcupons) {

            CompraDTO compra = client.ComprarOferta(consumidor.Id, oferta.Id, nrcupons);
            client.SalvarCompra(compra);
         
       }


        private static void PagarCompras(ConsumidorDTO consumidor, EnumFormaPagamento tipo)
        {

            if (consumidor.Compras != null && consumidor.Compras.Count > 0)
            {

                consumidor.Compras.ForEach(c =>
                {
                    client.PagarCompra(c.Id, tipo);

                });
            }
        }

        private static void InformarCupom(OfertaDTO oferta) 
        {

            if (oferta.CuponsGerados != null && oferta.CuponsGerados.Count > 0)
            {


                oferta.CuponsGerados.ForEach(o =>
                {

                    if (o.Id % 2 == 0)
                    {
                        client.InformarUsoCupom(o.Id);
                    }


                });
            }
        }

        private static void ConsolidarOferta(OfertaDTO oferta)
        {
            List<CupomDTO> cupons = client.ConsolidarOferta(oferta.Id);

            decimal total = 0;

            if (cupons != null && cupons.Count > 0)
            {

                cupons.ForEach(c =>
                {

                    Console.WriteLine("Cupom " + c.Id + ":" + c.Valor);
                    total = total + c.Valor;

                });
            }

            Console.WriteLine("Total da Oferta = " + total);
                
        }



        }
       }

   