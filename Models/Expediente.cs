using System.Collections.Generic;

namespace App.Models
{
    public class Expediente
    {
        public int Id { get; set; }
        public int CargaHoraria { get; set; }
        public virtual ICollection<Contrato> Contratos { get; set; }
    }
}