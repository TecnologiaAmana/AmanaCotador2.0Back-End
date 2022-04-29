using amanaWebAPI.Domains;
using System.Collections.Generic;

namespace amanaWebAPI.Interfaces
{
    public interface INivelcoberturaRepository
    {
        List<Nivelcobertura> ListarTodos();

        Nivelcobertura BuscarPorId(int id);

        bool Cadastrar(Nivelcobertura nivelCobertura);

        bool Deletar(int id);

        bool Atualizar(int id, Nivelcobertura nivelCoberturaAtualizado);
    }
}
