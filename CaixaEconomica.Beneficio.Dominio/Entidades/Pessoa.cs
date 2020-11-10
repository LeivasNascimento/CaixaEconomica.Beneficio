using CaixaEconomica.Beneficio.Dominio.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CaixaEconomica.Beneficio.Dominio.Entidades
{
    public class Pessoa : Entidade
    {
        public int Id { get; set; }
        public int Idade { get; set; }
        public int QuantidadeFilhos { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        /*
         * 02 Empregado
         * 11 Profissional Liberal
         * */
        public int CodigoOcupacao { get; set; }

        private readonly HashSet<BeneficioPessoa> _beneficioPessoas = new HashSet<BeneficioPessoa>();
        public IEnumerable<BeneficioPessoa> beneficiosPessoas => _beneficioPessoas.ToList().AsReadOnly();

        public Pessoa()
        {
            //  Enderecos = new List<Endereco>();
            SetNotificacao(new NotificacaoDominio());
        }

        //Relacionamento de 1(Pessoa) para Muitos(Endereço)
        // Backing Field - n acessar a lista Enderecos diretamente
        // tem uma boa peformance; evita ter elementos duplicados

        private readonly HashSet<Endereco> _enderecos = new HashSet<Endereco>();
        public IEnumerable<Endereco> Enderecos => _enderecos.ToList().AsReadOnly(); //esses itens n poderão ser alterados de fora da classe

        public void AdicionarEndereco(Endereco endereco)
        {
            if (endereco == null)
            {
                NotificacaoDominio.AddErro("Erro: endereço deve ser instanciado");
            }
            else
            {
                //vai ficar assim enquanto o projeto n tiver a injeção de dependência 
                endereco.SetNotificacao(new NotificacaoDominio());

                //n é para tratar os erros de endereço (singular) em Pessoa. é de interesse de Pessoa somente os endereços (plural)
                endereco.Validar();
                if(endereco.Valido())
                {
                    _enderecos.Add(endereco);
                }else
                {
                    NotificacaoDominio.AddErro("Erro: Endereço não é válido");
                }
           

            }
        }

        public bool Equals(Pessoa other)
        {
            return Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        //public virtual ICollection<Endereco> Enderecos { get; set; }



    }
}
