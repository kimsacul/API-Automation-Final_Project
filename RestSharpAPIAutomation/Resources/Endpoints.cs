using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpAPIAutomation.Resources
{
    public class Endpoints
    {
        public const string baseUrl = "https://restful-booker.herokuapp.com";

        public const string BookerEndpoint = "/booking";

        public const string TokenEndpoint = "/auth";

        public static string BaseBookingMethod => $"{baseUrl}{BookerEndpoint}";
        public static string GenerateToken => $"{baseUrl}{TokenEndpoint}";
        public static string GeneralEndpointById(int bookingId) => $"{baseUrl}{BookerEndpoint}/{bookingId}";
    }
}
