using System.ComponentModel.DataAnnotations;

namespace MyBookshelf.Core.Model
{
    public class Book
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Veuillez renseigner le titre du livre.")]
        public string Title { get; set; }
        public string? Author { get; set; }
        [Range(0, 5, ErrorMessage = "La note doit être un chiffre entre 0 et 5.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "La note doit être un nombre entier.")]
        [Required(ErrorMessage = "Veuillez renseigner une note.")]
        public int Note { get; set; }
        public string? Review { get; set; }
        public string? Quotes { get; set; }
    }
}
