using System;
using Juntos.IService;
using Framework;
using Juntos.Model;
using Juntos.Model.Enums;
using System.Collections.Generic;
using System.IO;

namespace Juntos.ConsoleApp
{
    class Program
    {
        private static IConsumidorService consumidorService = typeof(IConsumidorService).Fabricar();
        
        static void Main(string[] args)
        {

            //limpa banco de dados 
            if (File.Exists(@"c:\cd\JuntosDb.sdf"))
                File.Delete(@"c:\cd\JuntosDb.sdf");


            /*Testes de Consumidores*/
            List<Consumidor> consumidores = GeraConsumidoresParaTeste();

            consumidores.ForEach(c =>
            {
                IncluiConsumidor(c);

            });

  
            
                     
        }


        private static void IncluiConsumidor(Consumidor consumidor)
        {
            consumidorService.Adicionar(consumidor);
        }

        private static void AlteraConsumidor(Consumidor consumidor)
        {

        }

        private static void ExcluiConsumidor(Consumidor consumidor)
        {

        }
        
        private static Consumidor ListaConsumidor(Guid id)
        {
            return null;
        }

        private static List<Consumidor> ListaConsumidores()
        {
            return null;
        }

        private static List<Consumidor> GeraConsumidoresParaTeste()
        {
            return null;
            /*
            Consumidor consumidor = new Consumidor();
            consumidor.CpfCnpj =30030030030;
            //consumidor.Compras = new List<Compra>();
            consumidor.Email = "email@servidor.com";
            consumidor.Id = 0;
            consumidor.Nome = "Incluido da Silva";
            consumidor.Tipo = EnumTipoPessoa.Fisica;
                        
            
            Endereco endereco = new Endereco();
            endereco.Id = 0;
            endereco.Logradouro = "Onde eu moro";
            endereco.Numero=0;
            endereco.Bairro="bairro";
            endereco.Cidade="Rio de Janeiro";
            endereco.Estado="RJ";
            endereco.Cep="22222-222";
            endereco.Complemento="Palacio";
            endereco.Pais="Brasil";
          
            Telefone telefone = new Telefone();
            telefone.DDI=55;
            telefone.DDD=21;
            telefone.Numero=22222222;
            telefone.Id=0;

            consumidor.Enderecos.Add(endereco);
            consumidor.Telefones.Add(telefone);

             Consumidor consumidor1 = new Consumidor();
            consumidor1.CpfCnpj =191;
            //consumidor1.Compras = new List<Compra>();
            consumidor1.Email = "email-empresa@servidor.com";
            consumidor1.Id = 0;
            consumidor1.Nome = "Trambiques e Trombadas";
            consumidor1.Tipo = EnumTipoPessoa.Fisica;
            
            Endereco endereco1 = new Endereco();
            endereco1.Id = 0;
            endereco1.Logradouro = "Onde a empresa mora";
            endereco1.Numero=0;
            endereco1.Bairro="bairro";
            endereco1.Cidade="Rio de Janeiro";
            endereco1.Estado="RJ";
            endereco1.Cep="11111-111";
            endereco1.Complemento="Palacio";
            endereco1.Pais="Brasil";
          
            Telefone telefone1 = new Telefone();
            telefone1.DDI=55;
            telefone1.DDD=21;
            telefone1.Numero=11111111;
            telefone1.Id=0;

            consumidor1.Enderecos.Add(endereco1);
            consumidor1.Telefones.Add(telefone1);


            Consumidor consumidor2 = new Consumidor();
            consumidor2.CpfCnpj = 11111111111;
            //consumidor2.Compras = new List<Compra>();
            consumidor2.Email = "exmail@servidor.com";
            consumidor2.Id = 0;
            consumidor2.Nome = "Excluido da Silva";
            consumidor2.Tipo = EnumTipoPessoa.Fisica;

            Endereco endereco2 = new Endereco();
            endereco2.Id = 0;
            endereco2.Logradouro = "Sem Destino";
            endereco2.Numero = 0;
            endereco2.Bairro = "bairro";
            endereco2.Cidade = "Rio de Janeiro";
            endereco2.Estado = "RJ";
            endereco2.Cep = "33333-333";
            endereco2.Complemento = "Palacio";
            endereco2.Pais = "Brasil";

            Telefone telefone2 = new Telefone();
            telefone2.DDI = 55;
            telefone2.DDD = 21;
            telefone2.Numero = 33333333;
            telefone2.Id = Guid.NewGuid();

            consumidor2.Enderecos.Add(endereco);
            consumidor2.Telefones.Add(telefone);

            List<Consumidor> result = new List<Consumidor>();

            result.Add(consumidor);
            result.Add(consumidor1);
            result.Add(consumidor2);
            
            return result; */
        }
      


    }
}