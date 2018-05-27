using System;
using System.Collections.Generic;
using System.Text;

namespace GuardID.ViewModel
{
    public class QrViewModel
    {
        public string Background { get; set; }
        public string lblDescricao { get; set; }

        public string ImgCamera { get; set; }

        public QrViewModel()
        {
            Background = Util.ImagePorSistema("background");
            lblDescricao = $"Posicione sua camera sobre o código QR para confirmar a autenticidade do cidadão ou clique no botão abaixo para validar alguma identidade.";
            ImgCamera = Util.ImagePorSistema("ImgCamera");
        }
    }
}
