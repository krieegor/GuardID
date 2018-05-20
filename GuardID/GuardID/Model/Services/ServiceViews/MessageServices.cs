using GuardID.Model.Services.ServicesViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GuardID.Model.Services.ServiceViews
{
    class MessageServices : IMessageService
    {
        public async Task ShowAsync(string Message)
        {
            await App.Current.MainPage.DisplayAlert("GuardID", Message, "OK");
        }
        public MessageServices()
        {

        }
    }
}
