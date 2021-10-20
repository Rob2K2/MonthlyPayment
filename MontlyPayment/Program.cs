using Common.Helpers;
using DataAccess.Settings;
using DataAccess.Users;
using Domain.Settings;
using Domain.Users;
using SimpleInjector;
using SimpleInjector.Diagnostics;
using System;
using System.Windows.Forms;

namespace MontlyPayment
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var container = Bootstrap();

            Application.Run(container.GetInstance<frmLogin>());
        }

        private static Container Bootstrap()
        {
            var container = new Container();

            container.Register<IUsersBL, UsersBL>();
            container.Register<IUsersDAL, UsersDAL>();
            container.Register<INumberLCD, NumberLCD>();
            container.Register<ISettingsBL, SettingsBL>();
            container.Register<ISettingsDAL, SettingsDAL>();

            AutoRegisterWindowsForms(container);

            container.Verify();

            return container;
        }

        private static void AutoRegisterWindowsForms(Container container)
        {
            var types = container.GetTypesToRegister<Form>(typeof(Program).Assembly);

            foreach (var type in types)
            {
                var registration =
                    Lifestyle.Transient.CreateRegistration(type, container);

                registration.SuppressDiagnosticWarning(
                    DiagnosticType.DisposableTransientComponent,
                    "Forms should be disposed by app code; not by the container.");

                container.AddRegistration(type, registration);
            }
        }
    }
}
