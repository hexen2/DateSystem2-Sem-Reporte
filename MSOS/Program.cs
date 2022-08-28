using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DateSystem
{

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //Application.Run(new FormPrincipal());
                //Application.Run(new FormLoginUsuario());
                //Application.Run(new FormCadastraProdutos());


                //Application.Run(new FormTeste());


                FormLoginUsuario LoginUsuario = new FormLoginUsuario();
                LoginUsuario.ShowDialog();
                if (LoginUsuario.logado == true)
                {
                    LoginUsuario.Nome.ToString();
                    LoginUsuario.connectionString.ToString();

                    Application.Run(new FormPrincipal(LoginUsuario.Nome.ToString(), LoginUsuario.connectionString.ToString()));
                }
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
        }
    }
}
