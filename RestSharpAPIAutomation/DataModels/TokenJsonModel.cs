using Newtonsoft.Json;

namespace RestSharpAPIAutomation.DataModels
{
    public class TokenJsonModel
    {
        [JsonProperty("token")]
        public string Token { get; set; } = default!;
    }
}
