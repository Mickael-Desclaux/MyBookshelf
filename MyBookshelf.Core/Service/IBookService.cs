using MyBookshelf.Core.Model;

namespace MyBookshelf.Core.Service
{
    public interface IBookService
    {
        public Task<IEnumerable<Book>> GetAllBooksAsync();
        public Task<Book> GetBookByIdAsync(int id);
        public Task AddBookAsync(Book book);
        public Task UpdateBookAsync(Book book);
        public Task RemoveBookAsync(int id);
    }
}
