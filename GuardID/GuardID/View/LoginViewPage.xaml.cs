using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuardID.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginViewPage : ContentPage
	{

		public LoginViewPage ()
		{
			InitializeComponent ();
            this.BindingContext = new ViewModel.LoginViewModel();
		}
	}
}