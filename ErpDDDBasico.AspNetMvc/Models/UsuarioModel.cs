using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ErpDDDBasico.AspNetMvc.Models
{
    public class UsuarioModel
    {
        [DisplayName("Login")]
        public string UsuarioLogin { get; set; }
        [DisplayName("Senha")]
        [DataType(DataType.Password)]
        public string UsuarioSenha { get; set; }
        public int UsuarioId { get; set; }
        //public List<UsuarioPermissaoModuloModel> UsuarioPermissaoModuloModel { get; set; }
    }
}