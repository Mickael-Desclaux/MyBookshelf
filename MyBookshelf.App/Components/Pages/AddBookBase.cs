using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MyBookshelf.Core.Model;
using MyBookshelf.Core.Service;
using System.Linq.Expressions;

namespace MyBookshelf.App.Components.Pages
{
    public class AddBookBase : ComponentBase
    {
        [Inject] protected IBookService BookService { get; init; } = default!;
        [Inject] protected NavigationManager NavigationManager { get; set; } = default!;

        protected Book Book = new();

        protected string newQuote;

        protected EditContext EditContext;

        protected async Task AddBookAsync()
        {
            try
            {
                if (EditContext.Validate())
                {
                    Book.Quotes = FormatQuotes(Book);
                    await BookService.AddBookAsync(Book);
                    NavigationManager.NavigateTo("/");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        protected List<string> GetQuotes(Book book)
        {
            if (!string.IsNullOrWhiteSpace(book.Quotes))
            {
                return book.Quotes.Split('|').ToList();
            }
            else
            {
                return new List<string>();
            }
        }

        protected void AddNewQuote()
        {
            if (!string.IsNullOrWhiteSpace(newQuote))
            {
                if (string.IsNullOrWhiteSpace(Book.Quotes))
                {
                    Book.Quotes = newQuote;
                }
                else
                {
                    Book.Quotes += "|" + newQuote;
                }
                newQuote = string.Empty;
            }
        }

        protected string FormatQuotes(Book book)
        {
            if (string.IsNullOrWhiteSpace(book.Quotes))
            {
                return string.Empty;
            }

            return string.Join("|", book.Quotes.Split('|').Select(q => q.Trim()));
        }

        protected override void OnInitialized()
        {
            EditContext = new EditContext(Book);
            base.OnInitialized();
        }

    }
}
