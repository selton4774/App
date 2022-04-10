using System.Collections.Generic;

namespace App.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public ICollection<RegistroPonto> RegistroDePontos { get; set; }
        public ICollection<HoraExtra> HorasExtras { get; set; }
        public ICollection<Ocorrencia> Ocorrencias { get; set; }
        public ICollection<Contrato> Contratos { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }
    }
}