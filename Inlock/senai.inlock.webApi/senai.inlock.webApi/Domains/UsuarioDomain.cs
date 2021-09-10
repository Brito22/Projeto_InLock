using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Domains
{
    public class UsuarioDomain
    {
        public int idUsuario { get; set; }
        [Required(ErrorMessage = "Informe o e-mail.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informe a senha.")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "O campo senha precisa ter no mínimo 3 e no máximo 10 caracteres.")]
        public string Senha { get; set; }

       

        public TipoUsuarioDomain TipoUsuario { get; set; }
    }
}
