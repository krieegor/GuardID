using GuardID.View;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace GuardID.ViewModel
{
    public class CadastroViewModel : BaseViewModel
    {
        public string Background { get; set; }
        public string Title { get; set; }
        public string LogoIco1 { get; set; }
        public string LogoIco2 { get; set; }
        public string ImgGeneroF { get; set; }
        public string imgGeneroM { get; set; }
        public string titleGenero { get; set; }
        public Command ForwadPageSwitch;
        public string LblNome { get; set; }
        public string LblCpf { get; set; }
        public string LblIdade { get; set; }
        public string LblEndereco { get; set; }
        private Color colorClickF;
        public Color ColorClickF
        {
            get { return colorClickF; }
            set { SetProperty(ref colorClickF, value); }
        }
        private string nome;
        public string Nome
        {
            get { return "Lucas Ranuzi Rocha"; }
            set { nome = value; }
        }

        private int idade;
        public int Idade
        {
            get { return 23; }
            set { idade = value; }
        }

        public string ImgSexoSelecionado { get; set; }


        //private string _txtCpf;
        //public string TxtCpf
        //{
        //    get { return _txtCpf; }
        //    set
        //    {
        //        SetProperty(ref _txtCpf, Format(value));
        //    }
        //}

        public Command CommandClickF { get; set; }        
        //public Command BtnProsseguir { get; set; }

        public Command MaskFormat { get; set; }

        public CadastroViewModel()
        {
            Background = Util.ImagePorSistema("background");
            LogoIco1 = Util.ImagePorSistema("LogoCadastro");
            LogoIco2 = Util.ImagePorSistema("LogoCadastroN");
            ImgGeneroF = Util.ImagePorSistema("mulher01tracado");
            imgGeneroM = Util.ImagePorSistema("homem1tracado");
            ImgSexoSelecionado = Util.ImagePorSistema("homem1");

            Title = "Boas vindas ao futuro";
            titleGenero = "SELECIONE SEU GENÊRO";
            LblCpf = "DIGITE SEU CPF";
            //TODO Alterar para pegar o nome que for o CPF 
            LblNome = $"Olá, {Util.BuscaPrimeiroNome(Nome)}";
            LblIdade = $"{Idade} Anos";
            LblEndereco = $"Onde você mora , {Util.BuscaPrimeiroNome(Nome)}";

            ColorClickF =   Color.Transparent;                     
           
            ForwadPageSwitch = new Command(ForwadPage);
            CommandClickF = new Command(ClickF);
            //BtnProsseguir = new Command(ForwadPage);

            //TxtCpf = Format(TxtCpf);
        }
       
        private void ClickF()
        {
            if(!ColorClickF.Equals(Color.Transparent))
                ColorClickF =  Color.FromHex("#0078FF");
            else
                ColorClickF = Color.Transparent;
            ColorClickF = new Color(0, 0, 0);
        }

        private async void ForwadPage()
        {
          
        }

        # region Para Mascara de CPF 
        //
        //private string Format(string input)
        //{            
        //    var digitsRegex = new Regex(@"[^d]");
            
        //    if (!string.IsNullOrWhiteSpace(input))
        //    {                
        //        return FormatCPF(input);
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        //private string FormatCPF(string digits)
        //{
        //    digits = digits.PadRight(10);
        //    if (digits.Length > 11)
        //    {
        //        digits = digits.Remove(11);
        //    }
        //    digits = digits.Insert(3, ".").Insert(7, ".").Insert(11, "-").TrimEnd(new char[] { ' ', '.', '-' });
        //    return digits;
        //}
        #endregion

    }
}
