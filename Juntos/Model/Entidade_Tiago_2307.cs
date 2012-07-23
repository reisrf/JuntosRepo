using System;

namespace Juntos.Model
{
    public abstract class Entidade
    {

        public long Id { get; set; }

        protected Entidade()
        {
            this.Id = 0;
        }

        public bool IsEntity()
        {
            return true;
        }
    }
}
