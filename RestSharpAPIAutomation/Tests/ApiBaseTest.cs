using RestSharp;
using RestSharpAPIAutomation.DataModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpAPIAutomation.Tests
{
    public class ApiBaseTest
    {
        public RestClient RestClient { get; set; }

        public BookerIdJsonModel BookingDetails { get; set; }

        [TestInitialize]
        public void Initilize()
        {
            RestClient = new RestClient();
        }
    }
}
