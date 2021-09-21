using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MishaTelecoms.API.Models.Requests.CDRData.Post.Update
{
    /// <summary>
    /// CDR Data Model for Update Command Requests
    /// </summary>
    public class UpdateCDRAllRequest
    {
        /// <summary>
        /// Unique Id for CDRData Object
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Number that initiated the call
        /// </summary>
        public string CallingNumber { get; set; }
        /// <summary>
        /// Number that received the call
        /// </summary>
        public string CalledNumber { get; set; }
        /// <summary>
        /// Origin of Caller
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// Type of CallType/Communication medium | SMS/VOICE
        /// </summary>
        public string CallType { get; set; }
        /// <summary>
        /// Duration of the call
        /// </summary>
        public int Duration { get; set; }
        /// <summary>
        /// Date of occurance
        /// </summary>
        public string DateCreated { get; set; }
        /// <summary>
        /// Cost of communication
        /// </summary>
        public double Cost { get; set; }
    }
}
