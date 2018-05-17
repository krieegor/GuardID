using GuardID.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuardID
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StartPage : ContentPage
	{
        public Image BackImage { get; set; }
        public StartPage()
        {
            BackImage = new Image
            {
                Source = "background",
            };
            InitializeComponent ();
			BindingContext = new RotinasGerais();
		}
	}
}