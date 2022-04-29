using amanaWebAPI.Context;
using amanaWebAPI.Domains;
using amanaWebAPI.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace amanaWebAPI.Repositories
{
    public class SeguradoraRepository : ISeguradoraRepository
    {
        private readonly CotadorContext ctx;

        public SeguradoraRepository(CotadorContext appContext)
        {
            ctx = appContext;
        }
        public bool Atualizar(int id, Seguradora seguradoraAtualizada)
        {
            Seguradora segBuscada = BuscarPorId(id);
            if(segBuscada == null) return false;

            seguradoraAtualizada.IdSeguradora = segBuscada.IdSeguradora;
            ctx.Seguradoras.Update(seguradoraAtualizada);
            ctx.SaveChanges();
            return true;
        }

        public Seguradora BuscarPorId(int id)
        {
            return ctx.Seguradoras.FirstOrDefault(s => s.IdSeguradora == id);
        }

        public bool Cadastrar(Seguradora novaSeguradora)
        {
            ctx.Seguradoras.Add(novaSeguradora);
            ctx.SaveChanges();
            return true;
        }

        public bool Deletar(int id)
        {
            Seguradora segBuscada = BuscarPorId(id);
            if (segBuscada == null) return false;

            ctx.Seguradoras.Remove(segBuscada);
            ctx.SaveChanges();
            return true;
        }

        public List<Seguradora> ListarTodas()
        {
            return ctx.Seguradoras.ToList();
        }
    }
}
