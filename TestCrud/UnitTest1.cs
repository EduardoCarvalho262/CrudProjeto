using CrudProjeto.Controllers;
using CrudProjeto.Models;
using CrudProjeto.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
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
        public void Test_Get_Retorna_Elementos_Da_Lista()
        {
            _mockService.Setup(r => r.Obter()).Returns(new List<Cliente> {
                new Cliente { Id = 1, Nome = "Edu", Sobrenome = "Carvalho",Telefone = "41445907" },
                new Cliente { Id = 2, Nome = "Eduardo", Sobrenome = "Cutrim",Telefone = "41445908" }
            });

            var lista = _controller.Get();

            var esperado = 2;

            Assert.AreEqual(esperado, lista.Count);

        }

        [Test]
        public void Test_Get_Retorna_Por_id()
        {
            _mockService.Setup(r => r.ObterPorId(It.IsAny<int>()))
                .Returns(new Cliente { Id = 1, Nome = "Edu", Sobrenome = "Carvalho", Telefone = "41445907" });

            var result = _controller.Get(1);

            Assert.IsInstanceOf<OkObjectResult>(result.Result);
        }

        [Test]
        public void Test_Post_Cria_Cliente()
        {
            _mockService.Setup(r => r.Criar(It.IsAny<Cliente>()));

            Cliente cliente = new Cliente { Id = 1, Nome = "Eduardo", Sobrenome = "Cutrim", Telefone = "41444907" };

            var result = _controller.Post(cliente);

            Assert.IsInstanceOf<CreatedAtActionResult>(result.Result);
        }

        [Test]
        public void Test_Delete_Cliente()
        {

            _mockService.Setup(r => r.ObterPorId(It.IsAny<int>()))
                .Returns(new Cliente { Id = 1, Nome = "Edu", Sobrenome = "Carvalho", Telefone = "41445907" });


            var result = _controller.Delete(1);


            Assert.IsInstanceOf<NoContentResult>(result.Result);

        }

        [Test]
        public void Test_Put_Cliente()
        {
            _mockService.Setup(r => r.Atualizar(It.IsAny<Cliente>()))
                .Returns(new Cliente { Id = 2, Nome = "Eduardo", Sobrenome = "Cutrim", Telefone = "41425987" });


            int id = 2;

            var c = new Cliente { Id = 2, Nome = "Eduardo", Sobrenome = "Cutrim Damascena", Telefone = "41425987" };

            var result = _controller.Put(id, c);

            Assert.IsInstanceOf<NoContentResult>(result.Result);
        }
    }
}