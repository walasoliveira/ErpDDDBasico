using System;

namespace ErpDDDBasico.AspNetMvc.Models
{
    public class ModuloModel
    {
        public int ModuloId { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}