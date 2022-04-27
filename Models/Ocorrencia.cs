using System;

namespace App.Models
{
    public class Ocorrencia
    {
        public int Id { get; set; }
        public int IdFuncionario { get; set; }
        public virtual TipoOcorrencia TipoOcorrencia { get; set; }
        public virtual StatusOcorrencia StatusOcorrencia { get; set; }
        public virtual Funcionario Funcionario { get; set; }
        public int IdTipoOcorrencia { get; set; }
        public int IdStatusOcorrencia { get; set; }
        public DateTime? Data { get; set; }
        public string Descricao { get; set; }
    }
}