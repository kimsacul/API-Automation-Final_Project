using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientAPIAutomation.Resources
{
    public class Endpoints
    {
        public const string baseUrl = "https://restful-booker.herokuapp.com";

        public const string BookerEndpoint = "/booking";

        public const string TokenEndpoint = "/auth";

        public static string GetUrl(string endpoint) => $"{baseUrl}{endpoint}";
        public static Uri GetUri(string endpoint) => new Uri(GetUrl(endpoint));
    }
}
