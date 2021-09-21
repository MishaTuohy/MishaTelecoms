using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MishaTelecoms.API.Models.Requests.CDRData.Post.Update
{
    public class UpdateCDRCallingNumberRequest
    {
        /// <summary>
        /// Unique Id for CDRData Object
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Number that initiated the call
        /// </summary>
        public string CallingNumber { get; set; }
    }
}
