using System.ComponentModel.DataAnnotations;

namespace amanaWebAPI.ViewModels
{
    public class ClienteViewModel
    {
        [Required]
        public int? IdUsuario { get; set; }
        [Required]
        public string Telefone { get; set; }
    }
}
