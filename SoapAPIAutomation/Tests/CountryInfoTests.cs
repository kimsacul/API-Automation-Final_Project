using CountryInfoServiceReference;

namespace SoapAPIAutomation.Tests
{
    [TestClass]
    public class CountryInfoTests
    {
        private static CountryInfoServiceSoapTypeClient? countryInfoServiceSoapTypeClient = null;

        private List<tCountryCodeAndName> CountryCodes()
        {
            var countryCodes = countryInfoServiceSoapTypeClient?.ListOfCountryNamesByCode();

            return countryCodes;
        }

        private string RandomCountryCode(List<tCountryCodeAndName> countryList)
        {
            Random random = new Random();
            int randomCountry = random.Next(0, countryList.Count - 1);
            var randomCountryCode = countryList[randomCountry];

            return randomCountryCode.sISOCode;
        }

        [TestInitialize]
        public void TestInit()
        {
            countryInfoServiceSoapTypeClient = new CountryInfoServiceSoapTypeClient(CountryInfoServiceSoapTypeClient.EndpointConfiguration.CountryInfoServiceSoap);
        }

        [TestMethod]
        public void FullCountryInfoMethod()
        {
            //assign
            var countryCodes = CountryCodes();
            var randomCountry = RandomCountryCode(countryCodes);

            //act
            var fullCountryInfo = countryInfoServiceSoapTypeClient?.FullCountryInfo(randomCountry);

            //assert
            Assert.AreEqual(randomCountry, fullCountryInfo.sISOCode);

            var countryName = countryInfoServiceSoapTypeClient?.CountryName(randomCountry);
            Assert.AreEqual(countryName, fullCountryInfo.sName);
        }

        [TestMethod]

        public void CountryISOCodeMethod()
        {
            //assign
            var countryCodes = CountryCodes();
            List<string> randomCountries = new List<string>();

            int i = 0;
            while (i == 4)
            {
                randomCountries.Add(RandomCountryCode(countryCodes));
                i++;
            }

            foreach (var countryCode in randomCountries)
            {
                //act
                var countryName = countryInfoServiceSoapTypeClient?.CountryName(countryCode);
                var countryIsoCode = countryInfoServiceSoapTypeClient?.CountryISOCode(countryName);

                //assert
                Assert.AreEqual(countryCode, countryIsoCode);
            }
        }
    }
}