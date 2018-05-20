using GuardID.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuardID.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageModelo : ContentPage
	{
		public PageModelo ()
		{
			InitializeComponent ();
            BindingContext = new CadastroViewModel();
		}
	}
}