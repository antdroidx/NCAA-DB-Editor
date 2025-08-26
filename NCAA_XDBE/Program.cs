using System;
using System.Windows.Forms;

namespace DB_EDITOR
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
            ApplicationConfiguration.Initialize();
            Application.Run(new MainEditor());
        }
    }
}
