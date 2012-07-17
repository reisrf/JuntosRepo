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
            IAnuncianteService anuncianteService = typeof (IAnuncianteService).Fabricar();
            var anunciante = new Anunciante("Alterdata", 1111111111, "aaa@aaa.com.br");
            anunciante.Enderecos.Add(new Endereco() { Bairro="Tijuca", Cidade="Teresópolis", Estado="RJ", Id=Guid.NewGuid(), Logradouro="Rua Sebastião Teixeira", Numero=323, Pais="Brasil" });
            anunciante.Telefones.Add(new Telefone(55, 21, 2721221));
            anuncianteService.Adicionar(anunciante);
        }
    }
}