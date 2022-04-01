using System.Collections.Generic;

namespace App.Models
{
    public class ModalidadeHoraExtra
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public float Valor { get; set; }
        public ICollection<HoraExtra> HoraExtras { get; set; }
    }
}