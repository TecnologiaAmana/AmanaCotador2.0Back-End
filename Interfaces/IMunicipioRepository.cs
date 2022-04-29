using amanaWebAPI.Domains;
using System.Collections.Generic;

namespace amanaWebAPI.Interfaces
{
    public interface IMunicipioRepository
    {
        List<Municipio> ListarTodos();

        List<Municipio> ListarPeloUf(int idUf);

        Municipio BuscarPorId(int id);

        bool Cadastrar(Municipio Municipio);

        bool Deletar(int id);

        bool Atualizar(int id, Municipio municipioAtualizado);
    }
}
