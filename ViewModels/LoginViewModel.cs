using System.ComponentModel.DataAnnotations;

namespace amanaWebAPI.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o e-mail do usuário")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informe a senha do usuário")]
        public string Senha { get; set; }
    }
}
