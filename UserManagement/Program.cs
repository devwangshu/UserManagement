using System.Configuration;

namespace UserManagement
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //Application.Run(new SplashScreen());
            //Application.Run(new UserList());
            //ConfigurationManager.RefreshSection("appSettings");
            /*if (File.Exists("App.config"))
            {
                Application.Run(new SplashScreen());
            }
            else
            {
                MessageBox.Show("Please create a app.config file or contact to system admin");
                //Application.Run(new DatabaseConfig());
            }*/
            try
            {

                if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["MyKey"]))
                {
                    //config file doesn't exist..
                    //MessageBox.Show("Please create a app.config file or contact to system admin");
                    Application.Run(new DatabaseConfig());
                }
                else
                {
                    Application.Run(new SplashScreen());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Configuration settings."+ex.Message);
            }
        }
    }
}