using System.Collections.Generic;

namespace App.Models
{
    public class Cargo
    {
        public int Id { get; set; }
        public string NomeCargo { get; set; }
        public ICollection<Contrato> Contratos { get; set; }
    }
}