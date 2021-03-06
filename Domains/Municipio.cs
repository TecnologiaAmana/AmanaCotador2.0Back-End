using System;
using System.Collections.Generic;

#nullable disable

namespace amanaWebAPI.Domains
{
    public partial class Municipio
    {
        public Municipio()
        {
            Plantios = new HashSet<Plantio>();
        }

        public int IdMunicipio { get; set; }
        public short? IdUf { get; set; }
        public string Nome { get; set; }

        public virtual Uf IdUfNavigation { get; set; }
        public virtual ICollection<Plantio> Plantios { get; set; }
    }
}
