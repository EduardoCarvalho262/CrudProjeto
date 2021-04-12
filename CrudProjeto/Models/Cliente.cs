﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProjeto.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o nome")]
        [MinLength(3, ErrorMessage = "O nome deve ter um tamanho mínimo de 3 caracteres.")]
        public string Nome { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o sobrenome")]
        [MinLength(3, ErrorMessage = "O nome deve ter um tamanho mínimo de 3 caracteres.")]
        public string Sobrenome { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o telefone")]
        [MinLength(9, ErrorMessage = "O nome deve ter um tamanho mínimo de 9 caracteres.")]
        public string Telefone { get; set; }
    }
}
