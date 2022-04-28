using Microsoft.EntityFrameworkCore; 
using BlogPessoal.src.data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlogPessoal.src.modelos;
using System.Linq;

namespace BlogPessoalTeste.Testes.data
{
    [TestClass]
    public class BlogPessoalContextoTeste
    {
        private BlogPessoalContexto _contexto;

        [TestInitialize]
        public void inicio()
        {
            var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
                .UseInMemoryDatabase(databaseName: "db_blogpessoal")
                .Options;

            _contexto = new BlogPessoalContexto(opt);
        }

        [TestMethod]
        public void InserirNovoUsuarioNoBancoRetornaUsuario()
        {
            UsuarioModelo usuario = new UsuarioModelo();

            usuario.Nome = "Lethicya Lopes";
            usuario.Email = "lethicyaslopes@gmail.com";
            usuario.Senha = "123456";
            usuario.Foto = "LINKDAFOTO";

            _contexto.Usuarios.Add(usuario);

            _contexto.SaveChanges();

            Assert.IsNotNull(_contexto.Usuarios.FirstOrDefault(u => u.Email == "lethicyaslopes@gmail.com")); 
        }
    }
}
