using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wifi.PlaylistEditor.Factories;
using Wifi.PlaylistEditor.Types;

namespace Wifi.PlaylistEditor.UI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var builder = new ContainerBuilder();

            builder.RegisterType<DummyDataProvider>().As<INewPlaylistDataProvider>();
            builder.RegisterType<PlaylistFactory>().As<IPlaylistFactory>();
            builder.RegisterType<PlaylistItemFactory>().As<IPlaylistItemFactory>();
            builder.RegisterType<RepositoryFactory>().As<IRepositoryFactory>();            
            builder.RegisterType<frm_Main>();

            var container = builder.Build();

            var mainForm = container.Resolve<frm_Main>();

            //var repositoryFactory = container.Resolve<IRepositoryFactory>();

            Application.Run(mainForm);
        }
    }
}
