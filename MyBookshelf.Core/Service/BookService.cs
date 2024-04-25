using MyBookshelf.Core.Model;
using MyBookshelf.Core.Repository;

namespace MyBookshelf.Core.Service
{
    public class BookService(IRepository<Book> bookRepository) : IBookService
    {
        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await bookRepository.GetAllAsync();
        }

        public async Task<Book> GetBookByIdAsync(int bookId)
        {
            IEnumerable<Book> books = await bookRepository.GetAllAsync();
            Book? book = books.FirstOrDefault(b => b.Id == bookId);

            if (book == null)
            {
                throw new Exception("Ce livre n'existe pas.");
            }

            return book;
        }

        public async Task AddBookAsync(Book book)
        {
            await bookRepository.AddAsync(book);
        }

        public async Task UpdateBookAsync(Book book)
        {
            await bookRepository.UpdateAsync(book);
        }

        public async Task RemoveBookAsync(Book book)
        {
            await bookRepository.DeleteAsync(book);
        }
    }
}
