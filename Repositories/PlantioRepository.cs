using amanaWebAPI.Context;
using amanaWebAPI.Domains;
using amanaWebAPI.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace amanaWebAPI.Repositories
{
    public class PlantioRepository : IPlantioRepository
    {
        private readonly CotadorContext ctx;

        public PlantioRepository(CotadorContext appContext)
        {
            ctx = appContext;
        }
        public bool Atualizar(int id, Plantio plantioAtualizado)
        {
            Plantio plantioBuscado = BuscarPorId(id);

            if (plantioBuscado == null) return false;

            plantioAtualizado.IdPlantio = id;
            ctx.Update(plantioAtualizado);
            ctx.SaveChanges();
            return true;
        }

        public Plantio BuscarPorId(int id)
        {
            return ctx.Plantios.Find(id);
        }

        public Plantio BuscarPorInfo(int idMunicipio, int idSeguradora, int idCultura, int idNivelCobertura)
        {
            return ctx.Plantios.Where(p => p.IdMunicipio == idMunicipio &&
                                           p.IdSeguradora == idSeguradora &&
                                           p.IdCultura == idCultura &&
                                           p.IdNivelCobertura == idNivelCobertura).FirstOrDefault();
        }

        public bool Cadastrar(Plantio novoPlantio)
        {
            ctx.Add(novoPlantio);
            ctx.SaveChanges();
            return true;
        }

        public bool Deletar(int id)
        {
            Plantio plantioBuscado = BuscarPorId(id);

            if (plantioBuscado == null) return false;

            ctx.Remove(plantioBuscado);
            ctx.SaveChanges();
            return true;
        }

        public List<Plantio> ListarTodos()
        {
            return ctx.Plantios.ToList();
        }
    }
}
