using Microsoft.AspNetCore.Components;
using MyBookshelf.Core.Model;
using MyBookshelf.Core.Service;

namespace MyBookshelf.App.Components.Pages
{
    public class HomeBase : ComponentBase
    {
        [Inject] protected IBookService BookService { get; init; } = default!;

        protected List<Book>? Books = new();

        protected override async Task OnInitializedAsync()
        {
            var bookList = await BookService.GetAllBooksAsync();
            Books = bookList.ToList();
        }
    }
}
