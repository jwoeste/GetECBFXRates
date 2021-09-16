using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;

namespace GetECBFXRates
{
    class Program
    {
        static void Main(string[] args)
        {
            List<FXRate> FXRates = new List<FXRate>(); //  ECBFXRates.GetECBFXRates();

            Console.WriteLine(@"Load http://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml");
            var doc = new XmlDocument();
            doc.Load(@"http://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml");

            XmlNode xmlNode = doc.SelectSingleNode("//*[@time]");
            DateTime asofdate = DateTime.Parse(xmlNode.Attributes["time"].Value);
            Console.WriteLine("Got rates from " + asofdate.ToLongDateString());
            XmlNodeList nodes = doc.SelectNodes("//*[@currency]");
            if (nodes != null)
            {
                foreach (XmlNode node in nodes)
                {
                    FXRates.Add(new()
                    {
                        AsOfDate = asofdate,
                        Currency = node.Attributes["currency"].Value,
                        QuotingCurrency = "EUR",
                        Rate = Double.Parse(node.Attributes["rate"].Value, NumberStyles.Any, new CultureInfo("en-Us")),
                    });
                }
            }

            Console.WriteLine("Contents of FXRates");
            foreach (FXRate rate in FXRates)
            {
                Console.WriteLine("{0} : {1}", rate.QuotingCurrency + "/" + rate.Currency, rate.Rate);

            }


            Console.ReadLine();
        }
    }
}
