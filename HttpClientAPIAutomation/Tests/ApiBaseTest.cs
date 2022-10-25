using HttpClientAPIAutomation.DataModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientAPIAutomation.Tests
{
    public class ApiBaseTest
    {
       // public RestClient RestClient { get; set; }

        public BookerIdJsonModel BookingDetails { get; set; }

        [TestInitialize]
        public void Initilize()
        {
           // RestClient = new RestClient();
        }
    }
}
