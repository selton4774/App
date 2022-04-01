using System.Collections.Generic;

namespace App.Models
{
    public class StatusOcorrencia
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public ICollection<Ocorrencia> Ocorrencias { get; set; }
    }
}