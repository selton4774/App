using System;

namespace App.Models
{
    public class Ocorrencia
    {
        public int Id { get; set; }
        public int IdFuncionario { get; set; }
        public TipoOcorrencia TipoOcorrencia { get; set; }
        public StatusOcorrencia StatusOcorrencia { get; set; }
        public Funcionario Funcionario { get; set; }
        public int IdTipoOcorrencia { get; set; }
        public int IdStatusOcorrencia { get; set; }
        public DateTime? Data { get; set; }
        public string Descricao { get; set; }
    }
}