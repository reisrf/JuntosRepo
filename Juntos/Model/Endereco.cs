namespace Juntos.Model
{
    public class Endereco : Entidade
    {
        public Endereco() { }
        
        public Endereco(Pessoa pessoa) { pessoa.Enderecos.Add(this); }

        public string Logradouro { get; set; }

        public int Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string Pais { get; set; }
        public string Cep { get; set; }

        public override string ToString()
        {
            return string.Format(@"{0}, {1} - {2}, {3} - {4} - {5} - {6} - {7}",
                this.Logradouro,
                this.Numero,
                this.Complemento,
                this.Bairro,
                this.Cidade,
                this.Estado,
                this.Pais,
                this.Cep);
        }
    }
}