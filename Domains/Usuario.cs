using System;
using System.Collections.Generic;

#nullable disable

namespace amanaWebAPI.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Cotacaos = new HashSet<Cotacao>();
        }

        public int IdUsuario { get; set; }
        public short? IdTipoUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual Tipousuario IdTipoUsuarioNavigation { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<Cotacao> Cotacaos { get; set; }
    }
}
