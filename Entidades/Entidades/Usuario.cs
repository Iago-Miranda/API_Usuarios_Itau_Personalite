using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entidades.Entidades
{
    public class Usuario
    {
        public Guid Id { get; set; }

        [MaxLength(128)]
        public string Nome { get; set; }

        [MaxLength(128)]
        public string Email { get; set; }

        [MaxLength(256)]
        public string Senha { get; set; }
    }
}
