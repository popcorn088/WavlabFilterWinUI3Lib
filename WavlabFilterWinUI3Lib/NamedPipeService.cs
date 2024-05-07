using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WavlabFilterWinUI3Lib
{
    public class WavlabFilterClient
    {
        NamedPipeClientStream pipeClient = null;
        public async Task SendCoefs(double[] numCoefs, double[] denCoefs)
        {
            string message = numCoefs.Length.ToString();
            for (int i = 0; i < numCoefs.Length; i++)
            {
                message += "," + numCoefs[i].ToString();
            }
            message += "," + denCoefs.Length.ToString();
            for (int i = 0; i < denCoefs.Length; i++)
            {
                message += "," + denCoefs[i].ToString();
            }

            await SendMessage(message);
        }
        private async Task SendMessage(string message)
        {
            using (pipeClient = new NamedPipeClientStream(".", "WavlabFilter", PipeDirection.Out, PipeOptions.Asynchronous | PipeOptions.CurrentUserOnly, System.Security.Principal.TokenImpersonationLevel.Impersonation))
            {
                await pipeClient.ConnectAsync();
                using (var writer = new StreamWriter(pipeClient))
                {
                    await writer.WriteLineAsync(message);
                    await writer.FlushAsync();
                }
            }

        }
    }
}
