using System;
using System.Collections.Generic;
using System.Text;

namespace GuardID.ViewModel
{
    public class CadastroViewModel : BaseViewModel
    {
        public string  Background { get; set; }        
        public string Name { get; set; }     
        public string Color { get; set; }
        public string LogoIco1 { get; set; }

        public CadastroViewModel()
        {
            Background = Util.ImagePorSistema("background");
            LogoIco1 = Util.ImagePorSistema("LogoCadastro");
            Name = "Carousel 1";
            Color = "Red";
        }
    }
}
