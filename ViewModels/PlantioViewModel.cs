using System.ComponentModel.DataAnnotations;

namespace amanaWebAPI.ViewModels
{
    public class PlantioViewModel
    {

        [Required]
        public int IdSeguradora { get; set; }
        [Required]
        public int IdNivelCobertura { get; set; }
        [Required]
        public int IdCultura { get; set; }
        [Required]
        public int IdMunicipio { get; set; }
    }
}
