using amanaWebAPI.Context;
using amanaWebAPI.Domains;
using amanaWebAPI.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace amanaWebAPI.Repositories
{
    public class ClienteRepository : IClienteRepository
    {

        private readonly CotadorContext ctx;

        public ClienteRepository(CotadorContext appContext)
        {
            ctx = appContext;
        }
        public bool Atualizar(int id, Cliente clienteAtualizado)
        {
            Cliente clienteBuscado = BuscarPorId(id);
            if (clienteBuscado == null) return false;

            clienteAtualizado.IdCliente = id;
            ctx.Clientes.Update(clienteAtualizado);
            ctx.SaveChanges();
            return true;

        }

        public Cliente BuscarPorId(int id)
        {
            return ctx.Clientes.FirstOrDefault(u => u.IdUsuario == id);
        }

        public bool Cadastrar(Cliente cliente)
        {
            ctx.Clientes.Add(cliente);
            ctx.SaveChanges();

            return true;
        }

        public bool Deletar(int id)
        {
            Cliente clienteBuscado = BuscarPorId(id);

            if (clienteBuscado == null) return false;

            ctx.Clientes.Remove(clienteBuscado);
            ctx.SaveChanges();

            return true;
        }

        public List<Cliente> ListarTodos()
        {
            return ctx.Clientes.ToList();
        }
    }
}
