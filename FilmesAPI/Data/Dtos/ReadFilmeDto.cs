using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Data.Dtos
{
    public class ReadFilmeDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "campo de título obrigatório")]
        public string titulo { get; set; }
        [StringLength(30, ErrorMessage = "no máximo 30 caracteres")]
        public string diretor { get; set; }
        public string genero { get; set; }
        [Range(1, 600, ErrorMessage = "filme deve ter duração de 1 minuto a 600 minutos")]
        public int duracao { get; set; }
        public string DataHoradaConsulta { get; set; }
    }
}
