using CrudProjeto.Data;
using CrudProjeto.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProjeto.Services
{

    public class ClienteService : IClienteService
    {

        //Injeção de dependência
        private readonly ApplicationDbContext _db;

        public ClienteService(ApplicationDbContext db)
        {
            _db = db;
        }


        //TODO - todos os services precisam do try-catch e
        //precisam implementar Serilog
        public Cliente Deletar(Cliente cliente)
        {
            _db.Clientes.Remove(cliente);
            _db.SaveChanges();

            return cliente;
        }

        public List<Cliente> Obter()
        {
            return _db.Clientes.ToList();
        }

        public Cliente ObterPorId(int id)
        {
            var c = _db.Clientes.Find(id);
            return c;
        }

        public Cliente Criar(Cliente cliente)
        {
            _db.Clientes.Add(cliente);
            _db.SaveChanges();
            return cliente;
        }

        public Cliente Atualizar(Cliente cliente)
        {
            _db.Update(cliente);
            _db.SaveChanges();
            return cliente;
        }
    }
}
