using System;
using System.Collections.Generic;
using System.Text;

namespace MishaTelecoms.Application.Dtos
{
    /// <summary>
    /// asdasd
    /// </summary>
    public class CDRDataDto
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
