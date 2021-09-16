using System;
namespace GetECBFXRates
{
    public class FXRate
    {

        public DateTime AsOfDate { get; set; }

        public string QuotingCurrency { get; set; }
        public string Currency { get; set; }
        public double Rate { get; set; }

        public FXRate()
        {
        }
    }
}
