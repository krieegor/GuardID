using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;

namespace GuardID.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class QrCodeScannerViewPage : ContentPage
	{
        public QrCodeScannerViewPage ()
		{
			InitializeComponent ();

		}

        private async void ZXingScannerView_OnOnScanResult(Result result)
        {
            // Stop analysis until we navigate away so we don't keep reading barcodes
            zxing.IsAnalyzing = false;

            // Show an alert
            await DisplayAlert("Scanned Barcode", result.Text, "OK");

            // Navigate away
            await Navigation.PopAsync();
        }

        private void Overlay_OnFlashButtonClicked(Button sender, EventArgs e)
        {
            zxing.IsTorchOn = !zxing.IsTorchOn;

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            zxing.IsScanning = true;
        }

        protected override void OnDisappearing()
        {
            zxing.IsScanning = false;

            base.OnDisappearing();
        }
    }
}