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
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public Funcionario Funcionario { get; set; }
        public ModalidadeContrato ModalidadeContrato { get; set; }
        public Expediente Expediente { get; set; }
        public Cargo Cargo { get; set; }

    }
}