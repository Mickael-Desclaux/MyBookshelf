using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MyBookshelf.Core.Model;
using MyBookshelf.Core.Service;

namespace MyBookshelf.App.Components.Pages
{
    public class EditBookBase : ComponentBase
    {
        [Inject] protected IBookService BookService { get; init; } = default!;
        [Inject] protected NavigationManager NavigationManager { get; set; } = default!;

        [Parameter] public int? Id { get; set; }

        protected Book Book = new();

        protected string newQuote;

        protected EditContext EditContext;

        protected override async Task OnInitializedAsync()
        {
            if (Id.HasValue)
            {
                Book = await BookService.GetBookByIdAsync(Id.Value);
            }
        }

        protected async Task EditBookAsync()
        {
            try
            {
                if (EditContext.Validate())
                {
                    Book.Quotes = FormatQuotes(Book);
                    await BookService.UpdateBookAsync(Book);
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

        protected void RemoveQuote(string quoteToRemove)
        {
            if (!string.IsNullOrWhiteSpace(Book.Quotes))
            {
                var quotesArray = Book.Quotes.Split('|');
                quotesArray = quotesArray.Where(q => q.Trim() != quoteToRemove).ToArray();
                Book.Quotes = string.Join("|", quotesArray);
            }
        }

    }
}
