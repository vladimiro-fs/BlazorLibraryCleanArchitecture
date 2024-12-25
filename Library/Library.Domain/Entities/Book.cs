namespace Library.Domain.Entities
{
    using Library.Domain.Enums;
    using System.ComponentModel.DataAnnotations;

    public class Book
    {
        public int BookId { get; set; }

        [Required(ErrorMessage ="Insert book title")]
        [StringLength(150)]
        public string? Title { get; set; }

        [Required(ErrorMessage ="Insert book author")]
        [StringLength(200)]
        public string? Author { get; set; }

        [Required(ErrorMessage ="Insert book release date")]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage ="Insert book cover")]
        [StringLength(200)]
        public string? Cover { get; set; }

        [Required]
        public Publisher Publisher { get; set; }

        [Required]
        [EnumDataType(typeof(Category), ErrorMessage ="Select a category")]
        public Category Category { get; set; }

        public Book(int bookId, string? title, string? author, 
                    DateTime releaseDate, string? cover, 
                    Publisher publisher, Category category)
        {
            BookId = bookId;
            Title = title;
            Author = author;
            ReleaseDate = releaseDate;
            Cover = cover;
            Publisher = publisher;
            Category = category;
        }
    }
}
