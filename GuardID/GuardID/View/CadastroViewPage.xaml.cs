﻿
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuardID.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CadastroViewPage : CarouselPage
	{
		public CadastroViewPage ()
		{
			InitializeComponent ();
            BindingContext = new CadastroViewPage();
		}
	}
}