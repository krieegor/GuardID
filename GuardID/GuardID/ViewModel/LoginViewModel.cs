using GuardID.Model.Services.ServicesViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GuardID.ViewModel
{
    class LoginViewModel : BaseViewModel
    {
        public string Background { get; set; }

        private string email;

        public string Email
        {
            get { return email; }
            set { this.SetProperty(ref email ,value); }
        }

        private string senha;

        public string Senha
        {
            get { return senha; }
            set { SetProperty(ref senha, value); }
        }

        private readonly Command loginCommand;

        private readonly IMessageService _messageService;

        public Command LoginCommand
        {
            get;
            set;
        }

        public LoginViewModel()
        {
            LoginCommand = new Command(Login);
            Background = Util.ImagePorSistema("backgroung");
            _messageService = DependencyService.Get<IMessageService>();
        }

        private void Login()
        {
            if(Email.Equals("adm") && Senha.Equals("123"))
            {
                //Navegar para a Proxima page
            }
            else
            {
                _messageService.ShowAsync("Email e/ou senha incorreto. ");
            }

        }

    }
}
