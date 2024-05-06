using System;
using WavlabFilterWinUI3Lib;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            WavlabFilterClient client = new WavlabFilterClient();
            client.SendCoefs(new double[] { 0.2, 0.2, 0.2, 0.2, 0.2 }, new double[0]);
        }
    }
}