using GuardID.View;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace GuardID.ViewModel
{
    public class CadastroViewModel : BaseViewModel
    {
        public string Background { get; set; }
        public string Name { get; set; }
        public string LogoIco1 { get; set; }
        public string LogoIco2 { get; set; }
        public string ImgGeneroF { get; set; }
        public string imgGeneroM { get; set; }
        public string titleGenero { get; set; }
        public Command ForwadPageSwitch;
        private Color visivelF;
        public Color VisivelF
        {
            get { return visivelF; }
            set { SetProperty(ref visivelF , value); }
        }

        private Color colorClickF;
        public Color ColorClickF
        {
            get { return colorClickF; }
            set { SetProperty(ref colorClickF, value); }
        }

        public Command CommandClickF { get; set; }
        public CadastroViewModel()
        {
            Background = Util.ImagePorSistema("background");
            LogoIco1 = Util.ImagePorSistema("LogoCadastro");
            LogoIco2 = Util.ImagePorSistema("LogoCadastroN");
            ImgGeneroF = Util.ImagePorSistema("mulher01tracado");
            imgGeneroM = Util.ImagePorSistema("homem1tracado");

            Name = "Boas vindas ao futuro";
            titleGenero = "SELECIONE SEU GENÊRO";

            ColorClickF =  new Color(0,120,255);
            VisivelF = new Color(100, 120, 255);            
           
            ForwadPageSwitch = new Command(ForwadPage);
            CommandClickF = new Command(ClickF);
        }

        private void ClickF()
        {
            if(!VisivelF.R.ToString().Equals("0") && !VisivelF.G.ToString().Equals("0") && !VisivelF.B.ToString().Equals("0"))
                VisivelF =  new Color(0, 0, 0);
            else
                VisivelF = new Color(0, 200, 200);
            ColorClickF = new Color(0, 0, 0);
        }

        private async void ForwadPage()
        {                        
           
        }       
    }
}
