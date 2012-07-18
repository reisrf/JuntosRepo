using System;

namespace Juntos.Model
{
    public abstract class Entidade
    {

        public Guid Id { get; set; }

        protected Entidade()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
