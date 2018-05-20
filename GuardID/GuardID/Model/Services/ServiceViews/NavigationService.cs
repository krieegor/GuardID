using System;
using System.Globalization;
using System.Reflection;
using System.Threading.Tasks;
using GuardID.ViewModel;
using Xamarin.Forms;

namespace GuardID.Model.Services.ServicesViewModels
{
    public class NavigationService : INavigationService
    {
        public Task InitializeAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel
        {
            await App.Current.MainPage.Navigation.PushAsync(CreatePage(typeof(TViewModel), null));
        }

        public async Task NavigateToAsync<TViewModel>(object[] parameter) where TViewModel : BaseViewModel
        {
            await App.Current.MainPage.Navigation.PushAsync(CreatePage(typeof(TViewModel), parameter));
        }              

        public Task RemoveBackStackAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveLastFromBackStackAsync()
        {
            throw new System.NotImplementedException();
        }

        private Type GetPageTypeForViewModel(Type viewModelType)
        {
            var viewName = viewModelType.FullName.Replace("Model", string.Empty)+"Page";
            var viewModelAssemblyName = viewModelType.GetTypeInfo().Assembly.FullName;
            var viewAssemblyName = string.Format(
                        CultureInfo.InvariantCulture, "{0}, {1}", viewName, viewModelAssemblyName);
            var viewType = Type.GetType(viewAssemblyName);
            return viewType;
        }

        private Page CreatePage(Type viewModelType, object parameter)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);
            if (pageType == null)
            {
                throw new Exception($"Cannot locate page type for {viewModelType}");
            }

            Page page = Activator.CreateInstance(pageType) as Page;
            return page;
        }
    }
}
