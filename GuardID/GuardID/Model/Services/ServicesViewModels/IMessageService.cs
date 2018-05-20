using System.Threading.Tasks;

namespace GuardID.Model.Services.ServicesViewModels
{
    public interface IMessageService
    {
        Task ShowAsync(string Message);
    }
}
