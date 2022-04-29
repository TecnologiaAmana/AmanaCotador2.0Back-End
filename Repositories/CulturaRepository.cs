using amanaWebAPI.Context;
using amanaWebAPI.Domains;
using amanaWebAPI.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace amanaWebAPI.Repositories
{
    public class CulturaRepository : ICulturaRepository
    {

        private readonly CotadorContext ctx;

        public CulturaRepository(CotadorContext appContext)
        {
            ctx = appContext;
        }

        public bool Atualizar(int id, Cultura culturaAtualizada)
        {
            Cultura culturaBuscada = BuscarPorId(id);
            if (culturaBuscada == null) return false;

            culturaAtualizada.IdCultura = culturaBuscada.IdCultura;
            ctx.Culturas.Update(culturaAtualizada);
            ctx.SaveChanges();

            return true;

        }

        public Cultura BuscarPorId(int id)
        {
            return ctx.Culturas.FirstOrDefault(c => c.IdCultura == id);
        }

        public bool Cadastrar(Cultura Cultura)
        {
            ctx.Culturas.Add(Cultura);
            ctx.SaveChanges();
            return true;
        }

        public bool Deletar(int id)
        {
            Cultura culturaBuscada = BuscarPorId(id);
            if (culturaBuscada == null) return false;

            ctx.Culturas.Remove(culturaBuscada);
            ctx.SaveChanges();
            return true;
        }

        public List<Cultura> ListarTodos()
        {
            return ctx.Culturas.ToList();
        }
    }
}
