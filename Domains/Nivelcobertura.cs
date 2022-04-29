using System;
using System.Collections.Generic;

#nullable disable

namespace amanaWebAPI.Domains
{
    public partial class Nivelcobertura
    {
        public Nivelcobertura()
        {
            Plantios = new HashSet<Plantio>();
        }

        public byte IdNivelCobertura { get; set; }
        public byte Valor { get; set; }

        public virtual ICollection<Plantio> Plantios { get; set; }
    }
}
