namespace Juntos.IModel.Pessoa
{
    using Enumerador;
    using System.Collections.Generic;

    /// <summary>
    /// Interface para classe de pessoa.
    /// </summary>
    public interface IPessoa
    {
        /// <summary>
        /// Retorna ou atribui um nome a pessoa.
        /// </summary>
        string Nome { get; set; }

        /// <summary>
        /// Retorna ou atribui um cpf ou cnpj a pessoa.
        /// </summary>
        long CpfCnpj { get; set; }

        /// <summary>
        /// Retorna todos os endereços cadastrados para pessoa.
        /// </summary>
        IEnumerable<IEndereco> Enderecos { get; }

        /// <summary>
        /// Retorna todos os contatos cadastrados para pessoa.
        /// </summary>
        IEnumerable<IContato> Contatos { get; }

        /// <summary>
        /// Cria e retorna uma nova instância de endereço.
        /// </summary>
        /// <returns>Retorna uma instância de endereço.</returns>
        IEndereco NovoEndereco();

        /// <summary>
        /// Valida e adiciona um endereço a pessoa.
        /// </summary>
        /// <param name="endereco">Objeto de endereço a ser vinculado a pessoa.</param>
        void AdicionarEndereco(IEndereco endereco);

        /// <summary>
        /// Cria e retorna uma nova instância de contato.
        /// </summary>
        /// <param name="tipoContato">Tipo de contato.</param>
        /// <returns>Retorna uma instância de contato.</returns>
        IContato NovoContato(EnumTipoContato tipoContato);

        /// <summary>
        /// valida e adiciona um contato a pessoa.
        /// </summary>
        /// <param name="contato">Objeto de contato a ser vinculado a pessoa.</param>
        void AdicionarContato(IContato contato);
    }
}
