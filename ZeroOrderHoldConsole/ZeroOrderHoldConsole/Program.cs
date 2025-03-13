using System;
using System.Threading.Tasks;
using WavlabFilterWinUI3Lib;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            _ = await WavlabFilterClient.SendCoefsAsync(3000, 10, new CoefsData()
            {
                NumCoefs = new double[] { 0.2, 0.2, 0.2, 0.2, 0.2 },
                DenCoefs = new double[0],
            });
        }
    }
}