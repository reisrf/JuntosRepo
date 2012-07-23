using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Juntos.Apresentacao.ConsoleTest.wsProxy;

namespace Juntos.Apresentacao.ConsoleTest
{
    class Program
    {
        private static JuntosServiceClient client;
       
        static void Main(string[] args)
        {
            start();


               Console.WriteLine("Criando Anunciantes");
               Anunciante empresaA = CriarAnunciante("Empresa A LTDA",EnumTipoPessoa.Juridica,11111111111111, "empresa_A@servidor.com");
               Anunciante empresaB = CriarAnunciante("Empresa B LTDA", EnumTipoPessoa.Juridica, 22222222222222, "empresa_B@servidor.com");
               Anunciante empresaC = CriarAnunciante("Empresa C LTDA", EnumTipoPessoa.Juridica, 33333333333333, "empresa_C@servidor.com");
               
               Console.WriteLine("Salvando Anunciantes");
               client.SalvarAnunciante(empresaA);
               client.SalvarAnunciante(empresaB);
               client.SalvarAnunciante(empresaC);

               Console.WriteLine("Criando Consumidores");
               Consumidor consumidorA = CriarConsumidor("Genesio Orlando", EnumTipoPessoa.Fisica, 30030030030, "genesio@servidor.com");
               Consumidor consumidorB = CriarConsumidor("Gervasio Andre", EnumTipoPessoa.Fisica, 12345678909, "gervasio@servidor.com");
               Consumidor consumidorC = CriarConsumidor("Geroncio Bernardo", EnumTipoPessoa.Fisica, 11111111111, "geroncio@servidor.com");
               
               Console.WriteLine("Salvando Anunciantes");
               client.SalvarConsumidor(consumidorA);
               client.SalvarConsumidor(consumidorB);
               client.SalvarConsumidor(consumidorC);

               Console.WriteLine("Gerando Ofertas");
               //Anunciante anunciante = ObterAnunciante();
               Anunciante anunciante = ObterAnunciantePorEmail("empresa_A@servidor.com");
               //anunciante.Ofertas = new List<Oferta>();
               Console.WriteLine(">");
               Oferta ofertaA = GerarOferta("Cha completo para duas pessoas",anunciante,"So nos dias de semana ate as 18 horas", 30, 100);
               client.SalvarOferta(ofertaA, anunciante.Id);
               Oferta ofertaB = GerarOferta("Jantar Pink Fleet", anunciante, "Tercas e quintas", 10, 30);
               client.SalvarOferta(ofertaB, anunciante.Id);
               Oferta ofertaC = GerarOferta("Rodizio de Pizza", anunciante, "Segundas e Tercas", 35, 10);
               client.SalvarOferta(ofertaC, anunciante.Id);


             
               Console.WriteLine("Publicando Oferta");

               PublicarOferta();

               Console.WriteLine("Comprando Oferta");

               Consumidor consumidor = ObterConsumidor();
               Oferta oferta = ObterOferta();

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

            stop();

        }


        private static void start()
        {
            client = new JuntosServiceClient();
        }


        private static void stop()
        {
            client.Close();
        }

        private static Anunciante CriarAnunciante(string nome, EnumTipoPessoa tipopessoa, long inscricao, string email)
        {
            Anunciante anunciante = new Anunciante();

            anunciante.Nome = nome;
            anunciante.Email = email;
            anunciante.CpfCnpj = inscricao;
            anunciante.Tipo = tipopessoa;
            
            Endereco endereco = new Endereco();
            endereco.Logradouro = "Rua A";
            endereco.Numero = 30;
            endereco.Complemento = "Apto 607";
            endereco.Bairro = "Cantao";
            endereco.Cidade = "Malnicipio";
            endereco.Estado = "RJ";
            endereco.Cep = "11111-111";
            endereco.Pais = "Brasil";
            
            Telefone telefone = new Telefone();
            telefone.DDI = 51;
            telefone.DDD = 21;
            telefone.Numero = 22757643;

            anunciante.Telefones = new List<Telefone>();
            anunciante.Enderecos = new List<Endereco>();
            anunciante.Telefones.Add(telefone);
            anunciante.Enderecos.Add(endereco);

            return anunciante;
        }

        private static Consumidor CriarConsumidor(string nome, EnumTipoPessoa tipopessoa, long inscricao, string email)
        {
            Consumidor consumidor = new Consumidor();

            consumidor.Nome = nome;
            consumidor.Email = email;
            consumidor.CpfCnpj = inscricao;
            consumidor.Tipo = tipopessoa;

            
            Endereco endereco = new Endereco();
            endereco.Logradouro = "Rua A";
            endereco.Numero = 30;
            endereco.Complemento = "Apto 607";
            endereco.Bairro = "Cantao";
            endereco.Cidade = "Malnicipio";
            endereco.Estado = "RJ";
            endereco.Cep = "11111-111";
            endereco.Pais = "Brasil";

            Telefone telefone = new Telefone();
            telefone.DDI = 51;
            telefone.DDD = 21;
            telefone.Numero = 22757643;

            consumidor.Telefones = new List<Telefone>();
            consumidor.Enderecos = new List<Endereco>();

            consumidor.Telefones.Add(telefone);
            consumidor.Enderecos.Add(endereco);
            
            return consumidor;
        }

        private static Anunciante ObterAnunciante()
        {

            List<Anunciante> anunciantes = client.RetornarTodosAnunciantes();
            Anunciante anunciante=null;

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

        private static Anunciante ObterAnunciantePorEmail(string email)
        {

            Anunciante anunciante = client.ConsultarAnunciantePeloEmail(email);

            if (anunciante!=null)
            {

                return anunciante;
            }
            else
            {
                throw new Exception("Anunciante não cadastrado");
            }

        }
        private static Oferta GerarOferta(string descricao, Anunciante anunciante, string condicao, int nrcupons, decimal valor)
        {
            Oferta ofertaA = new Oferta();

            //ofertaA.Anunciante = anunciante;
            ofertaA.Condicoes = condicao;
            ofertaA.Descricao = descricao;
            ofertaA.DataInicioValidade = DateTime.Now;
            ofertaA.DataExpiracao = DateTime.Now.AddDays(7);
            ofertaA.DataValidadeCupons = DateTime.Now.AddDays(30);
            ofertaA.ValorCupons = valor;
            ofertaA.NumeroMaximoCupons = nrcupons;

            return ofertaA;
        }


        private static void PublicarOferta()
        {
            List<Oferta> ofertas = client.RetornarTodasOfertas();

            ofertas.ForEach(o =>
            {

                if (o.Status == EnumStatusOferta.Criada)
                    client.PublicarOferta(o.Id);

            });
        }


        private static Consumidor ObterConsumidor()
        {
            List<Consumidor> consumidores = client.RetornarTodosConsumidores();

            Consumidor consumidor = null;

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

        private static Oferta ObterOferta() {

            List<Oferta> ofertas = client.RetornarTodasOfertas();

            Oferta oferta = null;

            if (ofertas.Count > 0)
            {
                oferta = ofertas.ElementAt(0);
                
            }
            else
            {
                throw new Exception("Não existem anunciantes cadastrados");
            }


            return oferta;
        
        }


        private static void ComprarOfertas(Consumidor consumidor, Oferta oferta, int nrcupons) {

            Compra compra = client.ComprarOferta(consumidor.Id, oferta.Id, nrcupons);
            client.SalvarCompra(compra);
         
       }


        private static void PagarCompras(Consumidor consumidor, EnumFormaPagamento tipo)
        {
            consumidor.Compras.ForEach(c =>
            {
            
               
                client.PagarCompra(c.Id, tipo);


            });
        }

        private static void InformarCupom(Oferta oferta) 
        {
            oferta.CuponsGerados.ForEach(o =>
            {

                if (o.Id % 2 == 0)
                {
                    client.InformarUsoCupom(o.Id);
                }


            });
        }

        private static void ConsolidarOferta(Oferta oferta)
        {
            List<Cupom> cupons = client.ConsolidarOferta(oferta.Id);

            decimal total = 0;

            cupons.ForEach(c =>
            {

                Console.WriteLine("Cupom " + c.Id + ":" + c.Valor);
                total = total + c.Valor;

            });

            Console.WriteLine("Total da Oferta = " + total);
                
        }



        }
       }

   