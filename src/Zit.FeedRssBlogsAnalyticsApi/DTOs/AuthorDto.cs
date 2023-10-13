using System.ComponentModel.DataAnnotations;

namespace Zit.FeedRssBlogsAnalyticsApi.DTOs
{
    public class AuthorDto
    {
        [Display(Name="Id do autor")]
        [StringLength(100, ErrorMessage ="O campo {0} deve ter entre {2} e {1} caracteres", MinimumLength =1)]
        [Required(ErrorMessage ="O campo {0} é requerido.")]
        public string? AuthorId { get; set; }
        [Display(Name = "Nome do autor")]
        [StringLength(100, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres", MinimumLength = 1)]
        [Required(ErrorMessage = "O campo {0} é requerido.")]
        public string? Author { get; set; }
        [Display(Name = "Nº de Post do autor")]
        public int Count { get; set; }
    }
}
