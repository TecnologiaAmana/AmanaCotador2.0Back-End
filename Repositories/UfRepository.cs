using amanaWebAPI.Context;
using amanaWebAPI.Domains;
using amanaWebAPI.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace amanaWebAPI.Repositories
{
    public class UfRepository : IUfRepository
    {
        private readonly CotadorContext ctx;

        public UfRepository(CotadorContext appContext)
        {
            ctx = appContext;
        }
        public bool Atualizar(int id, Uf UfAtualizado)
        {
            throw new System.NotImplementedException();
        }

        public Uf BuscarPorId(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Cadastrar(Uf Uf)
        {
            throw new System.NotImplementedException();
        }

        public bool Deletar(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Uf> ListarTodos()
        {
            return ctx.Ufs.ToList();
        }
    }
}
