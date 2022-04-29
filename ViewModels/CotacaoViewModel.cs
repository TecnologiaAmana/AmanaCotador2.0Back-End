using System;
using System.ComponentModel.DataAnnotations;

namespace amanaWebAPI.ViewModels
{
    public class CotacaoViewModel
    {

        public int IdUsuario { get; set; }

        [Required]
        public int IdPlantio { get; set; }

        [Required]
        public int Area { get; set; }

        [Required]
        public double PremioBasica { get; set; }

        [Required]
        public double LmgaBasica { get; set; }

        [Required]
        public double PremioReplantio { get; set; }

        [Required]
        public double ValorLmgaReplantio { get; set; }

        [Required]
        public double ValorSaca { get; set; }

        [Required]
        public int ProdutividadeEsperada { get; set; }

        [Required]
        public DateTime PeriodoSaca { get; set; }

        [Required]
        public short VersaoSaca { get; set; }
    }
}
