using System;
using System.IO;
using System.Windows.Forms;
using Classes.Autenticacoes;
using Classes.Uteis;

namespace Classes.Uteis
{
	public static class AbriFormularioDinamicamente
    {
        /// <summary>
        /// Recebe uma string para Abrir o Formulario
        /// </summary>
        /// <param name="Namespace_FormName">Nome do Namespace.NomeForm Ex: teste.Form1</param>
        /// <param name="System_Modal">True = ShowDialog / False = Show</param>
        public static void OpenForm(string Namespace_FormName, bool System_Modal)
        {
            Type t = Type.GetType(Namespace_FormName);

            if (t != null)
            {
                System.Windows.Forms.Form f =
                (System.Windows.Forms.Form)Activator.CreateInstance(t);

                if (System_Modal)
                    f.ShowDialog();
                else
                    f.Show();
            }
        }

       
    }
}
