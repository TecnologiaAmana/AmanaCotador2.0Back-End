using System;
using System.Collections.Generic;

#nullable disable

namespace amanaWebAPI.Domains
{
    public partial class Cotacao
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
    }
}
