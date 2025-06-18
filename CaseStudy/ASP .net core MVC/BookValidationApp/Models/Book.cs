using System.ComponentModel.DataAnnotations;

namespace BookValidationApp.Models
{
    public class Book
    {
        [Required(ErrorMessage = "ISBN is required.")]
        public int Isbn { get; set; }

        [Required(ErrorMessage = "Book Name is required.")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Book Name must be between 1 and 20 characters.")]
        public string BookName { get; set; }

        [Required(ErrorMessage = "Author Name is required.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Author Name must be between 1 and 50 characters.")]
        public string AuthorName { get; set; }

        [Required(ErrorMessage = "Published Date is required.")]
        [PublishedDateValidation(ErrorMessage = "Published date cannot be in the future.")]
        public DateTime PublishedDate { get; set; }

        [Required(ErrorMessage = "Book URL is required.")]
        [Url(ErrorMessage = "Enter a valid URL.")]
        public string BookUrl { get; set; }
    }
}
