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
        
    }
}