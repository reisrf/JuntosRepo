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
                        
               Anunciante empresaA = CriarAnunciante("Empresa A LTDA",EnumTipoPessoa.Juridica,11111111111111, "empresai@servidor.com");
               Anunciante empresaB = CriarAnunciante("Empresa B LTDA", EnumTipoPessoa.Juridica, 22222222222222, "empresaa@servidor.com");
               Anunciante empresaC = CriarAnunciante("Empresa C LTDA", EnumTipoPessoa.Juridica, 33333333333333, "empresae@servidor.com");
               client.SalvarAnunciante(empresaA);
               client.SalvarAnunciante(empresaB);
               client.SalvarAnunciante(empresaC);

               Consumidor consumidorA = CriarConsumidor("Genesio Orlando", EnumTipoPessoa.Fisica, 30030030030, "email@servidor.com");
               Consumidor consumidorB = CriarConsumidor("Gervasio Andre", EnumTipoPessoa.Fisica, 12345678909, "emeio@servidor.com");
               Consumidor consumidorC = CriarConsumidor("Geroncio Bernardo", EnumTipoPessoa.Fisica, 11111111111, "emaul@servidor.com");
               client.SalvarConsumidor(consumidorA);
               client.SalvarConsumidor(consumidorB);
               client.SalvarConsumidor(consumidorC);

               Anunciante anunciante = client.ConsultarAnunciantePeloId(2);

               Oferta ofertaA = new Oferta();

               ofertaA.Anunciante = anunciante;
               ofertaA.Condicoes = "So nos dias de semana ate as 18 horas";
               ofertaA.Descricao = "Cha completo para duas pessoas";
               ofertaA.DataInicioValidade = DateTime.Now;
               ofertaA.DataExpiracao = DateTime.Now.AddDays(5);
               ofertaA.DataValidadeCupons = DateTime.Now.AddDays(30);
               ofertaA.ValorCupons = 30;
               ofertaA.NumeroMaximoCupons = 100;
                           
               Oferta ofertaB = new Oferta();

               ofertaB.Anunciante = anunciante;
               ofertaB.Condicoes = "tercas e quintas";
               ofertaB.Descricao = "Jantar a luz de velas";
               ofertaB.DataInicioValidade = DateTime.Now;
               ofertaB.DataExpiracao = DateTime.Now.AddDays(2);
               ofertaB.DataValidadeCupons = DateTime.Now.AddDays(15);
               ofertaB.ValorCupons = 50;
               ofertaB.NumeroMaximoCupons = 70;

               client.SalvarOferta(ofertaA);
               client.SalvarOferta(ofertaB);

               List<Oferta> ofertas = client.RetornarTodasOfertas();

               ofertas.ForEach(o => {

                   if (o.Status == EnumStatusOferta.Criada)
                       client.PublicarOferta(o.Id);
               
               
               });

                Consumidor consumidor = client.ConsultarConsumidorPeloId(4);
               
                Oferta oferta1 = client.ConsultarOfertaPeloId(1);
                Oferta oferta2 = client.ConsultarOfertaPeloId(2);

               Compra compraA = client.ComprarOferta(consumidor.Id, oferta1.Id, 4);
               client.SalvarCompra(compraA);
               Compra compraB = client.ComprarOferta(consumidor.Id, oferta2.Id, 6);
               client.SalvarCompra(compraB);

               consumidor = client.ConsultarConsumidorPeloId(4);

               consumidor.Compras.ForEach(c => {

                   client.PagarCompra(c.Id, EnumFormaPagamento.PagSeguro);    
 
               
               });


               oferta1.CuponsGerados.ForEach(o => {

                   if (o.Id % 2 == 0)
                   {
                       client.InformarUsoCupom(o.Id);
                   }
               
               
               });


              List<Cupom> cupons = client.ConsolidarOferta(oferta2.Id);

              decimal total = 0;

              cupons.ForEach(c =>
              {

                  Console.WriteLine("Cupom " + c.Id + ":" + c.Valor);
                  total = total + c.Valor;

              });

              Console.WriteLine("Total da Oferta = " + total);
                

                       
                            
            
            

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



        }
       }

   