using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RTAVisualiser.Interfaces;
using System.Windows.Forms;

namespace RTAVisualiser.App
{
    public class MagickImageProcessor : ITerminalInstruction
    {
        private IAppSettings AppSettings { get; set; } = null;
        public System.Diagnostics.Process Task { get; set; } = new System.Diagnostics.Process();

        public MagickImageProcessor(IAppSettings settings)
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
            Task.StartInfo.Arguments = $"/C .\\PPMtoJPG.cmd {arguments}";

            Console.WriteLine($"Launching .\\PPMtoJPG.cmd {arguments}");
            Task.Start();

            if (Task.HasExited)
            {
                Task.BeginOutputReadLine();
                Task.BeginErrorReadLine();
            }
        }

        private void Task_Exited(object sender, EventArgs e)
        {
            Console.WriteLine("Magick - Process Closed");
            if (!Task.HasExited)
            {
                Task.CancelOutputRead();
                Task.CancelErrorRead();
            }
        }
    }
}
