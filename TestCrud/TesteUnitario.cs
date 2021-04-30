using CrudProjeto.Data;
using CrudProjeto.Models;
using Infra.Repositorio;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCrud
{
    class TesteUnitario
    {


        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_GetClientes_Pode_Retornar_Clientes()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Teste1")
                .EnableSensitiveDataLogging()
                .Options;

            var context = new ApplicationDbContext(options);

            Seed(context);

            var repo = new Repositorio<Cliente>(context);

            var result = repo.GetClientes();

            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void Test_GetClientePorID_Pode_Retornar_Cliente()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
             .UseInMemoryDatabase(databaseName: "Teste2")
             .Options;

            var context = new ApplicationDbContext(options);

            Seed(context);

            var repo = new Repositorio<Cliente>(context);

            var result = repo.GetClientePorID(1);

            Assert.AreEqual("Eduardo", result.Nome);
        }

        [Test]
        public void Test_InsertCliente_Pode_Inserir_Cliente()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "Teste3")
            .Options;

            var context = new ApplicationDbContext(options);

            Seed(context);

            var repo = new Repositorio<Cliente>(context);

            var c = new Cliente { Id = 3, Nome = "Henrique", Sobrenome = "Lopes", Telefone = "986092941" };

            repo.InsertCliente(c);

            var result = repo.GetClientes();

            Assert.AreEqual(3, result.Count);

        }

        [Test]
        public void Test_DeleteCliente_Pode_Deletar_Cliente()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Teste4")
                .Options;

            var context = new ApplicationDbContext(options);

            Seed(context);

            var repo = new Repositorio<Cliente>(context);

            var c = repo.GetClientePorID(2);

            repo.DeleteCliente(c);

            var result = repo.GetClientes();

            Assert.AreEqual(1, result.Count);

        }

        [Test]
        public void Test_UpdateCliente_Pode_Atualizar_Cliente()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Teste5")
                .Options;

            var context = new ApplicationDbContext(options);

            Seed(context);

            var repo = new Repositorio<Cliente>(context);

            var c = repo.GetClientePorID(2);
            c.Nome = "Ramon";

            repo.UpdateCliente(c);

            var result = repo.GetClientePorID(2);

            Assert.AreEqual("Ramon", result.Nome);
        }


        private void Seed(ApplicationDbContext context)
        {
            IList<Cliente> clientes = new List<Cliente> {
                new Cliente { Id = 1, Nome = "Eduardo", Sobrenome = "Carvalho", Telefone = "985092041"},
                new Cliente { Id = 2, Nome = "Jorge", Sobrenome = "Henrique", Telefone = "986092241"}
            };

            context.Clientes.AddRange(clientes);
            context.SaveChanges();
        }
    }
}
