using System.Text;
using System.Data;
using Classes.Conexoes;

namespace Classes.Autenticacoes
{
	public class Autenticacao
    {
        public bool AutenticaTemporiaUsuario()
        {
            try
            {
                int usuario;
                string senha, conexao;
                Globals.Conexao = "Guardid";
                Globals.Usuario = 0001;
                Globals.Login = "";

                Conexao dal = new Conexao(Globals.GetStringConnection(), 2);

                if (!dal.TestaConexao())
                {
                    Globals.Usuario = 0;
                    Globals.Login = string.Empty;
                    return false;
                }
                else
                {
                    StringBuilder sql = new StringBuilder();

                    sql.Append(" ");

                    DataTable dt = dal.ExecuteQuery(sql.ToString());

                    if (dt.Rows.Count == 0)
                    {
                        Globals.Usuario = 0;
                        Globals.Login = string.Empty;
                        return false;
                    }

                    // 1 Usuário não autenticado
                    if (dt.Rows[0]["AUTENTICACAO"].ToString() == "1")
                    {
                        Globals.Usuario = 0;
                        Globals.Login = string.Empty;
                        return false;
                    }

                    // 2 Problema ao buscar autenticação do usuario
                    if (dt.Rows[0]["AUTENTICACAO"].ToString() == "2")
                    {
                        Globals.Usuario = 0;
                        Globals.Login = string.Empty;
                        return false;
                    }

                    string autenticacao = dt.Rows[0]["AUTENTICACAO"].ToString();

                    usuario = int.Parse(autenticacao.Substring(0, autenticacao.IndexOf(" | ")));
                    senha = autenticacao.Substring(autenticacao.IndexOf(" | ") + 3, (autenticacao.LastIndexOf(" | ") - 3) - (autenticacao.IndexOf(" | ")) + 1);
                    conexao = autenticacao.Substring(autenticacao.LastIndexOf(" | ") + 3);

                    if (!Seguranca.BuscaAutenticacaoUsuario(usuario, senha, conexao))
                    {
                        Globals.Usuario = 0;
                        Globals.Login = string.Empty;
                        return false;
                    }
                    else
                        return true;

                }
            }
            catch
            {
                Globals.Usuario = 0;
                Globals.Login = string.Empty;
                return false;
            }
            
        }
    }
}
