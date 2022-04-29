using amanaWebAPI.Context;
using amanaWebAPI.Domains;
using amanaWebAPI.ExtendedDomain;
using amanaWebAPI.Interfaces;
using amanaWebAPI.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace amanaWebAPI.Repositories
{
    public class CotacaoRepository : ICotacaoRepository
    {
        private readonly CotadorContext ctx;

        public CotacaoRepository(CotadorContext appContext)
        {
            ctx = appContext;
        }

        public List<CotacaoExtended> Calcular(List<Cotacao> cotacoesSimples, int area)
        {
            List<CotacaoExtended> cotacoesCompletas = new List<CotacaoExtended>();

            foreach (var c in cotacoesSimples)
            {
                CotacaoExtended cotacao = new CotacaoExtended();

                cotacao.IdCotacao = c.IdCotacao;
                cotacao.IdUsuario = c.IdUsuario;
                cotacao.IdPlantio = c.IdPlantio;
                cotacao.VersaoSaca = c.VersaoSaca;
                cotacao.TaxaBasica = c.TaxaBasica;
                cotacao.TaxaReplantio = c.TaxaReplantio;
                cotacao.ValorSaca = c.ValorSaca;
                cotacao.ProdutividadeEsperada = c.ProdutividadeEsperada;
                cotacao.Lmgareplantio = c.Lmgareplantio;
                cotacao.PeriodoSaca = c.PeriodoSaca;
                cotacao.IdPlantioNavigation = c.IdPlantioNavigation;
                cotacao.IdUsuarioNavigation = c.IdUsuarioNavigation;
                cotacao.VersaoSacaNavigation = c.VersaoSacaNavigation;

                //calculos
                cotacao.ProdutivadeGarantida = c.ProdutividadeEsperada * c.IdPlantioNavigation.IdNivelCoberturaNavigation.Valor / 100;
                cotacao.Lmgabasica = area * cotacao.ProdutivadeGarantida * cotacao.ValorSaca;
                cotacao.ValorLmgaReplantio = cotacao.Lmgareplantio * cotacao.Lmgabasica / 100;
                cotacao.PremioBasica = cotacao.Lmgabasica * cotacao.TaxaBasica;
                cotacao.PremioReplantio = cotacao.TaxaReplantio * cotacao.ValorLmgaReplantio;
                cotacao.PremioTotal = cotacao.PremioReplantio + cotacao.PremioBasica;
                cotacao.Subvencao = cotacao.PremioTotal * 40 / 100;
                if (cotacao.Subvencao > 60000) cotacao.Subvencao = 60000;
                cotacao.PremioSubvencao = cotacao.PremioTotal - cotacao.Subvencao;
                cotacao.PremioMedio = cotacao.PremioTotal / area;
                cotacao.PremioMedioSubvencao = cotacao.PremioSubvencao / area;

                cotacoesCompletas.Add(cotacao);
            }

            return cotacoesCompletas;
        }

        public bool Atualizar(int id, Cotacao cotacaoAtualizada)
        {
            Cotacao cotacao = BuscarPorId(id);
            if (cotacao == null) return false;

            ctx.Cotacaos.Update(cotacao);
            ctx.SaveChanges();

            return true;
        }

        public Cotacao BuscarPorId(int id)
        {
            return ctx.Cotacaos.FirstOrDefault(u => u.IdCotacao == id);
        }

        public bool Cadastrar(Cotacao CotacaoDomain)
        {
            ctx.Cotacaos.Add(CotacaoDomain);
            ctx.SaveChanges();

            return true;
        }

        public bool Deletar(int id)
        {
            Cotacao cotacaoBuscada = BuscarPorId(id);

            if (cotacaoBuscada == null) return false;

            ctx.Cotacaos.Remove(cotacaoBuscada);
            ctx.SaveChanges();
            return true;
        }

        public List<Cotacao> ListarTodas()
        {
            return ctx.Cotacaos
                .Include(c => c.IdPlantioNavigation.IdCulturaNavigation)
                .Include(c => c.IdPlantioNavigation.IdMunicipioNavigation.IdUfNavigation)
                .Include(c => c.IdPlantioNavigation.IdNivelCoberturaNavigation)
                .Include(c => c.IdPlantioNavigation.IdSeguradoraNavigation)
                .Include(c => c.VersaoSacaNavigation)
                .ToList();
        }

        public List<Cotacao> BuscarPorPlantio(int idPlantio)
        {
            return ctx.Cotacaos
                .Include(c => c.IdPlantioNavigation.IdCulturaNavigation)
                .Include(c => c.IdPlantioNavigation.IdMunicipioNavigation.IdUfNavigation)
                .Include(c => c.IdPlantioNavigation.IdNivelCoberturaNavigation)
                .Include(c => c.IdPlantioNavigation.IdSeguradoraNavigation)
                .Include(c => c.VersaoSacaNavigation)
                .Where(u => u.IdPlantio == idPlantio).ToList();
        }

        public Cotacao PrepCadastrar(CotacaoViewModel CotacaoModel)
        {
            Cotacao cotacaoDomain = new Cotacao();

            cotacaoDomain.IdUsuario = CotacaoModel.IdUsuario;
            cotacaoDomain.IdPlantio = CotacaoModel.IdPlantio;
            cotacaoDomain.VersaoSaca = cotacaoDomain.VersaoSaca;
            cotacaoDomain.TaxaBasica = CotacaoModel.PremioBasica / CotacaoModel.LmgaBasica;
            cotacaoDomain.TaxaReplantio = CotacaoModel.PremioReplantio / CotacaoModel.ValorLmgaReplantio;
            cotacaoDomain.ValorSaca = CotacaoModel.ValorSaca;
            cotacaoDomain.ProdutividadeEsperada = CotacaoModel.ProdutividadeEsperada;
            cotacaoDomain.PeriodoSaca = CotacaoModel.PeriodoSaca;
            cotacaoDomain.VersaoSaca = CotacaoModel.VersaoSaca;
            cotacaoDomain.Lmgareplantio = 100 / Convert.ToInt32(CotacaoModel.LmgaBasica / CotacaoModel.ValorLmgaReplantio);

            return cotacaoDomain;
        }
    }
}
