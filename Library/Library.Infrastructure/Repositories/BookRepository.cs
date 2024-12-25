namespace Library.Infrastructure.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Library.Domain.Abstractions;
    using Library.Domain.Entities;
    using Library.Infrastructure.Context;
    using Microsoft.EntityFrameworkCore;

    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Book> AddBook(Book book)
        {
            if (_context != null && book != null && _context.Books != null) 
            {
                _context.Books.Add(book);
                await _context.SaveChangesAsync();
                return book;
            }
            else 
            {
                throw new InvalidOperationException("Invalid information");
            }
        }

        public async Task<Book?> GetBook(int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.BookId == id);

            if (book == null)
                throw new InvalidOperationException($"The book with id {id} wasn't found");

            return book;
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            if (_context != null && _context.Books != null) 
            {
                var books = await _context.Books.ToListAsync();
                return books;
            }
            else 
            {
                return new List<Book>();
            }
        }

        public async Task RemoveBook(int id)
        {
            var book = await GetBook(id);

            if (book != null) 
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
            else 
            {
                throw new InvalidOperationException("Invalid data");
            }
        }

        public async Task UpdateBook(Book book)
        {
            if (book != null) 
            {
                _context.Entry(book).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            else 
            {
                throw new ArgumentNullException("Invalid data");
            }
        }
    }
}
