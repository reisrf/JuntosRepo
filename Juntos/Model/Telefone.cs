namespace Juntos.Model
{
    public class Telefone : Entidade
    {
        public Telefone() { }
        public Telefone(Pessoa pessoa) { pessoa.IncluirTelefone(this); }


        public Telefone(short ddi, short ddd, int numero)
        {
            this.DDI = ddi;
            this.DDD = ddd;
            this.Numero = numero;
        }

        public int Numero { get; set; }

        public short DDD { get; set; }

        public short DDI { get; set; }
    }
}