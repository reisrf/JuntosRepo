using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OfertaConsoleTest.proxy;

namespace OfertaConsoleTest
{
    
    class Program
    {
        private static AnuncianteDTO anunciante = null;

        static void Main(string[] args)
        {
            InformarAnunciante();
                       

            while (true)
            {

                bool sai = false;
                showmenu();
                string opcao = Console.ReadLine();

                switch (Convert.ToInt32(opcao))
                {
                    case 0:
                        IncluirOferta();
                        break;
                    case 1:
                        PublicarOferta();
                        break;
                    case 2:
                        OfertaPorAnunciante();
                        break;
                    case 3:
                        OfertaPorId();
                        break;
                    case 4:
                        OfertasNaoPublicada();
                        break;
                    case 5:
                        InformarAnunciante();
                        break;
                    case 6:
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

            Console.WriteLine("(0) Incluir Oferta");
            Console.WriteLine("(1) Publicar Oferta");
            Console.WriteLine("(2) Listar Oferta");
            Console.WriteLine("(3) Listar Oferta por Id");
            Console.WriteLine("(4) Listar Nao Publicas");
            Console.WriteLine("(5) Trocar de Anunciante");
            Console.WriteLine("(6) Sair");
        }


        private static void IncluirOferta() {
            //Dados da Oferta
            Console.Write("Descricao : ");
            string descricao = Console.ReadLine();
            Console.Write("Condição : ");
            string condicao = Console.ReadLine();
            Console.Write("Valor : ");
            string valor = Console.ReadLine();
            Console.Write("Numero Maximo de Cupons ");
            string maxcupons = Console.ReadLine();
            Console.Write("Validade da Oferta em dias ");
            string validadeO = Console.ReadLine();
            Console.Write("Validade dos Cupons em dias ");
            string validadeC = Console.ReadLine();
            //Endereco
            Console.Write("Logradouro : ");
            string logradouro = Console.ReadLine();
            Console.Write("Complemento : ");
            string complemento = Console.ReadLine();
            Console.Write("Numero : ");
            string numero = Console.ReadLine();
            Console.Write("Bairro : ");
            string bairro = Console.ReadLine();
            Console.Write("Cidade : ");
            string cidade = Console.ReadLine();
            Console.Write("Estado : ");
            string estado = Console.ReadLine();
            Console.Write("CEP : ");
            string cep = Console.ReadLine();
            Console.Write("Pais : ");
            string pais = Console.ReadLine();

            EnderecoDTO endereco = new EnderecoDTO();
            endereco.Logradouro = logradouro;
            endereco.Complemento = complemento;
            endereco.Numero = Convert.ToInt32(numero);
            endereco.Bairro = bairro;
            endereco.Cidade = cidade;
            endereco.Estado = estado;
            endereco.Cep = cep;
            endereco.Pais = pais;

            OfertaDTO oferta = new OfertaDTO();

            oferta.Endereco = endereco;
            oferta.Condicoes = condicao;
            oferta.DataExpiracao = DateTime.Now.AddDays(Convert.ToInt32(validadeO));
            oferta.DataValidadeCupons = DateTime.Now.AddDays(Convert.ToInt32(validadeC));
            oferta.Descricao = descricao;
            oferta.NumeroMaximoCupons = Convert.ToInt32(maxcupons);
            oferta.Status = EnumStatusOferta.Criada;
            oferta.ValorCupons = Convert.ToDecimal(valor);


            using (var service = new JuntosServiceClient())
            {
                service.SalvarOferta(oferta, anunciante.Id);
             }

        }

        private static void PublicarOferta() {
            
            List<OfertaDTO> ofertas = new List<OfertaDTO>();

            using (var service = new JuntosServiceClient())
            {
                  bool imprimiu = false;
                  ofertas = service.RetornarTodasOfertasPorAnunciante(anunciante.Id);

                 if (ofertas.Count > 0)
                 {
                     Console.WriteLine("----------------------------------");
                     ofertas.ForEach(o =>
                     {
                         
                         if (o.Status == EnumStatusOferta.Criada) {
                             imprimiu=true;
                             Console.WriteLine("Id : " + o.Id );
                             Console.WriteLine("Descricao : " + o.Descricao );
                             Console.WriteLine("Condicoes : " + o.Condicoes);
                             Console.WriteLine("Estado : " + o.Status);
                             Console.WriteLine("----------------------------------");
                        } //if for-each
                     } );  //lambda for-each

                     if (imprimiu) {
                         Console.WriteLine("Digite o id da oferta a ser publicada ou 0 para sair");
                         string id = Console.ReadLine();

                         if (!id.Equals("0")) { 
                            service.PublicarOferta(Convert.ToInt32(id));
                         } //if 0 
                         else 
                         {
                           
                            Console.WriteLine("Não Existem Ofertas Cadastrados para este anunciante");
                            Console.WriteLine("Digite Tecle Algo para voltar ao menu");
                            Console.ReadLine();
                         } // else 0

                     } // if imprimiu 
                     else 
                     {
                          Console.WriteLine("Oferta não publicada");
                          Console.WriteLine("Digite Tecle Algo para voltar ao menu");
                          Console.ReadLine();
                     } // else imprimiu
                 } // if oferta.count 0
            
                 else
                 {
                     Console.WriteLine("Não Existem Ofertas Cadastrados para este anunciante");
                     Console.WriteLine("Digite Tecle Algo para voltar ao menu");
                     Console.ReadLine();           
                 } // else oferta.count 0
            } //using
        } //metodo

        private static void OfertaPorAnunciante() {

            List<OfertaDTO> ofertas = new List<OfertaDTO>();
            using (var service = new JuntosServiceClient())
            {
                 ofertas = service.RetornarTodasOfertasPorAnunciante(anunciante.Id);

                 if (ofertas.Count > 0)
                 {
                     Console.WriteLine("----------------------------------");
                     ofertas.ForEach(o =>
                     {
                         Console.WriteLine("Id : " + o.Id );
                         Console.WriteLine("Descricao : " + o.Descricao );
                         Console.WriteLine("Condicoes : " + o.Condicoes);
                         Console.WriteLine("Estado : " + o.Status);
                         Console.WriteLine("----------------------------------");
                     });

                     Console.WriteLine("Digite Tecle Algo para voltar ao menu");
                     Console.ReadLine();
                 }
                 else
                 {
                     Console.WriteLine("Não Existem Ofertas Cadastrados para este anunciante");
                     Console.WriteLine("Digite Tecle Algo para voltar ao menu");
                     Console.ReadLine();


                 }


            }
        
        
        }

        private static void OfertaPorId() {

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

        private static void OfertasNaoPublicada() {

            List<OfertaDTO> ofertas = new List<OfertaDTO>();

            using (var service = new JuntosServiceClient())
            {
                bool imprimiu = false;
                ofertas = service.RetornarTodasOfertasPorAnunciante(anunciante.Id);

                if (ofertas.Count > 0)
                {
                    Console.WriteLine("----------------------------------");
                    ofertas.ForEach(o =>
                    {

                        if (o.Status == EnumStatusOferta.Criada)
                        {
                            imprimiu = true;
                            Console.WriteLine("Id : " + o.Id);
                            Console.WriteLine("Descricao : " + o.Descricao);
                            Console.WriteLine("Condicoes : " + o.Condicoes);
                            Console.WriteLine("Estado : " + o.Status);
                            Console.WriteLine("----------------------------------");
                        } //if for-each
                    });  //lambda for-each

                    if (!imprimiu)
                    {
                        Console.WriteLine("Não Existem Ofertas Cadastrados para este anunciante");
                        Console.WriteLine("Digite Tecle Algo para voltar ao menu");
                        Console.ReadLine();
                    } 

                  
                } // if oferta.count 0

                else
                {
                    Console.WriteLine("Não Existem Ofertas Cadastrados para este anunciante");
                    Console.WriteLine("Digite Tecle Algo para voltar ao menu");
                    Console.ReadLine();
                } // else oferta.count 0
            } //using
        
        
        
        }
        
        private static void InformarAnunciante() {
            

            while (true)
            {
                Console.Write("Id Anunciante : ");
                string id = Console.ReadLine();

                using (var service = new JuntosServiceClient())
                {
                    anunciante = service.ConsultarAnunciantePeloId(Convert.ToInt32(id));
                }

                if (anunciante != null)
                {
                    Console.WriteLine(anunciante.Id + " / " + anunciante.Nome);
                    
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



        




    }
}
