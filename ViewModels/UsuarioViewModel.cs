using System.ComponentModel.DataAnnotations;

namespace amanaWebAPI.ViewModels
{
    public class UsuarioViewModel
    {
        public short? IdTipoUsuario { get; set; }

        [Required(ErrorMessage = "Informe o nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o e-mail do usuário")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informe a senha do usuário")]
        public string Senha { get; set; }

    }
}
