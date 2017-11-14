using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RTAVisualiser.Interfaces;
using System.Windows.Forms;

namespace RTAVisualiser.App
{
    public class Raytracer : ITerminalInstruction
    {
        private RichTextBox TextBox { get; set; } = null;
        private IAppSettings AppSettings { get; set; } = null;
        public System.Diagnostics.Process Task { get; set; } = new System.Diagnostics.Process();

        public Raytracer(IAppSettings settings)
        {
            AppSettings = settings;

            Task.EnableRaisingEvents = true;
            Task.Exited += Task_Exited;
            Task.OutputDataReceived += (sender, args) => Console.WriteLine(args.Data);
            Task.ErrorDataReceived += (sender, args) => Console.WriteLine(args.Data);
        }

        public void Launch(string arguments = "")
        {
            Task.StartInfo.FileName = "cmd.exe";
            Task.StartInfo.CreateNoWindow = true;
            Task.StartInfo.UseShellExecute = false;
            Task.StartInfo.RedirectStandardOutput = true;
            Task.StartInfo.RedirectStandardError = true;
            Task.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            Task.StartInfo.Arguments = $"/C {AppSettings.RTAppExecutablePath} {arguments}";

            Console.WriteLine($"Launching {AppSettings.RTAppExecutablePath} {arguments}");
            Task.Start();
            Task.BeginOutputReadLine();
            Task.BeginErrorReadLine();
        }

        public void Task_Exited(object sender, EventArgs e)
        {
            Console.WriteLine("Raytracer - Process Closed");
            Task.CancelOutputRead();
            Task.CancelErrorRead();
        }
    }
}
