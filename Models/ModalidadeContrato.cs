using System.Collections.Generic;

namespace App.Models
{
    public class ModalidadeContrato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Contrato> Contratos { get; set; }
    }
}