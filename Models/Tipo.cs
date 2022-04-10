using System.Collections.Generic;

namespace App.Models
{
    public class Tipo
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public ICollection<HoraExtra> HorasExtras { get; set; }
    }
}