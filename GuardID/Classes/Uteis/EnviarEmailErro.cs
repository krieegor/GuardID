using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using Devart.Data.Oracle;
using Classes.Autenticacoes;
using Classes.Conexoes;

namespace Classes.Uteis
{
	public static class EnviarEmailErro
    {
        /// <summary>
        /// Envia email de erro - pelo codigo do sistema
        /// </summary>
        /// <param name="erro">Exceção ocorrida</param>
        /// <param name="nomeProcesso">Processo que o erro ocorreu</param>
        /// <param name="codigoSistema">Codigo do sistema executado</param>
        /// <param name="desconsiderarErrosIntegridade">Adiciona os codigos de erro de integridade do oracle na lista de erros a desconsiderar</param>
        /// <param name="listErrosDesconderar">Lista de erros (ex: oracle) que serão desconsiderados no envio, caso a mensage e/ou innerException no exception contenha</param>
        public static void EnviaEmailErro(Exception erro, string nomeProcesso, int codigoSistema, Boolean desconsiderarErrosIntegridade = false, List<string> listErrosDesconderar = null)
        {
            string conexaoAnterior = Globals.Conexao;

            try
            {
                if (Globals.Conexao == "MVPRD")
                    Globals.Conexao = "ACAD";

                if (validaEnvio(erro, desconsiderarErrosIntegridade, listErrosDesconderar))
                {
                    DataTable dtRemetente = buscaRemetente();
                    DataTable dtSistema = buscaSistema(codigoSistema);
                    DataTable dtDestinatarios = buscaDestinatarios(dtSistema.Rows[0]["SISTEMA"].ToString());
                    sendEmail(dtRemetente, dtSistema, dtDestinatarios, erro, nomeProcesso);
                }
            }
            catch (Exception)
            {
                //SOMENTE PARA NAO TRAVAR O SISTEMA
            }
            finally
            {
                Globals.Conexao = conexaoAnterior;
            }
        }

        /// <summary>
        /// Envia email de erro - pelo codigo de segurança
        /// </summary>
        /// <param name="erro">Exceção ocorrida</param>
        /// <param name="nomeProcesso">Processo que o erro ocorreu</param>
        /// <param name="codigoSeguranca">Codigo de segurança do programa</param>
        /// <param name="desconsiderarErrosIntegridade">Adiciona os codigos de erro de integridade do oracle na lista de erros a desconsiderar</param>
        /// <param name="listErrosDesconderar">Lista de erros (ex: oracle) que serão desconsiderados no envio, caso a mensage e/ou innerException no exception contenha</param>
        public static void EnviaEmailErro(Exception erro, string nomeProcesso, string codigoSeguranca, Boolean desconsiderarErrosIntegridade = false, List<string> listErrosDesconderar = null)
        {
            string conexaoAnterior = Globals.Conexao;

            try
            {
                if (Globals.Conexao == "MVPRD")
                    Globals.Conexao = "ACAD";

                if (validaEnvio(erro, desconsiderarErrosIntegridade, listErrosDesconderar))
                {
                    DataTable dtRemetente = buscaRemetente();
                    DataTable dtSistema = buscaSistemaByPrograma(codigoSeguranca);
                    DataTable dtDestinatarios = buscaDestinatarios(dtSistema.Rows[0]["SISTEMA"].ToString());
                    sendEmail(dtRemetente, dtSistema, dtDestinatarios, erro, nomeProcesso);
                }
            }
            catch (Exception e)
            {
                //SOMENTE PARA NAO TRAVAR O SISTEMA
                MessageBox.Show(e.Message + (e.InnerException != null ? e.InnerException.Message : ""));
            }
            finally
            {
                Globals.Conexao = conexaoAnterior;
            }
        }

        private static Boolean validaEnvio(Exception erro, Boolean desconsiderarErrosIntegridade, List<string> listErrosDesconderar)
        {
            Boolean retorno = true;
            if (desconsiderarErrosIntegridade)
            {
                listErrosDesconderar.Add("ORA-00001"); // O registro que você está tentando inserir já existe.
                listErrosDesconderar.Add("ORA-02292"); // Existem outros registros no banco de dados que estão vinculados a este registro. Para excluir este registro é preciso primeiramente remover todos seus vínculos
            }
            
            if ((listErrosDesconderar != null) && (listErrosDesconderar.Count > 0))
            {
                foreach (string sErro in listErrosDesconderar)
                {
                    if (erro.Message.ToUpper().Contains(sErro.ToUpper()))
                        retorno = false;

                    if ((erro.InnerException != null) && (erro.InnerException.ToString().ToUpper().Contains(sErro.ToUpper())))
                        retorno = false;
                }
            }
            return retorno;
        }

        private static void sendEmail(DataTable dtRemetente, DataTable dtSistema, DataTable dtDestinatarios, Exception erro, string nomeProcesso)
        {
            string conexaoAnterior = Globals.Conexao;

            if (Globals.Conexao == "MVPRD")
                Globals.Conexao = "ACAD";

            if (Globals.Conexao == "ACAD")
            {
                string assunto = "";
                StringBuilder corpoEmail = new StringBuilder();
                
                if (dtRemetente.Rows.Count != 0)
                {                  
                    if (dtSistema.Rows.Count != 0)
                    {
                        corpoEmail.Append(@"Processo executado por " + Globals.Usuario + " - " + Globals.NomeUsuario + " em: " + Globals.Sysdate +
                                            @"<br><br>
                                " + (dtSistema.Rows[0]["DESC_PROGRAMA"].ToString() != null ? ("Programa: " + dtSistema.Rows[0]["PROGRAMA"].ToString() + " - " + dtSistema.Rows[0]["DESC_PROGRAMA"].ToString() + "<br><br>") : "")
                                      + nomeProcesso + @"
                                <br><br>
                                Erro: " + erro.Message + @"<br>
                                InnerException: " + (erro.InnerException != null ? erro.InnerException.Message : "") + "<br><br>");

                        assunto = "ATENÇÃO! ERRO: " + dtSistema.Rows[0]["DESC_SISTEMA"].ToString();

                        List<string> destinatarios = new List<string>();
                        if (dtDestinatarios.Rows.Count != 0)
                        {
                            foreach (DataRow dtRow in dtDestinatarios.Rows)
                            {
                                destinatarios.Add(dtRow["DESTINATARIO"].ToString());                                
                            }
                            
                            long codigoEmail = insereEmail(dtSistema.Rows[0]["DESC_SISTEMA"].ToString(), dtRemetente.Rows[0]["EMAIL"].ToString(),
                                                          string.Join(", ", destinatarios.ToArray()), assunto, 2, "REQOCORRENCIA",
                                                          10, 1, corpoEmail.ToString(), PrintScreen());
                            //executaProcessoEnviaEmail(codigoEmail);
                        }
                    }
                }
            }

            Globals.Conexao = conexaoAnterior;
        }

        private static string PrintScreen()
        {
            string caminho;
            string data = Globals.Sysdate.Date.ToString().Substring(0, 10);
            data = data.Replace("/", "_");
            string time = Globals.Sysdate.ToLongTimeString();
            time = time.Replace(":", "_");
            caminho = @"C:\Temp\erro" + data + "_" + time + ".jpg";

            //FocusPrograma();
            Bitmap printscreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            Graphics graphics = Graphics.FromImage(printscreen as Image);

            graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);

            printscreen.Save(caminho, ImageFormat.Jpeg);
            return caminho;
        }

        private static DataTable buscaRemetente()
        {
            StringBuilder sql = new StringBuilder();
            Conexao dal = new Conexao(Globals.GetStringConnection(), 2);

            sql.Append(@"");
            return dal.ExecuteQuery(sql.ToString());
        }

        private static DataTable buscaSistema(int codigoSistema)
        {
            StringBuilder sql = new StringBuilder();
            Conexao dal = new Conexao(Globals.GetStringConnection(), 2);

            sql.Append(@"");

            return dal.ExecuteQuery(sql.ToString());
        }

        private static DataTable buscaSistemaByPrograma(string codigoSeguranca)
        {
            StringBuilder sql = new StringBuilder();
            Conexao dal = new Conexao(Globals.GetStringConnection(), 2);

            sql.Append(@"");

            return dal.ExecuteQuery(sql.ToString());
        }

        private static DataTable buscaDestinatarios(string codigoSistema)
        {
            StringBuilder sql = new StringBuilder();
            Conexao dal = new Conexao(Globals.GetStringConnection(), 2);

            sql.Append(@"");

            return dal.ExecuteQuery(sql.ToString());
        }

     

        /// <summary>
        /// Insere o e-mail no banco de dados para posterior envio
        /// </summary>
        /// <param name="remetente">Nome do remetente</param>
        /// <param name="email_remetente">E-mail do remetente</param>
        /// <param name="email_destinatario">E-mail de destinatário - caso seja mais que 1 informar separado por virgula</param>
        /// <param name="assunto">Assunto do e-mail</param>
        /// <param name="tipo_mensagem">Tipo da mensagem: 1 - Texto, 2 - HTML</param>
        /// <param name="identificador">Utilizado para enviar e-mail em lote, informar o nome do sistema</param>
        /// <param name="credencial">Credendial de autorização para envio de e-mail</param>
        /// <param name="prioridade">Prioridade: 1 - normal, 2 - alta, 3 - baixa</param>
        /// <param name="corpo_mensagem">Corpo da mensagem</param>
        private static long insereEmail(string remetente, string email_remetente, string email_destinatario, 
                                 string assunto, int tipo_mensagem, string identificador, int credencial, 
                                 int prioridade, string corpo_mensagem, string localAnexo)
        {
            long codigoEmail = -1;
            OracleConnection conexao = new OracleConnection(Globals.GetStringConnection());
            OracleCommand comando = new OracleCommand();
            OracleTransaction transacao = null;

            //Abre Conexão e Inicia Transação
            try
            {
                if (conexao.State == ConnectionState.Closed)
                    conexao.Open();
                comando.Connection = conexao;
            }
            catch (Exception ex)
            {
                comando.Parameters.Clear();
                conexao.Close();
                throw new Exception("Não foi possível estabelecer conexão.\nMotivo: " + ex.Message);
            }

            try
            {
                transacao = conexao.BeginTransaction();
                comando.Transaction = transacao;
                OracleDataAdapter oda = new OracleDataAdapter(comando);
                comando.Parameters.Add(new OracleParameter("remetente",remetente));
                comando.Parameters.Add(new OracleParameter("email_remetente", email_remetente));
                comando.Parameters.Add(new OracleParameter("email_destinatario", email_destinatario));
                comando.Parameters.Add(new OracleParameter("assunto", assunto));
                comando.Parameters.Add(new OracleParameter("tipo_mensagem", tipo_mensagem));
                comando.Parameters.Add(new OracleParameter("identificador", identificador));
                comando.Parameters.Add(new OracleParameter("credencial", credencial));
                comando.Parameters.Add(new OracleParameter("prioridade", prioridade));
                comando.Parameters.Add(new OracleParameter("corpo_mensagem", corpo_mensagem));
                                
                //INSERIDO O E-MAIL
                StringBuilder ins = new StringBuilder();
                ins.Append(@"");
                comando.CommandText = ins.ToString();
                comando.ExecuteNonQuery();

                //BUSCANDO E-MAIL INSERIDO
                comando.Parameters.Clear();
                StringBuilder sel = new StringBuilder();
                sel.Append(@"");

                DataTable dtEmail = new DataTable();
                comando.CommandText = sel.ToString();
                comando.ExecuteNonQuery();
                oda.Fill(dtEmail);
                codigoEmail = long.Parse(dtEmail.Rows[0]["EMAIL"].ToString());

                //INSERINDO O ANEXO
                ins.Clear();
                ins.Append(@"");
                comando.Parameters.Add(new OracleParameter("email", codigoEmail));
                comando.Parameters.Add(new OracleParameter("item", 1));
                comando.Parameters.Add(new OracleParameter("arquivo", convertFileToByteArray(localAnexo)));
                comando.Parameters.Add(new OracleParameter("nome_arquivo", localAnexo.Substring(localAnexo.IndexOf("\\",3)+1)));
                comando.CommandText = ins.ToString();
                comando.ExecuteNonQuery();

                transacao.Commit();                
            }
            catch (Exception ex)
            {
                if (transacao != null)
                    transacao.Rollback();
                comando.Parameters.Clear();
                conexao.Close();
                throw new Exception("Processo abortado.\nMotivo: " + ex.Message);
            }
            finally
            {
                if (conexao != null)
                {
                    if (conexao.State == ConnectionState.Open)
                    {
                        conexao.Close(); //Fechando Conexão
                    }
                }
            }
            return codigoEmail;
        }

      

        /// <summary>
        /// Converte um arquivo em vetor de bytes (util para gravar arquivos no banco) 
        /// </summary>
        /// <param name="fileName">Local com o nome onde o arquivo esta salvo</param>        
        public static byte[] convertFileToByteArray(string fileName)
        {
            //referência: http://www.digitalcoding.com/Code-Snippets/C-Sharp/C-Code-Snippet-Convert-file-to-byte-array.html 

            byte[] _Buffer = null;

            try
            {
                // Open file for reading 
                System.IO.FileStream _FileStream = new System.IO.FileStream(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);

                // attach filestream to binary reader 
                System.IO.BinaryReader _BinaryReader = new System.IO.BinaryReader(_FileStream);

                // get total byte length of the file 
                long _TotalBytes = new System.IO.FileInfo(fileName).Length;

                // read entire file into buffer 
                _Buffer = _BinaryReader.ReadBytes((Int32)_TotalBytes);

                // close file reader 
                _FileStream.Close();
                _FileStream.Dispose();
                _BinaryReader.Close();
            }
            catch (Exception _Exception)
            {
                // Error 
                Console.WriteLine("Exception caught in process: {0}", _Exception.ToString());
            }

            return _Buffer;
        }
    }
}
