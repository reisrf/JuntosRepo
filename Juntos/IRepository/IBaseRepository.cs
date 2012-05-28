namespace Juntos.IRepository
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Interface para um repositório base.
    /// 
    /// Repositório deverá ser implementado utilizando o padrão Object Pool e SyncRoot para controle de acessos simultâneos.
    /// Também deverá ser utilizado singleton para uma melhor performance e controle de memória. 
    /// </summary>
    public interface IBaseRepository<TEntidade>
    {
        /// <summary>
        /// Cria e retorna uma nova instância da entidade.
        /// </summary>
        /// <returns>Retorna uma nova instância da entidade.</returns>
        TEntidade Novo();

        /// <summary>
        /// Solicita ao repositório algumas entidades de acordo com o filtro fornecido através da expressão LINQ.
        /// </summary>
        /// <param name="consulta">Expressão LINQ.</param>
        /// <returns>Retorna uma lista de entidades.</returns>
        IEnumerable<TEntidade> Solcitar(Func<TEntidade, bool> consulta);

        /// <summary>
        /// Solicita ao repositório todas as entidades existentes.
        /// 
        /// De acordo com o parâmetro fornecido, a camada de persistência não será utilizada.
        /// 
        /// Esses itens serão removidos do repositório para prevenir problemas de concorrência.
        /// </summary>
        /// <param name="somenteEmMemoria">Informa ao repositório que somente os itens carregados em memória devem ser retornados.</param>
        /// <returns>Retorna uma lista de entidades.</returns>
        IEnumerable<TEntidade> SolicitarTodos(bool somenteEmMemoria);

        /// <summary>
        /// Devolve ao repositório uma entidade solicitada.
        /// </summary>
        /// <param name="entidade">Entidade a ser devolvida.</param>
        void Devolver(TEntidade entidade);

        /// <summary>
        /// Devolve ao repositório uma lista de entidades solicitadas.
        /// </summary>
        /// <param name="entidades">Lista de entidades a serem devolvidas.</param>
        void Devolver(IEnumerable<TEntidade> entidades);

        /// <summary>
        /// Deleta uma entidade persistida.
        /// </summary>
        /// <param name="entidade">Entidade a ser deletada.</param>
        void Remover(TEntidade entidade);
        
        /// <summary>
        /// Deleta uma lista de entidades persistidas.
        /// </summary>
        /// <param name="entidades">Lista de entidades a serem deletadas.</param>
        void Remover(IEnumerable<TEntidade> entidades);

        /// <summary>
        /// Persiste as mudanças das entidades.
        /// </summary>
        /// <param name="entidades">Entidades a serem persistidas.</param>
        void Save(IEnumerable<TEntidade> entidades);
    }
}
