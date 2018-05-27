using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace GuardID
{
    public class DocumentoMascara : Entry
    {
        public static readonly BindableProperty DocumentTypeProperty =
        BindableProperty.Create(nameof(DocumentType), typeof(string), typeof(DocumentoMascara), string.Empty);

        public string DocumentType
        {
            get { return (string)GetValue(DocumentTypeProperty); }
            set { SetValue(DocumentTypeProperty, value); }
        }

        public DocumentoMascara()
        {
            TextChanged += DocumentFormatterBehavior_TextChanged;
        }

        private void DocumentFormatterBehavior_TextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = ((Entry)sender);
            entry.Text = Format(entry);
        }
        private string Format(Entry entry)
        {
            string input = entry.Text;
            var digitsRegex = new Regex(@"[^d]");
            var digits = digitsRegex.Replace(input, "");
            if (DocumentType == "J")
            {
                return FormatCNPJ(digits);
            }
            else
            {
                return FormatCPF(digits);
            }
        }
        private string FormatCNPJ(string digits)
        {
            digits = digits.PadRight(13);
            if (digits.Length > 14)
            {
                digits = digits.Remove(14);
            }
            digits = digits.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(15, "-").TrimEnd(new char[] { ' ', '.', '/', '-' });
            return digits;
        }
        private string FormatCPF(string digits)
        {
            digits = digits.PadRight(10);
            if (digits.Length > 11)
            {
                digits = digits.Remove(11);
            }
            digits = digits.Insert(3, ".").Insert(7, ".").Insert(11, "-").TrimEnd(new char[] { ' ', '.', '-' });
            return digits;
        }
    }
}
