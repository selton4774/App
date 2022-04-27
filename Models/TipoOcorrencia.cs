using System.Collections.Generic;

namespace App.Models
{
    public class TipoOcorrencia
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<Ocorrencia> Ocorrencias { get; set; }
    }
}