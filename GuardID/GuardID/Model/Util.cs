using Xamarin.Forms;

namespace GuardID
{
    public class Util
    {
        public static string ImagePorSistema(string nmImage)
        {
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    return nmImage + ".png";
                case Device.Android:
                    return nmImage;
                case Device.UWP:
                    return "Imagens." + nmImage + ".png";
                default:
                    return null;
            }
        }
        public static string BuscaPrimeiroNome(string nome)
        {
            string[] Nm = nome.Split(' ');
            return Nm[0];

        }
    }
}
