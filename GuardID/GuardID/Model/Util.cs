using Xamarin.Forms;

namespace GuardID
{
    public class Util
    {
        public static string ImagePorSistema(string NmImage)
        {
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    return NmImage + ".png";
                case Device.Android:
                    return NmImage;
                case Device.UWP:
                    return "Imagens." + NmImage + ".png";
                default:
                    return null;
            }
        }
    }
}
