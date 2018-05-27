using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace GuardID
{
    public class DocumentoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public List<TipoDocumento> TiposDocumento { get; set; }
        private TipoDocumento _tipoDocumento;
        public TipoDocumento TipoDocumento
        {
            get { return _tipoDocumento; }
            set
            {
                if (_tipoDocumento != value)
                {
                    _tipoDocumento = value;
                    Documento = string.Empty;
                    NotifyPropertyChanged();
                }
            }
        }
        private string _documento;
        public string Documento
        {
            get { return _documento; }
            set
            {
                if (_documento != value)
                {
                    _documento = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public DocumentoViewModel()
        {
            LoadTiposDocumentos();
        }
        public void LoadTiposDocumentos()
        {
            TiposDocumento = new List<TipoDocumento>(TipoDocumento.GetTiposDocumentos());
        }
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
