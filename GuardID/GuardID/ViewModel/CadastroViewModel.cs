using System;
using System.Collections.Generic;
using System.Text;

namespace GuardID.ViewModel
{
    public class CadastroViewModel : BaseViewModel
    {
        public string  background { get; set; }

        public CadastroViewModel()
        {
            background = Util.ImagePorSistema("background");
        }
    }
}
