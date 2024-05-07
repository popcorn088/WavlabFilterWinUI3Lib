using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WavlabFilterWinUI3Lib.WavlabFilterClient client = new WavlabFilterWinUI3Lib.WavlabFilterClient();
            client.SendCoefs(new double[] { 0.2, 0.2, 0.2, 0.2, 0.2 }, new double[0]);
        }
    }
}