using System;

namespace CaixaEconomica.Beneficio.Dominio.Entidades
{
    public class Endereco : Entidade, IEquatable<Endereco>
    {
        public int Id { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        /*
         TipoEnderecoId
         1 = residencial
         2 = Trabalho
         */
        public int TipoEnderecoId { get; set; }

        public int PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }

        public bool Equals(Endereco other)
        {
            return Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        internal void Validar()
        {
            if (Rua == null || Numero == 0 && TipoEnderecoId == 0 && PessoaId == 0)
            {
                NotificacaoDominio.AddErro("existem campos nulos do endereço informado. favor revise-os!");
            }
        }
    }
}
