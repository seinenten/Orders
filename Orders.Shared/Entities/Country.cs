using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Shared.Entities
{
    public class Country
    {
        public int Id { get; set; }

        //SI NO SE LE AGREGA UN MAX LENGT EN SQL HARA UN VARCHAR MAX Y NO SE PODRA CREAR INDICES
        [Display(Name = "Pais")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Name { get; set; } = null!;

        
    }
}
