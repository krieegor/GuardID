using GuardID.Model.Services.ServicesViewModels;
using GuardID.Model.Services.ServiceViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace GuardID
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();
            DependencyService.Register<IMessageService,MessageServices>();
            DependencyService.Register<INavigationService, NavigationService>();


            //MainPage = new NavigationPage(new StartPage());
            MainPage = new NavigationPage(new View.QrViewPage());
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
