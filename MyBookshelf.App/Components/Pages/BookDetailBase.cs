using Microsoft.AspNetCore.Components;
using MyBookshelf.Core.Model;
using MyBookshelf.Core.Service;

namespace MyBookshelf.App.Components.Pages
{
    public class BookDetailBase : ComponentBase
    {
        [Inject] protected IBookService BookService { get; init; } = default!;
        [Inject] protected NavigationManager NavigationManager { get; set; } = default!;
        [Parameter] public int? Id { get; set; }
        
        protected Book Book { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (Id.HasValue)
            {
                Book = await BookService.GetBookByIdAsync(Id.Value);
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

        protected async void RemoveBookAsync(Book book)
        {
            bool confirmed = await ShowDeleteConfirmationDialogAsync();
            if (confirmed)
            {
                await BookService.RemoveBookAsync(book);
                NavigationManager.NavigateTo("/");
            }
        }

        protected async Task<bool> ShowDeleteConfirmationDialogAsync()
        {
            var result = await Application.Current.MainPage.DisplayAlert("Confirmation", "Voulez-vous vraiment supprimer ce livre?", "Oui", "Non");
            return result;
        }

        protected void NavigateToBookEdit(Book book)
        {
            NavigationManager.NavigateTo($"editbook/{book.Id}");
        }
    }
}
