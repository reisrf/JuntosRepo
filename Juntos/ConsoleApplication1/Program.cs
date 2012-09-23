using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleApplication1.proxy;


namespace PessoaConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {

                bool sai = false;
                showmenu();
                string opcao = Console.ReadLine();

                switch (Convert.ToInt32(opcao))
                {
                    case 0:
                        IncluirAnunciante();
                        break;
                    case 1:
                        IncluirConsumidor();
                        break;
                    case 2:
                        ListarTodosAnunciantes();
                        break;
                    case 3:
                        ListarTodosConsumidores();
                        break;
                    case 4:
                        ListarAnunciantePorId();
                        break;
                    case 5:
                        ListarConsumidorPorId();
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

            Console.WriteLine("(0) Incluir Anunciante");
            Console.WriteLine("(1) Incluir Consumidor");
            Console.WriteLine("(2) Listar Todos Anunciantes");
            Console.WriteLine("(3) Listar Todos Consumidores");
            Console.WriteLine("(4) Listar Anunciante por Id");
            Console.WriteLine("(5) Listar Consumidor por Id");
            Console.WriteLine("(6) Sair");
        }
        
        private static void IncluirAnunciante()
        {
            Console.Write("Nome : ");
            string nome = Console.ReadLine();
            Console.Write("Inscricao : ");
            string inscricao = Console.ReadLine();
            Console.Write("email : ");
            string email = Console.ReadLine();
            Console.Write("Senha : ");
            string senha = Console.ReadLine();
            Console.Write("Tipo de Pessoa ([F]isica ou [J]uridica) : ");
            string tipopessoa = Console.ReadLine();
            
            AnuncianteDTO pessoa = new AnuncianteDTO();
            pessoa.Telefones = new List<TelefoneDTO>();
            pessoa.Enderecos = new List<EnderecoDTO>();
            
            pessoa.Nome = nome;
            pessoa.Inscricao = Convert.ToInt64(inscricao);
            pessoa.Senha = senha;
            pessoa.Email = email;
            
            if (tipopessoa.Equals("f") || tipopessoa.Equals("F"))
            {
                pessoa.Tipo = EnumTipoPessoa.Fisica;
            
            } 
            else 
            {
                pessoa.Tipo = EnumTipoPessoa.Juridica;
            
            }


            List<EnderecoDTO> enderecos = IncluirEndereco();

            pessoa.Enderecos.AddRange(enderecos);
            
            
            List<TelefoneDTO> telefones = IncluirTelefone();
            
            pessoa.Telefones.AddRange(telefones);


            using (var service = new JuntosServiceClient())
            {
                service.SalvarAnunciante(pessoa);
            }
            
            
          
           
        }


        private static void IncluirConsumidor()
        {
            Console.Write("Nome : ");
            string nome = Console.ReadLine();
            Console.Write("Inscricao : ");
            string inscricao = Console.ReadLine();
            Console.Write("email : ");
            string email = Console.ReadLine();
            Console.Write("Senha : ");
            string senha = Console.ReadLine();
            Console.Write("Tipo de Pessoa ([F]isica ou [J]uridica) : ");
            string tipopessoa = Console.ReadLine();

            ConsumidorDTO pessoa = new ConsumidorDTO();
            pessoa.Telefones = new List<TelefoneDTO>();
            pessoa.Enderecos = new List<EnderecoDTO>();

            pessoa.Nome = nome;
            pessoa.Inscricao = Convert.ToInt64(inscricao);
            pessoa.Senha = senha;
            pessoa.Email = email;

            if (tipopessoa.Equals("f") || tipopessoa.Equals("F"))
            {
                pessoa.Tipo = EnumTipoPessoa.Fisica;

            }
            else
            {
                pessoa.Tipo = EnumTipoPessoa.Juridica;

            }


            List<EnderecoDTO> enderecos = IncluirEndereco();

            pessoa.Enderecos.AddRange(enderecos);


            List<TelefoneDTO> telefones = IncluirTelefone();

            pessoa.Telefones.AddRange(telefones);


            using (var service = new JuntosServiceClient())
            {
                service.SalvarConsumidor(pessoa);
            }


  

        }



        private static void ListarTodosAnunciantes()
        {
            List<AnuncianteDTO> pessoas = new List<AnuncianteDTO>();

            using (var service = new JuntosServiceClient())
            {
                pessoas = service.RetornarTodosAnunciantes();

                if (pessoas.Count > 0) 
                {
                    
                    pessoas.ForEach(p => {
                    
                        Console.WriteLine(p.Id + " / " + p.Nome);
                        

                    });
                    Console.WriteLine("Digite Tecle Algo para voltar ao menu");
                    Console.ReadLine();
                
                 } else {
                        Console.WriteLine("Não Existem Anunciantes Cadastrados");
                        Console.WriteLine("Digite Tecle Algo para voltar ao menu");
                        Console.ReadLine();
                }


            }
                  
      
            
        }

        private static void ListarTodosConsumidores()
        {
            List<ConsumidorDTO> pessoas = new List<ConsumidorDTO>();

            using (var service = new JuntosServiceClient())
            {
                pessoas = service.RetornarTodosConsumidores();
            }

                if (pessoas.Count > 0)
                {

                    pessoas.ForEach(p =>
                    {

                        Console.WriteLine(p.Id + " / " + p.Nome);
                    });

                    Console.WriteLine("Digite Tecle Algo para voltar ao menu");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Não Existem Consumidores Cadastrados");
                    Console.WriteLine("Digite Tecle Algo para voltar ao menu");
                    Console.ReadLine();


                }

           
        }

        private static void ListarAnunciantePorId()
        {
            AnuncianteDTO pessoa = null;

            Console.Write("id : ");
            string id = Console.ReadLine();

            using (var service = new JuntosServiceClient())
            {
                pessoa = service.ConsultarAnunciantePeloId(Convert.ToInt32(id));
            }

            if (pessoa!=null) {
                 Console.WriteLine(pessoa.Id + " / " + pessoa.Nome);
                 Console.WriteLine("Digite Tecle Algo para voltar ao menu");
                 Console.ReadLine();
            } else {
                Console.WriteLine("Não Existe Consumidor com id " + id);
            
            }

        }

        private static void ListarConsumidorPorId()
        {
            ConsumidorDTO pessoa = null;
            
            Console.Write("id : ");
            string id = Console.ReadLine();

            using (var service = new JuntosServiceClient())
            {
                pessoa = service.ConsultarConsumidorPeloId(Convert.ToInt32(id));
            }

             if (pessoa!=null) {
                 Console.WriteLine(pessoa.Id + " / " + pessoa.Nome);
                 Console.WriteLine("Digite Tecle Algo para voltar ao menu");
                 Console.ReadLine();
            } else {
                Console.WriteLine("Não Existe Consumidor com id " + id);
                Console.WriteLine("Digite Tecle Algo para voltar ao menu");
                Console.ReadLine();
            
            }


            
        }

        private static List<EnderecoDTO> IncluirEndereco()
        {
            List<EnderecoDTO> enderecos = new List<EnderecoDTO>();
            
            while (true)
            {
                EnderecoDTO endereco = new EnderecoDTO();
                
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
                Console.Write("outro (s/n) : ");
                string flag = Console.ReadLine();

                endereco.Logradouro = logradouro;
                endereco.Complemento = complemento;
                endereco.Numero = Convert.ToInt32(numero);
                endereco.Bairro = bairro;
                endereco.Cidade = cidade;
                endereco.Estado = estado;
                endereco.Cidade = cidade;
                endereco.Estado = estado;
                endereco.Cep = cep;
                endereco.Pais = pais;

                enderecos.Add(endereco);
                
                
                if (flag.Equals("n") || flag.Equals("N"))
                {
                    break;
                }
            }

            return enderecos;
        }

        private static List<TelefoneDTO> IncluirTelefone()
        {

            List<TelefoneDTO> telefones = new List<TelefoneDTO>();

            while (true)
            {

                TelefoneDTO telefone = new TelefoneDTO();

                Console.Write("Numero : ");
                string numero = Console.ReadLine();

                Console.Write("DDD : ");
                string ddd = Console.ReadLine();

                Console.Write("DDI : ");
                string ddi = Console.ReadLine();

                telefone.Numero = Convert.ToInt32(numero);
                telefone.DDD = Convert.ToInt16(ddd);
                telefone.DDI = Convert.ToInt16(ddi);

                telefones.Add(telefone);

                Console.Write("outro (s/n) : ");
                string flag = Console.ReadLine();
                
                if (flag.Equals("n") || flag.Equals("N"))
                {
                    break;
                }
            }



            return telefones;



        }


    }
}
