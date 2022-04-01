using System.Collections.Generic;

namespace App.Models
{
    public class ModalidadeHoraExtra
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public ICollection<HoraExtra> HoraExtras { get; set; }
    }
}