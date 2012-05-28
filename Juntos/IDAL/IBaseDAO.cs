namespace Juntos.IDAL
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface base para uma classe de acesso a dados.
    /// </summary>
    public interface IBaseDAO<TEntidade>
    {
        /// <summary>
        /// Consulta uma lista de entidades persistidas de acordo com a expressão LINQ.
        /// </summary>
        /// <param name="consulta">Expressão LINQ.</param>
        /// <returns>Retorna uma lista de entidades.</returns>
        IEnumerable<TEntidade> Consultar(IEnumerable<TEntidade> consulta);

        /// <summary>
        /// Persiste uma lista de entidades.
        /// </summary>
        /// <param name="entidades">Entidades a serem persistidas.</param>
        void Salvar(IEnumerable<TEntidade> entidades);
    }
}
