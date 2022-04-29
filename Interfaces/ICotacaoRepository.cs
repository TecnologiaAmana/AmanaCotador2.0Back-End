using amanaWebAPI.Domains;
using amanaWebAPI.ExtendedDomain;
using amanaWebAPI.ViewModels;
using System.Collections.Generic;

namespace amanaWebAPI.Interfaces
{
    public interface ICotacaoRepository
    {
        List<Cotacao> ListarTodas();

        List<CotacaoExtended> Calcular(List<Cotacao> cotacoesSimples, int area);

        Cotacao BuscarPorId(int id);

        List<Cotacao> BuscarPorPlantio(int idPlantio);

        bool Cadastrar(Cotacao CotacaoDomain);

        Cotacao PrepCadastrar(CotacaoViewModel CotacaoModel);

        bool Deletar(int id);

        bool Atualizar(int id, Cotacao cotacaoAtualizada);
    }
}
