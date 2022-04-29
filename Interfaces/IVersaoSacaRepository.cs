using amanaWebAPI.Domains;
using System.Collections.Generic;

namespace amanaWebAPI.Interfaces
{
    public interface IVersaoSacaRepository
    {
        List<Versaosaca> ListarTodos();

        Versaosaca BuscarPorId(int id);

        bool Cadastrar(Versaosaca Cultura);

        bool Deletar(int id);

        bool Atualizar(int id, Versaosaca culturaAtualizada);
    }
}
