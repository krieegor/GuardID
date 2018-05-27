using GuardID.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuardID.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CadastroViewPage : CarouselPage
	{
        private int currentPage;

        public int _CurrentPage
        {
            get { return currentPage; }
            set { currentPage = value; }
        }
        public int SelectedIndex
        {
            get
            {
                return (int)CarouselCadastro.SelectedItem;
            }
        }

        public CadastroViewPage ()
		{
			InitializeComponent ();
            BindingContext = new CadastroViewModel();            
		}
      
        public void NextCadA_Clicked(object sender, System.EventArgs e)
        {
            Device.BeginInvokeOnMainThread((System.Action)(() =>
            {
                if (currentPage == Children.Count)
                {
                    currentPage = 0;
                }
                else
                {
                    currentPage++;
                }

                this.CurrentPage = this.Children[currentPage];
            }));
        }

        private void NextCadB_Clicked(object sender, System.EventArgs e)
        {

        }       
    }
}