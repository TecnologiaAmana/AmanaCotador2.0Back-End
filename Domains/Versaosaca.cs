using System;
using System.Collections.Generic;

#nullable disable

namespace amanaWebAPI.Domains
{
    public partial class Versaosaca
    {
        public Versaosaca()
        {
            Cotacaos = new HashSet<Cotacao>();
        }

        public short IdVersaoSaca { get; set; }
        public string Valor { get; set; }

        public virtual ICollection<Cotacao> Cotacaos { get; set; }
    }
}
