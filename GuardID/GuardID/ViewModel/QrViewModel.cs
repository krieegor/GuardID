using GuardID.Model.Services.ServicesViewModels;
using GuardID.View;
using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing;
using ZXing.Net.Mobile.Forms;
using ZXing.QrCode;

namespace GuardID.ViewModel
{
    public class QrViewModel : BaseViewModel
    {
        #region Propriedades        
        public string Background { get; set; }
        public string LblDescricao { get; set; }
        public string ImgCamera { get; set; }
        public Command BtnLeitorQr { get; set; }
        #endregion
        public Command BtnGeraQrCode { get; set; }
        private  ZXingBarcodeImageView valueQrCode;
        public ZXingBarcodeImageView ValueQrCode
        {
            get { return valueQrCode; }
            set {SetProperty(ref valueQrCode , value); }
        }

        private readonly INavigationService _navigationService;

        public string teste { get; set; }
        public QrViewModel()
        {
            Background = Util.ImagePorSistema("background");
            LblDescricao = $"Posicione sua camera sobre o código QR para confirmar a autent" +
                $"icidade do cidadão ou clique no botão abaixo para validar alguma identidade.";
            ImgCamera = Util.ImagePorSistema("ImgCamera");

            BtnLeitorQr = new Command(LeitorQrAsync);
            //GeraQrCode();
            BtnGeraQrCode = new Command(GeraQrCode);

            _navigationService = DependencyService.Get<INavigationService>();
        }

        private async void LeitorQrAsync()
        {
            var scanner = new ZXing.Mobile.MobileBarcodeScanner();
            var result = await scanner.Scan();
            if(result != null)
                await App.Current.MainPage.DisplayAlert("Valor", $"Leitura do codigo: { result.Text}", "OK");
        }

        private void GeraQrCode()
        {            
            try
            {
                //ResultQrViewPage qr = new ResultQrViewPage
                //{
                //    Content = GenerateQR()
                //};

                PageModelo pm = new PageModelo(GenerateQR());
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                App.Current.MainPage.DisplayAlert("Alert", "Introduzca el valor que desea convertir código QR", "OK");
            }
        }

        ZXingBarcodeImageView GenerateQR(string codeValue = "Implementar")
        {
            if (codeValue != string.Empty)
            {
                ValueQrCode = new ZXingBarcodeImageView
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                };
                ValueQrCode.BarcodeFormat = BarcodeFormat.QR_CODE;
                ValueQrCode.BarcodeOptions.Width = 500;
                ValueQrCode.BarcodeOptions.Height = 500;
                ValueQrCode.BarcodeValue = codeValue.Trim();
                return ValueQrCode;
            }
            else
            {                
                App.Current.MainPage.DisplayAlert("Alert", "Introduzca el valor que desea convertir código QR", "OK");
                return null;
            }           
        }

        public BinaryBitmap GenerateQR(int width, int height, string text)
        {
            var bw = new BarcodeWriter<Binarizer>();
            var encOptions = new ZXing.Common.EncodingOptions() { Width = width, Height = height, Margin = 0 };
            bw.Options = encOptions;
            bw.Format = BarcodeFormat.QR_CODE;
            var result = new BinaryBitmap(bw.Write(text));

            return result;
        }       

    }
}
