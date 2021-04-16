using CrudProjeto.Controllers;
using CrudProjeto.Models;
using CrudProjeto.Services;
using Moq;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace TestCrud
{
    public class Tests
    {
        private Mock<IClienteService> _mockService;
        private ClienteController _controller;

        [SetUp]
        public void Setup()
        {
            _mockService = new Mock<IClienteService>();
            _controller = new ClienteController(_mockService.Object);
        }

        [Test]
        public void Test_Get_Retorna_Quantidade_Lista()
        {
            _mockService.Setup(r => r.Obter()).Returns(new List<Cliente> {
                new Cliente { Id = 1, Nome = "Edu", Sobrenome = "Carvalho",Telefone = "41445907" }
            });

            var lista = _controller.Get();

            var esperado = 1;

            Assert.AreEqual(esperado, lista.Count);

        }

    }
}