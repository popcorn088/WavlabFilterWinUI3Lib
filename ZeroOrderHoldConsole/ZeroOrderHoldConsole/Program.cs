using WavlabFilterWinUI3Lib;

namespace ZeroOrderHoldConsole // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static async Task Main()
        {
            _ = await WavlabFilterClient.SendCoefsAsync(3000, 10, new CoefsData()
            {
                NumCoefs = new double[] { 0.2, 0.2, 0.2, 0.2, 0.2 },
                DenCoefs = Array.Empty<double>(),
            });
        }
    }
}