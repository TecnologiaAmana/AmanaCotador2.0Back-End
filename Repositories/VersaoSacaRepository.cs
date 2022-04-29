using amanaWebAPI.Context;
using amanaWebAPI.Domains;
using amanaWebAPI.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace amanaWebAPI.Repositories
{
    public class VersaoSacaRepository : IVersaoSacaRepository
    {

        private readonly CotadorContext ctx;

        public VersaoSacaRepository(CotadorContext appContext)
        {
            ctx = appContext;
        }
        public bool Atualizar(int id, Versaosaca culturaAtualizada)
        {
            throw new System.NotImplementedException();
        }

        public Versaosaca BuscarPorId(int id)
        {
            return ctx.Versaosacas.FirstOrDefault(v => v.IdVersaoSaca == id);
        }

        public bool Cadastrar(Versaosaca Cultura)
        {
            throw new System.NotImplementedException();
        }

        public bool Deletar(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Versaosaca> ListarTodos()
        {
            return ctx.Versaosacas.ToList();
        }
    }
}
