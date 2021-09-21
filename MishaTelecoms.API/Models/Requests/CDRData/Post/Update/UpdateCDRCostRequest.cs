using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MishaTelecoms.API.Models.Requests.CDRData.Post.Update
{
    public class UpdateCDRCostRequest
    {
        /// <summary>
        /// Unique Id for CDRData Object
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Cost of communication
        /// </summary>
        public double Cost { get; set; }
    }
}
