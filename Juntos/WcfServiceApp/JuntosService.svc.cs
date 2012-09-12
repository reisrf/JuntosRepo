using Juntos.WcfServiceApp.PagamentoServices;

namespace Juntos.WcfServiceApp
{
    using System;
    using System.Collections.Generic;
    using Framework;
    using IService;
    using Model;
    using Model.Enums;
    using Juntos.Apresentacao.WcfServiceApp.dto;
    using Juntos.WcfServiceApp.wsProxy;

    public class JuntosService : IJuntosService
    {
        public List<ConsumidorDTO> RetornarTodosConsumidores()
        {
            IConsumidorService consumidorService = typeof (IConsumidorService).Fabricar();
            List<Consumidor> consumidores = consumidorService.RetornarTodos();
            List<ConsumidorDTO> result = new List<ConsumidorDTO>();

            consumidores.ForEach(c => {

                result.Add(ConsumidorToDTO(c));
          
            });

            return result;
        }

        public ConsumidorDTO ConsultarConsumidorPeloId(long id)
        {
            IConsumidorService consumidorService = typeof(IConsumidorService).Fabricar();
            Consumidor consumidor = consumidorService.BuscarPorId(id);
            ConsumidorDTO result = ConsumidorToDTO(consumidor);
            return result;

        }

        public void SalvarConsumidor(ConsumidorDTO consumidor)
        {
            IConsumidorService consumidorService = typeof(IConsumidorService).Fabricar();
            consumidorService.Salvar(DTOtoConsumidor(consumidor));
        }

        public List<AnuncianteDTO> RetornarTodosAnunciantes()
        {
            IAnuncianteService anuncianteService = typeof (IAnuncianteService).Fabricar();
            List<Anunciante> anunciantes = anuncianteService.RetornarTodos();
            List<AnuncianteDTO> result = new List<AnuncianteDTO>();

            anunciantes.ForEach(a =>
            {

                result.Add(AnuncianteToDTO(a));

            });

            return result;


        }

        public AnuncianteDTO ConsultarAnunciantePeloId(long id)
        {
            IAnuncianteService anuncianteService = typeof(IAnuncianteService).Fabricar();
            Anunciante anunciante = anuncianteService.BuscarPorId(id);
            AnuncianteDTO result = AnuncianteToDTO(anunciante);
            return result;

        }

        public AnuncianteDTO ConsultarAnunciantePeloEmail(string email)
        {
            IAnuncianteService anuncianteService = typeof(IAnuncianteService).Fabricar();

            Anunciante anunciante = anuncianteService.ConsultarPeloEmail(email); 
            AnuncianteDTO result = AnuncianteToDTO(anunciante);
            return result;
            
        
        }

        public void SalvarAnunciante(AnuncianteDTO anunciante)
        {
            IAnuncianteService anuncianteService = typeof (IAnuncianteService).Fabricar();
            anuncianteService.Salvar(DTOtoAnunciante(anunciante));
        }

        public List<OfertaDTO> RetornarTodasOfertasPorAnunciante(long anuncianteid)
        {
            IAnuncianteService anuncianteService = typeof(IAnuncianteService).Fabricar();
            Anunciante anunciante = anuncianteService.BuscarPorId(anuncianteid);

            List<Oferta> ofertas = anunciante.Ofertas;
            List<OfertaDTO> result = new List<OfertaDTO>();

            

            ofertas.ForEach(o => {
                result.Add(OfertaToDTO(o));           
            });

            return result;
        }


        public List<OfertaDTO> RetornarTodasOfertas()
        {
           IOfertaService ofertaService = typeof (IOfertaService).Fabricar();

           List <Oferta> ofertas = ofertaService.RetornarTodos();

           List<OfertaDTO> result = new List<OfertaDTO>();

           ofertas.ForEach(o =>
           {
               result.Add(OfertaToDTO(o));


           });

           return result;

           
        }

        public OfertaDTO ConsultarOfertaPeloId(long id)
        {
            IOfertaService ofertaService = typeof (IOfertaService).Fabricar();
            Oferta oferta = ofertaService.BuscarPorId(id);

            return OfertaToDTO(oferta);

        }

        public void SalvarOferta(OfertaDTO oferta, long idAnunciante)
        {
            IAnuncianteService anuncianteService = typeof(IAnuncianteService).Fabricar();
            Anunciante anunciante = anuncianteService.BuscarPorId(idAnunciante);

            if (anunciante.Ofertas == null)
            {
                anunciante.Ofertas = new List<Oferta>();
            }

            anunciante.IncluirOferta(DTOtoOferta(oferta));
            anuncianteService.Salvar(anunciante);
        }

        public List<CompraDTO> RetornarTodasComprasPorConsumidor(long consumidorid)
        {
            IConsumidorService consumidorService = typeof(IConsumidorService).Fabricar();
            Consumidor consumidor = consumidorService.BuscarPorId(consumidorid);
            List<CompraDTO> result = new List<CompraDTO>();

            consumidor.Compras.ForEach(c => {

                result.Add(CompraToDTO(c));
            
            });

            return result;
        }

        public List<CompraDTO> RetornarTodasCompras()
        {
            ICompraService compraService = typeof (ICompraService).Fabricar();
            List<Compra> compras = compraService.RetornarTodos();

            List<CompraDTO> result = new List<CompraDTO>();

            compras.ForEach(c =>
            {

                result.Add(CompraToDTO(c));

            });

            return result;
        }


        public CompraDTO ConsultarCompraPeloId(long id)
        {
            ICompraService compraService = typeof(ICompraService).Fabricar();
            Compra compra = compraService.BuscarPorId(id);

            return CompraToDTO(compra);
        }

        public void SalvarCompra(CompraDTO compra)
        {
            ICompraService compraService = typeof(ICompraService).Fabricar();
            compraService.Salvar(DTOtoCompra(compra));
        }

        public CompraDTO ComprarOferta(long idConsumidor, long idOferta, int quantidadeCupons)
        {
            IConsumidorService consumidorService = typeof(IConsumidorService).Fabricar();
            IOfertaService ofertaService = typeof (IOfertaService).Fabricar();
            ICompraService compraService = typeof(ICompraService).Fabricar();

            var consumidor = consumidorService.BuscarPorId(idConsumidor);
            var oferta = ofertaService.BuscarPorId(idOferta);
            Compra compra = compraService.ComprarOferta(consumidor, oferta, quantidadeCupons);

            return CompraToDTO(compra);
        }

        public void PagarCompra(long idCompra, EnumFormaPagamento formaPagamento)
        {
            if (formaPagamento == EnumFormaPagamento.NaoDefinida)
            {
                throw new Exception("Forma de pagamento não definida.");
            }

            ICompraService compraService = typeof (ICompraService).Fabricar();
            var compra = compraService.BuscarPorId(idCompra);

            if (formaPagamento == EnumFormaPagamento.PayPal)
            {
                using (var pagamentoServiceClient = new PagamentoServiceClient())
                {
                    pagamentoServiceClient.Open();
                    if (pagamentoServiceClient.Pagar(compra.ValorTotal))
                    {
                        compraService.PagarCompra(compra, formaPagamento);
                    }
                }
            }
            else
            {

                using (var client = new ControladorPagamentoServiceClient())
                {
                    client.Open();

                    Juntos.WcfServiceApp.wsProxy.Pagamento pagto = new Juntos.WcfServiceApp.wsProxy.Pagamento();
                    pagto.Codigo = idCompra;
                    pagto.DataPagamento = DateTime.Now;
                    pagto.FormaPagamento = FormaPagamento.PagSeguro;
                    pagto.Valor = compra.ValorTotal;

                    client.PaymentRequest(pagto);

                    pagto = client.GetPaymentResult(pagto.Codigo);

                    if (pagto.Status==StatusPagamento.Aprovado) 
                    {
                        compraService.PagarCompra(compra, formaPagamento);
                    }
               
               }
            }
        }


        public void InformarUsoCupom(long idCupom) 
        {

            IOfertaService ofertaService = typeof(IOfertaService).Fabricar();


            ofertaService.UtilizarCupom(idCupom);
            
        
        }


        public void PublicarOferta(long idOferta) {
            IOfertaService ofertaService = typeof(IOfertaService).Fabricar();

            ofertaService.Publicar(idOferta);
        
        
        }


        public List<CupomDTO> ListarCuponsNaoUtilizados(long ofertaid) {
            IOfertaService ofertaService = typeof(IOfertaService).Fabricar();
            
            Oferta oferta = ofertaService.BuscarPorId(ofertaid);
            List<CupomDTO> result = new List<CupomDTO>();

            oferta.CuponsGerados.ForEach(c => {

                if (!c.IsUtilizado())
                {
                    result.Add(CupomToDTO(c));
                }
            
            });

            return result; 

        }



        public List<CupomDTO> ConsolidarOferta(long ofertaid)
        {
            IOfertaService ofertaService = typeof(IOfertaService).Fabricar();

            Oferta oferta = ofertaService.BuscarPorId(ofertaid);
            List<CupomDTO> result = new List<CupomDTO>();

            oferta.CuponsGerados.ForEach(c =>
            {

                if (c.IsUtilizado())
                {
                    result.Add(CupomToDTO(c));
                }

            });

            return result; 
        }

        private ConsumidorDTO ConsumidorToDTO(Consumidor c)
        {
            if (c == null)
            {
                return null;
            }


            ConsumidorDTO consumidor = new ConsumidorDTO();

            consumidor.Id = c.Id;
            consumidor.Nome = c.Nome;
            consumidor.Tipo = c.Tipo;
            consumidor.CpfCnpj = c.CpfCnpj;
            consumidor.Email = c.Email;
            consumidor.Telefones = new List<TelefoneDTO>();
            consumidor.Enderecos = new List<EnderecoDTO>();

            if (c.Telefones != null && c.Telefones.Count != 0)
            {
                c.Telefones.ForEach(t =>
                {
                    TelefoneDTO telefone = new TelefoneDTO();
                    telefone.DDD = t.DDD;
                    telefone.DDI = t.DDI;
                    telefone.Id = t.Id;
                    telefone.Numero = t.Numero;
                    consumidor.Telefones.Add(telefone);
                });
            }


            if (c.Enderecos != null && c.Enderecos.Count != 0)
            {
                c.Enderecos.ForEach(e =>
                {
                    EnderecoDTO endereco = new EnderecoDTO();
                    endereco.Bairro = e.Bairro;
                    endereco.Cep = e.Cep;
                    endereco.Cidade = e.Cidade;
                    endereco.Complemento = e.Complemento;
                    endereco.Estado = e.Estado;
                    endereco.Id = e.Id;
                    endereco.Logradouro = e.Logradouro;
                    endereco.Numero = e.Numero;
                    endereco.Pais = e.Pais;
                    consumidor.Enderecos.Add(endereco);
                });
            }
            return consumidor;




        }

        private Consumidor DTOtoConsumidor(ConsumidorDTO c)
        {

            if (c == null)
            {
                return null;
            }
            
            Consumidor consumidor = new Consumidor();

            consumidor.Id = c.Id;
            consumidor.Nome = c.Nome;
            consumidor.Tipo = c.Tipo;
            consumidor.CpfCnpj = c.CpfCnpj;
            consumidor.Email = c.Email;
  
            if (c.Telefones != null && c.Telefones.Count != 0)
            {
                c.Telefones.ForEach(t =>
                {
                    Telefone telefone = new Telefone();
                    telefone.DDD = t.DDD;
                    telefone.DDI = t.DDI;
                    telefone.Id = t.Id;
                    telefone.Numero = t.Numero;
                    consumidor.Telefones.Add(telefone);
                   });
            }
            if (c.Enderecos != null && c.Enderecos.Count != 0)
            {
                c.Enderecos.ForEach(e =>
                {
                    Endereco endereco = new Endereco();
                    endereco.Bairro = e.Bairro;
                    endereco.Cep = e.Cep;
                    endereco.Cidade = e.Cidade;
                    endereco.Complemento = e.Complemento;
                    endereco.Estado = e.Estado;
                    endereco.Id = e.Id;
                    endereco.Logradouro = e.Logradouro;
                    endereco.Numero = e.Numero;
                    endereco.Pais = e.Pais;
                    consumidor.Enderecos.Add(endereco);
                });
            }
            return consumidor;

        }

        private AnuncianteDTO AnuncianteToDTO(Anunciante a)
        {

            if (a == null)
            {
                return null;
            }
            
            AnuncianteDTO anunciante = new AnuncianteDTO();

            anunciante.Id = a.Id;
            anunciante.Nome = a.Nome;
            anunciante.Tipo = a.Tipo;
            anunciante.CpfCnpj = a.CpfCnpj;
            anunciante.Email = a.Email;
            anunciante.Telefones = new List<TelefoneDTO>();
            anunciante.Enderecos = new List<EnderecoDTO>();

            if (a.Telefones != null && a.Telefones.Count != 0)
            {
                a.Telefones.ForEach(t =>
                {
                    TelefoneDTO telefone = new TelefoneDTO();
                    telefone.DDD = t.DDD;
                    telefone.DDI = t.DDI;
                    telefone.Id = t.Id;
                    telefone.Numero = t.Numero;

                    anunciante.Telefones.Add(telefone);


                });
            }

            if (a.Enderecos != null && a.Enderecos.Count != 0)
            {
                a.Enderecos.ForEach(e =>
                {
                    EnderecoDTO endereco = new EnderecoDTO();
                    endereco.Bairro = e.Bairro;
                    endereco.Cep = e.Cep;
                    endereco.Cidade = e.Cidade;
                    endereco.Complemento = e.Complemento;
                    endereco.Estado = e.Estado;
                    endereco.Id = e.Id;
                    endereco.Logradouro = e.Logradouro;
                    endereco.Numero = e.Numero;
                    endereco.Pais = e.Pais;

                    anunciante.Enderecos.Add(endereco);
                });
            }
            return anunciante;
        }

        private Anunciante DTOtoAnunciante(AnuncianteDTO a)
        {
            if (a == null)
            {
                return null;
            }

            Anunciante anunciante = new Anunciante();

            anunciante.Id = a.Id;
            anunciante.Nome = a.Nome;
            anunciante.Tipo = a.Tipo;
            anunciante.CpfCnpj = a.CpfCnpj;
            anunciante.Email = a.Email;
  
            a.Telefones.ForEach(t =>
            {
                Telefone telefone = new Telefone();
                telefone.DDD = t.DDD;
                telefone.DDI = t.DDI;
                telefone.Id = t.Id;
                telefone.Numero = t.Numero;
                anunciante.IncluirTelefone(telefone);
            });

            a.Enderecos.ForEach(e =>
            {
                Endereco endereco = new Endereco();
                endereco.Bairro = e.Bairro;
                endereco.Cep = e.Cep;
                endereco.Cidade = e.Cidade;
                endereco.Complemento = e.Complemento;
                endereco.Estado = e.Estado;
                endereco.Id = e.Id;
                endereco.Logradouro = e.Logradouro;
                endereco.Numero = e.Numero;
                endereco.Pais = e.Pais;
                anunciante.IncluirEndereco(endereco);
            });

            return anunciante;
        }

        private OfertaDTO OfertaToDTO(Oferta o)
        {
            if (o == null)
            {
                return null;
            }

            OfertaDTO oferta = new OfertaDTO();

            //oferta.Anunciante = AnuncianteToDTO(o.Anunciante);
            oferta.Condicoes = o.Condicoes;
            oferta.DataExpiracao = o.DataExpiracao;
            oferta.DataInicioValidade = o.DataInicioValidade;
            oferta.DataPublicacao = o.DataPublicacao;
            oferta.DataValidadeCupons = o.DataValidadeCupons;
            oferta.Descricao = o.Descricao;
            oferta.Id = o.Id;
            oferta.NumeroMaximoCupons = o.NumeroMaximoCupons;
            oferta.Status = o.Status;
            oferta.ValorCupons = o.ValorCupons;
            oferta.CuponsGerados = new List<CupomDTO>();

            EnderecoDTO endereco = new EnderecoDTO();
            endereco.Bairro = o.Endereco.Bairro;
            endereco.Cep = o.Endereco.Cep;
            endereco.Cidade = o.Endereco.Cidade;
            endereco.Complemento = o.Endereco.Complemento;
            endereco.Estado = o.Endereco.Estado;
            endereco.Id = o.Endereco.Id;
            endereco.Logradouro = o.Endereco.Logradouro;
            endereco.Numero = o.Endereco.Numero;
            endereco.Pais = o.Endereco.Pais;
            
            oferta.Endereco = endereco;

            if (o.CuponsGerados != null && o.CuponsGerados.Count != 0)
            {

                o.CuponsGerados.ForEach(c =>
                {
                    CupomDTO cupom = new CupomDTO();

                    cupom = CupomToDTO(c);

                    oferta.CuponsGerados.Add(cupom);
                });
            }

            return oferta;
        }

        private Oferta DTOtoOferta(OfertaDTO o)
        {
            if (o == null)
            {
                return null;
            }

            Oferta oferta = new Oferta();
            //oferta.Anunciante = DTOtoAnunciante(o.Anunciante);
            oferta.Condicoes = o.Condicoes;
            oferta.DataExpiracao = o.DataExpiracao;
            oferta.DataInicioValidade = o.DataInicioValidade;
            oferta.DataPublicacao = o.DataPublicacao;
            oferta.DataValidadeCupons = o.DataValidadeCupons;
            oferta.Descricao = o.Descricao;
            oferta.Id = o.Id;
            oferta.NumeroMaximoCupons = o.NumeroMaximoCupons;
            oferta.Status = o.Status;
            oferta.ValorCupons = o.ValorCupons;
            oferta.CuponsGerados = new List<Cupom>();

            Endereco endereco = new Endereco();
            endereco.Bairro = o.Endereco.Bairro;
            endereco.Cep = o.Endereco.Cep;
            endereco.Cidade = o.Endereco.Cidade;
            endereco.Complemento = o.Endereco.Complemento;
            endereco.Estado = o.Endereco.Estado;
            endereco.Id = o.Endereco.Id;
            endereco.Logradouro = o.Endereco.Logradouro;
            endereco.Numero = o.Endereco.Numero;
            endereco.Pais = o.Endereco.Pais;

            oferta.Endereco = endereco;

           
            if (o.CuponsGerados != null && o.CuponsGerados.Count != 0)
            {
                o.CuponsGerados.ForEach(c =>
                {
                    Cupom cupom = DTOtoCupom(c);

                    oferta.CuponsGerados.Add(cupom);


                });
            }
            return oferta;
        }


        private CupomDTO CupomToDTO(Cupom c)
        {
            if (c == null)
            {
                return null;
            }

            CupomDTO cupom = new CupomDTO();

            cupom.DataUtilizacao = c.DataUtilizacao;
            cupom.DataValidade = c.DataValidade;
            cupom.Id = c.Id;
            //cupom.Oferta = OfertaToDTO(c.Oferta);
            cupom.Valor = cupom.Valor;


            return cupom;
        }

        private Cupom DTOtoCupom(CupomDTO c)
        {
            Cupom cupom = new Cupom();

            cupom.DataUtilizacao = c.DataUtilizacao;
            cupom.DataValidade = c.DataValidade;
            cupom.Id = c.Id;
            //cupom.Oferta = DTOtoOferta(c.Oferta);
            cupom.Valor = cupom.Valor;


            return cupom;
        }

        private CompraDTO CompraToDTO(Compra c)
        {

            if (c == null)
            {
                return null;
            }
            
            CompraDTO compra = new CompraDTO();

            //compra.Consumidor = ConsumidorToDTO(c.Consumidor);
            compra.DataCompra = c.DataCompra;
            compra.Id = c.Id;
            compra.ValorTotal = c.ValorTotal;
            compra.Cupons = new List<CupomDTO>();
            compra.Pagamentos = new List<PagamentoDTO>();

            if (c.Cupons != null && c.Cupons.Count != 0)
            {
                c.Cupons.ForEach(cp =>
                {
                    compra.Cupons.Add(CupomToDTO(cp));
                });
            }

            if (c.Pagamentos != null && c.Pagamentos.Count != 0)
            {
                c.Pagamentos.ForEach(p =>
                {
                    compra.Pagamentos.Add(PagamentoToDTO(p));

                });
            }
            return compra;
        }

        private Compra DTOtoCompra(CompraDTO c)
        {

            if (c == null)
            {
                return null;
            }
            
            Compra compra = new Compra();


            //compra.Consumidor = DTOtoConsumidor(c.Consumidor);
            compra.DataCompra = c.DataCompra;
            compra.Id = c.Id;
            compra.ValorTotal = c.ValorTotal;
            compra.Cupons = new List<Cupom>();
            compra.Pagamentos = new List<Model.Pagamento>();

            if (c.Cupons != null && c.Cupons.Count != 0)
            {
                c.Cupons.ForEach(cp =>
                {
                    compra.Cupons.Add(DTOtoCupom(cp));
                });
            }

            if (c.Pagamentos != null && c.Pagamentos.Count != 0)
            {
                c.Pagamentos.ForEach(p =>
                {
                    compra.Pagamentos.Add(DTOtoPagamento(p));

                });
            }
            return compra;
        }


        private PagamentoDTO PagamentoToDTO(Juntos.Model.Pagamento p)
        {

            if (p == null)
            {
                return null;
            }

            PagamentoDTO pagamento = new PagamentoDTO();

            pagamento.Codigo = p.Codigo;
            pagamento.DataPagamento = p.DataPagamento;
            pagamento.FormaPagamento = p.FormaPagamento;
            pagamento.Id = p.Id;
            pagamento.Status = p.Status;
            pagamento.Valor = p.Valor;


            return pagamento;
        }

        private Juntos.Model.Pagamento DTOtoPagamento(PagamentoDTO p)
        {
            if (p == null)
            {
                return null;
            }

            Juntos.Model.Pagamento pagamento = new Juntos.Model.Pagamento();

            pagamento.Codigo = p.Codigo;
            pagamento.DataPagamento = p.DataPagamento;
            pagamento.FormaPagamento = p.FormaPagamento;
            pagamento.Id = p.Id;
            pagamento.Status = p.Status;
            pagamento.Valor = p.Valor;


            return pagamento;
        }

    }
}
