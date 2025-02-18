using Assistr.ViewModels.Pages;
using Wpf.Ui.Controls;
using System.Text.Json;
using System.IO;
using Json.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace Assistr.Views.Pages
{
    public partial class DashboardPage : INavigableView<DashboardViewModel>
    {
        public DashboardViewModel ViewModel { get; }

        public DashboardPage(DashboardViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
        }
    
    public class RiotJson
    {
        public string rc_live { get; set; }
    }

        private void ProjectA_Launch_Click(object sender, RoutedEventArgs e)
        {
            // find the Riot Client Installs json and get the current executable from it
            string rci = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System)) + @"ProgramData\\Riot Games\\RiotClientInstalls.json";
            if (File.Exists(rci)) {
                // parse and convert to string for reading
                var rc_live = JObject.Parse(File.ReadAllText(rci)).GetValue("rc_live").ToString();
                Process.Start(new ProcessStartInfo { FileName = rc_live, Arguments = "--launch-product=valorant --launch-patchline=live" });
            }
            else
            {
                System.Windows.MessageBox.Show("Could not find RiotClientInstalls.json in ProgramData of the local drive! Assistr is not able to launch VALORANT.");
            }
        }
    }
}
