using Newtonsoft.Json;

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
