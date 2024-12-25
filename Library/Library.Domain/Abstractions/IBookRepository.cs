namespace Library.Domain.Abstractions
{
    using Library.Domain.Entities;

    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooks();

        Task<Book?> GetBook(int id);

        Task<Book> AddBook(Book book);
        
        Task RemoveBook(int id);

        Task UpdateBook(Book book);
    }
}
