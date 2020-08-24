using System.Threading.Tasks;

namespace SampleEcommerce.Mobile.Abstractions
{
    public interface IDialogService
    {
        Task<bool> Ask(string title, string question);

        Task ShowMessage(string title, string message);

        Task<(bool calceled, string chose)> Choose(string question, string cancel = null, params string[] selections);
    }
}
