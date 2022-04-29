using amanaWebAPI.Context;
using amanaWebAPI.Domains;
using amanaWebAPI.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace amanaWebAPI.Repositories
{
    public class MunicipioRepository : IMunicipioRepository
    {

        private readonly CotadorContext ctx;

        public MunicipioRepository(CotadorContext appContext)
        {
            ctx = appContext;
        }
        public bool Atualizar(int id, Municipio municipioAtualizado)
        {
            Municipio municipioBuscado = BuscarPorId(id);
            if (municipioBuscado == null) return false;

            municipioAtualizado.IdMunicipio = municipioBuscado.IdMunicipio;
            ctx.Municipios.Update(municipioAtualizado);
            ctx.SaveChanges();
            return true;
        }

        public Municipio BuscarPorId(int id)
        {
            return ctx.Municipios.FirstOrDefault(m => m.IdMunicipio == id);
        }

        public bool Cadastrar(Municipio Municipio)
        {
            ctx.Municipios.Add(Municipio);
            return true;
        }

        public bool Deletar(int id)
        {
            Municipio municipioBuscado = BuscarPorId(id);
            if (municipioBuscado == null) return false;

            ctx.Municipios.Remove(municipioBuscado);
            ctx.SaveChanges();

            return true;
        }

        public List<Municipio> ListarPeloUf(int idUf)
        {
            return ctx.Municipios.Where(m => m.IdUf == idUf).ToList();
        }

        public List<Municipio> ListarTodos()
        {
            return ctx.Municipios.ToList();
        }
    }
}
