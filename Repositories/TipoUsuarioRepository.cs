using amanaWebAPI.Context;
using amanaWebAPI.Domains;
using amanaWebAPI.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace amanaWebAPI.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly CotadorContext ctx;

        public TipoUsuarioRepository(CotadorContext appContext)
        {
            ctx = appContext;
        }
        public bool Atualizar(int id, Tipousuario tipoUsuarioAtualizado)
        {
            Tipousuario tipoBuscado = BuscarPorId(id);
            if (tipoBuscado == null) return false;

            tipoUsuarioAtualizado.IdTipoUsuario = tipoBuscado.IdTipoUsuario;
            ctx.Tipousuarios.Update(tipoUsuarioAtualizado);
            ctx.SaveChanges();
            return true;
        }

        public Tipousuario BuscarPorId(int id)
        {
            return ctx.Tipousuarios.FirstOrDefault(u => u.IdTipoUsuario == id);
        }

        public bool Cadastrar(Tipousuario TipoUsuario)
        {
            ctx.Tipousuarios.Add(TipoUsuario);
            ctx.SaveChanges();
            return true;
        }

        public bool Deletar(int id)
        {
            Tipousuario tipoBuscado = BuscarPorId(id);
            if (tipoBuscado == null) return false;

            ctx.Tipousuarios.Remove(tipoBuscado);
            ctx.SaveChanges();
            return true;
        }

        public List<Tipousuario> ListarTodos()
        {
            return ctx.Tipousuarios.ToList();
        }
    }
}
