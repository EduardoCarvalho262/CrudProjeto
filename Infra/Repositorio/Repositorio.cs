using CrudProjeto.Data;
using CrudProjeto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositorio
{
    class Repositorio<T> : IRepository<T> where T : Cliente
    {


        //Injeção de dependência
        private readonly ApplicationDbContext _db;

        public Repositorio(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Delete(T cliente)
        {
            _db.Clientes.Remove(cliente);
            _db.SaveChanges();
        }

        public T Get(int id)
        {
            return (T) _db.Clientes.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return (IEnumerable<T>) _db.Clientes;
        }

        public void Insert(T cliente)
        {
            _db.Clientes.Add(cliente);
            _db.SaveChanges();
        }

        public void Update(T cliente)
        {
            _db.Update(cliente);
            _db.SaveChanges();
        }
    }
}
