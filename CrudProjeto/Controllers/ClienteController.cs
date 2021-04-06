using CrudProjeto.Data;
using CrudProjeto.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProjeto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        //Injeção de dependência
        private readonly ApplicationDbContext _db;

        public ClienteController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: api/Cliente
        [HttpGet]
       public IEnumerable<Cliente> Get()
        {
            return _db.Clientes;
        }


        // GET: api/Cliente/5
        [HttpGet("{id}")]
        public ActionResult<Cliente> Get(int id)
        {

            var c = _db.Clientes.Find(id);

            if(c == null)
            {
                return NotFound();
            }

            return c;
        }


        [HttpPut("{id}")]
        public ActionResult<Cliente> Put(int id, Cliente cliente)
        {

            if (id != cliente.Id)
            {
                return BadRequest();
            }

            _db.Update(cliente);
            _db.SaveChanges();

            return NoContent();


        }


        // POST: api/Cliente
        [HttpPost]
        public ActionResult<Cliente> Post(Cliente cliente)
        {
            _db.Clientes.Add(cliente);
            _db.SaveChanges();
            return CreatedAtAction("Get", new { id = cliente.Id }, cliente);
        }


        // DELETE: api/Cliente/5
        [HttpDelete("{id}")]
        public ActionResult<Cliente> Delete(int id)
        {
            var cliente = _db.Clientes.Find(id);
            if(cliente == null)
            {
                return NotFound();
            }

            _db.Clientes.Remove(cliente);
            _db.SaveChanges();
            return NoContent();
        }



    }
}
