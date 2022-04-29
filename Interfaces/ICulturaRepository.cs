using amanaWebAPI.Domains;
using System.Collections.Generic;

namespace amanaWebAPI.Interfaces
{
    public interface ICulturaRepository
    {
        List<Cultura> ListarTodos();

        Cultura BuscarPorId(int id);

        bool Cadastrar(Cultura Cultura);

        bool Deletar(int id);

        bool Atualizar(int id, Cultura culturaAtualizada);
    }
}
