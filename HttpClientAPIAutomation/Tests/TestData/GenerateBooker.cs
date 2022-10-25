using HttpClientAPIAutomation.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientAPIAutomation.Tests.TestData
{
    public class GenerateBooker
    {
        public static BookerJsonModel newBooker()
        {
            return new BookerJsonModel
            {
                Firstname = "Dayton",
                Lastname = "Reece",
                Totalprice = 318,
                Depositpaid = true,
                Bookingdates = new Bookingdates
                {
                    Checkin = DateTime.UtcNow.Date,
                    Checkout = DateTime.UtcNow.Date
                },
                Additionalneeds = "Smoking"
            };
        }
    }
}
