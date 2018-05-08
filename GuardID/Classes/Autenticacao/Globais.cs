using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Data.EntityClient;
using Classes.Conexoes;

namespace Classes.Autenticacoes
{
	public static class Globals
    {
        private static string _login = string.Empty;
        private static int _usuario, _usuarioCarteira;
        private static string _nomeUsuario;
        private static string _conexao;
        private static DateTime _sysdate;
        private static string _programa;
        public enum CBanco { guardId };
        public static int Sistema { get; set; }
        public static string TituloSistema { get; set; }
        public static string ServerName { get; set; }
        /// <summary>
        /// Flag para utilizar ou não os direcionais para alterar páginas no relatório completo
        /// </summary>
        public static bool _UtilizarDirecionaisRel { get; set; }
        /// <summary>
        /// Flag para utilizar ou não as teclas de atalhos no relatório
        /// </summary>
        public static bool _UtilizarAtalhosRel { get; set; }


        public static string GetConectionString(string initStringConection, string endStringConection, string caminho = "")
        {
            ServerName = initStringConection;

            if (string.IsNullOrEmpty(caminho))
                caminho = GetPathToTNSNamesFile();

            TextReader leitor = new StreamReader(caminho);
            string stringConexao = "", linha;

            do
            {
                linha = leitor.ReadLine();
                if (linha.Contains(initStringConection))
                {
                    string aux = linha;
                    aux = aux.Replace(initStringConection, "");
                    do
                    {
                        stringConexao += aux;
                        aux = leitor.ReadLine();
                    } while (!aux.Contains(endStringConection));
                    linha = null;
                }
            } while (linha != null);

            leitor.Close();
            return stringConexao;
        }

        /// <summary>
        /// Gets TNSNames file path from system path
        /// </summary>
        /// <returns>TNSNames.ora file path</returns>
        private static string GetPathToTNSNamesFile()
        {
            string systemPath = Environment.GetEnvironmentVariable("Path");
            Regex reg = new Regex("[a-zA-Z]:\\\\[a-zA-Z0-9\\\\]*(oracle|app)[a-zA-Z0-9_.\\\\]*(?=bin)");
            MatchCollection col = reg.Matches(systemPath);

            string subpath = "network\\ADMIN\\tnsnames.ora";
            foreach (Match match in col)
            {
                string path = match.ToString() + subpath;
                if (File.Exists(path))
                    return path;
            }
            return string.Empty;
        }

        public static string GetStringConnection()
        {
            string stringConnection = string.Empty;
            if (Globals.Conexao == "localhost")
                stringConnection = "Data Source" + GetConectionString("localhost.guardId", "#FIMLOCALHOST#") + ";User Id=" + Globals.Usuario.ToString() + ";Password=" + Globals.Login;           
            return stringConnection;
        }

        public static string GetStringConnection(string pConexao, string pUsuario, string pLogin)
        {
            string stringConnection = string.Empty;
            if (pConexao == "localhost")
                stringConnection = "Data Source" + GetConectionString("localhost.guardId", "#FIMLOCALHOST#") + ";User Id=" + pUsuario + ";Password=" + pLogin;            
            return stringConnection;
        }

        public static string GetStringConnection(CBanco pBanco)
        {
            string stringConnection = string.Empty;

            if (pBanco == CBanco.guardId)
            {
                stringConnection = GetStringConnection();
            }            
            return stringConnection;
        }

        public static EntityConnectionStringBuilder GetStringConnectionEntity(string Metadata)
        {
            return GetStringConnectionEntity(Metadata, CBanco.guardId);
        }

        public static EntityConnectionStringBuilder GetStringConnectionEntity(string Metadata, CBanco pBanco)
        {
			EntityConnectionStringBuilder connStrBuild = new EntityConnectionStringBuilder
			{
				Metadata = Metadata,
				Provider = "Devart.Data.Oracle",
				ProviderConnectionString = GetStringConnection(pBanco)
			};
			return connStrBuild;
        }

        public static List<Seguranca> listaSeguranca;

        public static string Login
        {
            get { return Globals._login; }
            set { Globals._login = value; }
        }

        public static int Usuario
        {
            get { return Globals._usuario; }
            set { Globals._usuario = value; }
        }

        public static string NomeUsuario
        {
            get { return Globals._nomeUsuario; }
            set { Globals._nomeUsuario = value; }
        }

        public static string Conexao
        {
            get { return Globals._conexao; }
            set { Globals._conexao = value; }
        }

        public static DateTime Sysdate
        {
            get { return RetornaSysdate(); }
            set { Globals._sysdate = value; }
        }

        private static DateTime RetornaSysdate()
        {
            Conexao dal = new Conexao(GetStringConnection(), 2);
            StringBuilder sql = new StringBuilder();

            sql.Append(" SELECT SYSDATE AS DATAHORA FROM DUAL ");

            DataTable dt = new DataTable();
            dt = dal.ExecuteQuery(sql.ToString());

            if (dt.Rows.Count > 0)
            {
                return DateTime.Parse(dt.Rows[0]["DATAHORA"].ToString());
            }
            else
            {
                return new DateTime();
            }
        }

        public static string Programa
        {
            get { return Globals._programa; }
            set { Globals._programa = value; }
        }

        public static int UsuarioCarteira
        {
            get { return Globals._usuarioCarteira; }
            set { Globals._usuarioCarteira = value; }
        }
    }
}
