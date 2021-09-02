using System;

namespace MishaTelecoms.CDRGenerator.Models
{
    public class CDRDataModel
    {
        #region "Properties"
        public Guid Id { get; set; }
        public string CallingNumber { get; set; }
        public string CalledNumber { get; set; }
        public string Country { get; set; }
        public string CallType { get; set; }
        public int Duration { get; set; }
        public string DateCreated { get; set; }
        public double Cost { get; set; }
        #endregion
        public CDRDataModel() 
        {
        }
        public override string ToString()
        {
            return $"{Id},{CalledNumber},{CallingNumber},{Country},{CallType},{Duration},{DateCreated}";
        }
        public double CalculateCost(string country, int duration)
        {
            return country switch
            {
                "Ireland" => 0.66 * duration,
                "England" => 0.85 * duration,
                "Scotland" => 1.10 * duration,
                "Wales" => 0.77 * duration,
                "Northern Ireland" => 0.89 * duration,
                _ => 0.0,
            };
        }
    }
}