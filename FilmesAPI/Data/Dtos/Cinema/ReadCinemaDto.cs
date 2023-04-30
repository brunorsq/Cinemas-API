using System.ComponentModel.DataAnnotations;
using FilmesAPI.Models;

namespace FilmesAPI.Data.Dtos
{
    public class ReadCinemaDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatorio")]
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }
        public Gerente Gerente { get; set; }
    }
}
