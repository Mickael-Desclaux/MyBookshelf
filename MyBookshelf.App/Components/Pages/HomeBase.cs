using Microsoft.AspNetCore.Components;
using MyBookshelf.Core.Model;
using MyBookshelf.Core.Service;

namespace MyBookshelf.App.Components.Pages
{
    public class HomeBase : ComponentBase
    {
        [Inject] protected IBookService BookService { get; init; } = default!;
        [Inject] protected NavigationManager NavigationManager { get; set; } = default!;

        protected List<Book>? Books = new();

        protected override async Task OnInitializedAsync()
        {
            var bookList = await BookService.GetAllBooksAsync();
            Books = bookList.ToList();
        }

        protected async Task RemoveBookAsync(Book book)
        {
            bool confirmed = await ShowDeleteConfirmationDialogAsync();
            if (confirmed)
            {
                await BookService.RemoveBookAsync(book);
                Books.Remove(book);
            }
        }

        protected async Task<bool> ShowDeleteConfirmationDialogAsync()
        {
            var result = await Application.Current.MainPage.DisplayAlert("Confirmation", "Voulez-vous vraiment supprimer ce livre?", "Oui", "Non");
            return result;
        }

        protected void NavigateToBookId(Book book)
        {
            NavigationManager.NavigateTo($"editbook/{book.Id}");
        }
    }
}
