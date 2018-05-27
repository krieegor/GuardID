using System;
using System.Collections.Generic;
using System.Text;

namespace GuardID
{
    public class TipoDocumento
    {
        public string Sigla { get; set; }
        public string Descricao { get; set; }
        public static List<TipoDocumento> GetTiposDocumentos()
        {
            List<TipoDocumento> tiposDocumento = new List<TipoDocumento>
            {
            new TipoDocumento{ Sigla = "F" , Descricao = "CPF" },
            new TipoDocumento{ Sigla = "J", Descricao = "CNPJ"}
            };
            return tiposDocumento;
        }
    }
}
