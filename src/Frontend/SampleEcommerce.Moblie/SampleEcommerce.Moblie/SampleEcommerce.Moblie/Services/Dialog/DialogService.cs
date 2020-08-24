using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleEcommerce.Mobile.Services.Dialog
{

    public class DialogService : IDialogService
    {
        private Page _currentPage => Application.Current.MainPage;

        public Task<bool> Ask(string title, string question)
        {
            return _currentPage.DisplayAlert(title, question, "Yes", "No");
        }

        public Task ShowMessage(string title, string message)
        {
            return _currentPage.DisplayAlert(title, message, "Ok");
        }

        public async Task<(bool calceled, string chose)> Choose(string question, string cancel = null, params string[] selections)
        {
            var result = await _currentPage.DisplayActionSheet(question, question, cancel, selections);
            return (result == cancel, result);
        }
    }

}
