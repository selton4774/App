using System;
using System.Collections.Generic;

namespace App.Models
{
    public class RegistroPonto
    {
        public int Id { get; set; }
        public int IdFuncionario { get; set; }
        public virtual Funcionario Funcionario { get; set; }
        public DateTime? Tempo { get; set; }
    }
}