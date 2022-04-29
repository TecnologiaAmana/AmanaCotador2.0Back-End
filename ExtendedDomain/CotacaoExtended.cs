using amanaWebAPI.Domains;
using System;

namespace amanaWebAPI.ExtendedDomain
{
    public class CotacaoExtended
    {
        public int IdCotacao { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdPlantio { get; set; }
        public short? VersaoSaca { get; set; }
        public double TaxaBasica { get; set; }
        public double TaxaReplantio { get; set; }
        public double ValorSaca { get; set; }
        public double? ProdutividadeEsperada { get; set; }
        public int Lmgareplantio { get; set; }
        public DateTime PeriodoSaca { get; set; }

        public virtual Plantio IdPlantioNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual Versaosaca VersaoSacaNavigation { get; set; }

        //Calculo

        public double? ValorLmgaReplantio { get; set; }
        public double? Lmgabasica { get; set; }
        public double? ProdutivadeGarantida { get; set; }
        public double? PremioBasicaSubvencao { get; set; }
        public double? PremioBasica { get; set; }
        public double? PremioReplantio { get; set; }
        public double? PremioReplantioSubvencao { get; set; }
        public double? Subvencao { get; set; }
        public double? PremioSubvencao { get; set; }
        public double? PremioMedio { get; set; }
        public double? PremioMedioSubvencao { get; set; }

        public double? PremioTotal { get; set; }

        public int? Area { get; set; }
    }
}
