using GuardID.ViewModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;


namespace GuardID.ViewModel
{
	public class RotinasGerais : BaseViewModel
    {
		private Image _background;
	
		
		public Image Background
		{
			get { return _background; }
			private set { SetProperty(ref _background, value);  }
		}
		
		public string Descricao { get; set; }
		
		public RotinasGerais()
		{
			Descricao = "Realizando um teste de View Model";
			//Background =  new Image { Source = Device.OnPlatform(iOS: "background.png" ,Android:"background",WinPhone:"Imagens.ackground.png") };
		}	
	}
}
