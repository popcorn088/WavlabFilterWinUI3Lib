using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WavlabFilterWinUI3Lib
{
    public static class WavlabFilterClient
    {

        public static Task<HttpResponseMessage> SendCoefsAsync(int portNumber, int timeoutSec, CoefsData coefsData)
        {
            var httpClient = new HttpClient
            {
                Timeout = new TimeSpan(0, 0, timeoutSec)
            };
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"http://localhost:{portNumber}/")
            };
            var json = JsonConvert.SerializeObject(coefsData);
            request.Content = new StringContent(json);

            return httpClient.SendAsync(request);
        }
    }
}
