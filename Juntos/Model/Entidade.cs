using System;

namespace Juntos.Model
{
    public abstract class Entidade
    {
        protected Entidade()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}
