using System;
using System.Collections.Generic;

namespace App.Models
{
    public class HoraExtra
    {
        public int Id { get; set; }
        public int IdFuncionario { get; set; }
        public virtual Funcionario Funcionario { get; set; }
        public virtual Tipo Tipo { get; set; }
        public virtual ModalidadeHoraExtra ModalidadeHoraExtra { get; set; }
        public int IdModalidadeHoraExtra { get; set; }
        public int IdTipo { get; set; }
        public DateTime? DataUso { get; set; }
        public int QtdUsada { get; set; }
    }
}