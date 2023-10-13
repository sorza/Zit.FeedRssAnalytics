using System.ComponentModel.DataAnnotations;

namespace Zit.FeedRssBlogsAnalyticsApi.DTOs
{
    public class CategoryDto
    {
        [Display(Name="Nome da Categoria")]
        [StringLength(80, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres", MinimumLength = 1)]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string? Name { get; set; }

        [Display(Name = "Número de Posts nesta Categoria")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int Count { get; set; }
    }
}
