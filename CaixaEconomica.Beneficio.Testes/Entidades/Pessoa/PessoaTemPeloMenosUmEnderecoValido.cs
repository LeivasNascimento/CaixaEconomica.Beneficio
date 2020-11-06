using Microsoft.VisualStudio.TestTools.UnitTesting;
using CaixaEconomica.Beneficio.Dominio.Entidades;
using System.Linq;

namespace CaixaEconomica.Beneficio.Testes.Entidades.Pessoa
{
    [TestClass]
    public class PessoaTemPeloMenosUmEnderecoValido
    {
        private CaixaEconomica.Beneficio.Dominio.Entidades.Pessoa pessoa;
        private Endereco endereco;

        [TestInitialize]
        public void Init()
        {
            pessoa = new Dominio.Entidades.Pessoa();
            endereco = new Endereco();
            pessoa.AdicionarEndereco(endereco);
        }

        [TestMethod]
        public void PessoaTemPeloMenosUmEnderecoQueSejaValido()
        {
            Assert.IsTrue(pessoa.Enderecos.Any());
        }
    }
}
