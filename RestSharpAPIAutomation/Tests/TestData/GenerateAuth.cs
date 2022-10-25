using RestSharpAPIAutomation.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpAPIAutomation.Tests.TestData
{
    public class GenerateAuth
    {
        public static TokenAuthJsonModel userCredentials()
        {
            return new TokenAuthJsonModel
            {
                Username = "admin",
                Password = "password123"
            };
        }
    }
}
