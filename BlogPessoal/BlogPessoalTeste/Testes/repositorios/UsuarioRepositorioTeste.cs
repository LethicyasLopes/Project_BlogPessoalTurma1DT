using System.Linq;
using BlogPessoal.src.data;
using BlogPessoal.src.data.dtos;
using BlogPessoal.src.repositorios;
using BlogPessoal.src.repositorios.implementacoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlogPessoalTeste.Testes.repositorios
{
    [TestClass]
    public class UsuarioRepositorioTeste
    {
        private BlogPessoalContexto _contexto;
        private IUsuario _repositorio;
        [TestInitialize]
        public void ConfiguracaoInicial()
        {
            var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
            .UseInMemoryDatabase(databaseName: "db_blogpessoal")
            .Options;
            _contexto = new BlogPessoalContexto(opt);
            _repositorio = new UsuarioRepositorio(_contexto);
        }

        [TestMethod]
        public void CriarQuatroUsuariosNoBancoRetornaQuatroUsuarios()
        {
            //GIVEN - Dado que registro 4 usuarios no banco
            _repositorio.NovoUsuario(
            new NovoUsuarioDTO(
            "Cynthia Freitas",
            "cynthia@email.com",
            "134652",
            "URLFOTO"));

            _repositorio.NovoUsuario(
            new NovoUsuarioDTO(
            "Guilherme Lopes",
            "guilherme@email.com",
            "134652",
            "URLFOTO"));

            _repositorio.NovoUsuario(
            new NovoUsuarioDTO(
            "Vinicius Cassullo",
            "vinicius@email.com",
            "134652",
            "URLFOTO"));

            _repositorio.NovoUsuario(
            new NovoUsuarioDTO(
            "Maria Cleres",
            "mcleres@email.com",
            "134652",
            "URLFOTO"));

            //WHEN - Quando pesquiso lista total
            //THEN - Então recebo 4 usuarios
            Assert.AreEqual(4, _contexto.Usuarios.Count());
        }

        [TestMethod]
        public void PegarUsuarioPeloEmailRetornaNaoNulo()
        {
            //GIVEN - Dado que registro um usuario no banco
            _repositorio.NovoUsuario(
            new NovoUsuarioDTO(
            "Milton Tomé",
            "milton@email.com",
            "134652",
            "URLFOTO"));

            //WHEN - Quando pesquiso pelo email deste usuario
            var user = _repositorio.PegarUsuarioPeloEmail("milton@email.com");

            //THEN - Então obtenho um usuario
            Assert.IsNotNull(user);
        }
        [TestMethod]
        public void PegarUsuarioPeloIdRetornaNaoNuloENomeDoUsuario()
        {
            //GIVEN - Dado que registro um usuario no banco
            _repositorio.NovoUsuario(
            new NovoUsuarioDTO(
            "Lethicya Lopes",
            "lethicya@email.com",
            "134652",
            "URLFOTO"));

            //WHEN - Quando pesquiso pelo id 6
            var user = _repositorio.PegarUsuarioPeloId(6);

            //THEN - Então, deve me retornar um elemento não nulo
            Assert.IsNotNull(user);

            //THEN - Então, o elemento deve ser Lethicya Lopes
            Assert.AreEqual("Lethicya Lopes", user.Nome);
        }

        [TestMethod]
        public void AtualizarUsuarioRetornaUsuarioAtualizado()
        {
            //GIVEN - Dado que registro um usuario no banco
            _repositorio.NovoUsuario(
            new NovoUsuarioDTO(
            "Emilly Lopes",
            "emilly@email.com",
            "134652",
            "URLFOTO"));

            //WHEN - Quando atualizamos o usuario
            var antigo = _repositorio.PegarUsuarioPeloEmail("emilly@email.com");
            _repositorio.AtualizarUsuario(
            new AtualizarUsuarioDTO(
                5,
                "Emilly Lopes",
                "134652",
                "URLFOTONOVA"));

            //THEN - Então, quando validamos pesquisa deve retornar nome Emilly Lopes
            Assert.AreEqual(
            "Emilly Lopes",
            _contexto.Usuarios.FirstOrDefault(u => u.Id == antigo.Id).Nome);

            //THEN - Então, quando validamos pesquisa deve retornar senha 123456
            Assert.AreEqual(
            "134652",
            _contexto.Usuarios.FirstOrDefault(u => u.Id ==
            antigo.Id).Senha);
        }
    }
}

    


