using System;

namespace MishaTelecoms.Domain.Entities
{
    // CDR Data | Call Detail Record
    public class CDRData
    {
        public Guid Id { get; set; }
        public string CallingNumber { get; set; }
        public string CalledNumber { get; set; }
        public string Country { get; set; }
        public string CallType { get; set; }
        public int Duration { get; set; }
        public string DateCreated { get; set; }
        public double Cost { get; set; }
    }
}
