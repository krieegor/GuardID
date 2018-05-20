using GuardID.Model.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GuardID.ViewModel
{
	public class BaseViewModel :INotifyPropertyChanged
    {        
        public event PropertyChangedEventHandler PropertyChanged;
       
        protected virtual void OnPropertyChange([CallerMemberName]string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(propertyName)));
		}

		protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
		{
			if (EqualityComparer<T>.Default.Equals(storage, value))
			{
				return false;
			}
			storage = value;
			OnPropertyChange(propertyName);

			return true;
		}       
    }
}
