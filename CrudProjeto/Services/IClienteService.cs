using CrudProjeto.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProjeto.Services
{
    public interface IClienteService
    {
        List<Cliente> Obter();
        Cliente ObterPorId(int id);
        Cliente Atualizar(Cliente cliente);
        Cliente Criar(Cliente cliente);
        Cliente Deletar(Cliente cliente);
    }
}
