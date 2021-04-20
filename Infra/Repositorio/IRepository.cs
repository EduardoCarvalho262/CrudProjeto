using CrudProjeto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositorio
{
    interface IRepository<T> where T : Cliente
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Insert(T cliente);
        void Update(T cliente);
        void Delete(T cliente);

    }
}
