using GuardID.Model.Services.ServicesViewModels;
using Xamarin.Forms;




namespace GuardID.ViewModel
{
    public class StartViewModel : BaseViewModel
    {
        #region Inicialização de variaveis utilizadas
        public string Background { get; set; }       
        public string ButtonCadastro { get; set; }
        public string LogoIcon1 { get; set; }
        public string LogoIcon2 { get; set; }
        public string LineHorizontal { get; set; }
        public string LineVertical { get; set; }
        public string Sobre { get; set; }
        public string Entrar { get; set; }
        public string Descricao { get; set; }
        public Command BtnNewGuardID { get; }
        public Command BtnLogin { get; }

        private readonly INavigationService _navigationService;

        #endregion
        public StartViewModel()
        {     			               
            Background = Util.ImagePorSistema("background");
            ButtonCadastro = Util.ImagePorSistema("btnCasdastrar"); 
            LogoIcon1 = Util.ImagePorSistema("logoico1"); 
            LogoIcon2 = Util.ImagePorSistema("logoico2"); 
            LineHorizontal = Util.ImagePorSistema("LineHorizontal"); 
            LineVertical = Util.ImagePorSistema("LineVertical"); 
            Sobre = Util.ImagePorSistema("Sobre"); 
            Entrar = Util.ImagePorSistema("Entrar");

            BtnNewGuardID = new Command(ExecuteBtGuardID);
            BtnLogin = new Command(ExecuteBtnLogin);

            _navigationService = DependencyService.Get<INavigationService>();
        }

        private async void ExecuteBtnLogin()
        {
            await _navigationService.NavigateToAsync<LoginViewModel>();
        }

        bool CanExecuteBtnNewGuardID()
        {
            return true;
        }

        private async void ExecuteBtGuardID()
        {
            await _navigationService.NavigateToAsync<CadastroViewModel>();
        }       
    }

}
