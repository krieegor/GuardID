using GuardID.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;
using static SQLite.SQLite3;

namespace GuardID.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class QrViewPage : ContentPage
	{
        ZXingBarcodeImageView barcode;        

        public QrViewPage ()
		{
			InitializeComponent ();
            BindingContext = new QrViewModel();            
        }

        private async void ScanCustomPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new QrCodeScannerViewPage());
        }

        private async void GenerateBarcode(object sender, EventArgs e)
        {
            try
            {
                qrResult.Content = null;
                ModificarQrCode();               
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                await DisplayAlert("Alert", "Introduzca el valor que desea convertir código QR", "OK");
            }
        }

        public void ModificarQrCode(string textoQr = "Implementar")
        {
            if (textoQr != string.Empty)
            {
                qrResult.Content = null;
                barcode = new ZXingBarcodeImageView
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                };
                barcode.BarcodeFormat = ZXing.BarcodeFormat.QR_CODE;
                barcode.BarcodeOptions.Width = 500;
                barcode.BarcodeOptions.Height = 500;
                barcode.BarcodeValue = textoQr.Trim();
                qrResult.Content = barcode;
            }
            else
            {
                DisplayAlert("Alert", "Introduzca el valor que desea convertir código QR", "OK");
            }           
        }
    }
}