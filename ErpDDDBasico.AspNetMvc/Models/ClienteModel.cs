using System.ComponentModel.DataAnnotations;

namespace ErpDDDBasico.AspNetMvc.Models
{
    public class ClienteModel
    {
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio.")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio.")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio.")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio.")]
        public string Cidade { get; set; }
    }
}