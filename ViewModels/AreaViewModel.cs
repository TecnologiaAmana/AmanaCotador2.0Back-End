using System.ComponentModel.DataAnnotations;

namespace amanaWebAPI.ViewModels
{
    public class AreaViewModel
    {
        [Required]
        public int Area { get; set; }
    }
}
