using amanaWebAPI.Domains;
using System.Collections.Generic;

namespace amanaWebAPI.Interfaces
{
    public interface IClienteRepository
    {
        List<Cliente> ListarTodos();

        Cliente BuscarPorId(int id);

        bool Cadastrar(Cliente cliente);

        bool Deletar(int id);

        bool Atualizar(int id, Cliente clienteAtualizado);
    }
}
