using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WavlabFilterWinUI3Lib
{
    [JsonObject("CoefsData")]
    public sealed class CoefsData
    {
        [JsonProperty(nameof(NumCoefs))]
        public double[] NumCoefs { get; set; }
        [JsonProperty(nameof(DenCoefs))]
        public double[] DenCoefs { get; set; }
    }
}
