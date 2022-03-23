using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Models
{
    public class Filme
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage ="O campo título é obrigatório")]
        public string Titulo { get; set; }
        [Required(ErrorMessage ="O campo diretor é obrigatório")]
        public string Diretor { get; set; }
        [StringLength(30, ErrorMessage = "O gênero não deve ter mais que 30 caracteres")]
        public string Genero { get; set; }
        [Range(1,800, ErrorMessage = "A duração deve ter entre 1 e 800 minutos")]
        public int Duracao { get; set; }
       
    }
}
