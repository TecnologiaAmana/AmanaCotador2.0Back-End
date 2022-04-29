using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace amanaWebAPI.Domains
{
    public partial class Plantio
    {
        public Plantio()
        {
            Cotacaos = new HashSet<Cotacao>();
        }

        public int IdPlantio { get; set; }

        [Required]
        public short? IdSeguradora { get; set; }
        [Required]
        public byte? IdNivelCobertura { get; set; }
        [Required]
        public short? IdCultura { get; set; }
        [Required]
        public int? IdMunicipio { get; set; }

        public virtual Cultura IdCulturaNavigation { get; set; }
        public virtual Municipio IdMunicipioNavigation { get; set; }
        public virtual Nivelcobertura IdNivelCoberturaNavigation { get; set; }
        public virtual Seguradora IdSeguradoraNavigation { get; set; }
        public virtual ICollection<Cotacao> Cotacaos { get; set; }
    }
}
