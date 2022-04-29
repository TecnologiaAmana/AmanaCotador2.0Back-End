using amanaWebAPI.Context;
using amanaWebAPI.Domains;
using amanaWebAPI.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace amanaWebAPI.Repositories
{
    public class NivelCoberturaRepository : INivelcoberturaRepository
    {
        private readonly CotadorContext ctx;

        public NivelCoberturaRepository(CotadorContext appContext)
        {
            ctx = appContext;
        }
        public bool Atualizar(int id, Nivelcobertura nivelCoberturaAtualizado)
        {
            Nivelcobertura nivelBuscado = BuscarPorId(id);
            if (nivelBuscado == null) return false;

            nivelCoberturaAtualizado.IdNivelCobertura = nivelBuscado.IdNivelCobertura;
            ctx.Nivelcoberturas.Update(nivelCoberturaAtualizado);
            ctx.SaveChanges();
            return true;
        }

        public Nivelcobertura BuscarPorId(int id)
        {
            return ctx.Nivelcoberturas.FirstOrDefault(n => n.IdNivelCobertura == id);
        }

        public bool Cadastrar(Nivelcobertura nivelCobertura)
        {
            ctx.Nivelcoberturas.Add(nivelCobertura);
            return true;
        }

        public bool Deletar(int id)
        {
            Nivelcobertura nivelBuscado = BuscarPorId(id);
            if (nivelBuscado == null) return false;

            ctx.Nivelcoberturas.Remove(nivelBuscado);
            ctx.SaveChanges();
            return true;
        }

        public List<Nivelcobertura> ListarTodos()
        {
            return ctx.Nivelcoberturas.ToList();
        }
    }
}
