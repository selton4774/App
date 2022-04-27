using System;

namespace App.Models
{
    public class Contrato
    {
        public int Id { get; set; }
        public int IdCargo { get; set; }
        public int IdFuncionario { get; set; }
        public int IdExpediente { get; set; }
        public int IdModalidadeContrato { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public virtual Funcionario Funcionario { get; set; }
        public virtual ModalidadeContrato ModalidadeContrato { get; set; }
        public virtual Expediente Expediente { get; set; }
        public virtual Cargo Cargo { get; set; }

    }
}