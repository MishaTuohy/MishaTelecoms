using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MishaTelecoms.API.Models.Requests.CDRData.Post.Update
{
    public class UpdateCDRDurationRequest
    {
        /// <summary>
        /// Unique Id for CDRData Object
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Duration of the call
        /// </summary>
        public int Duration { get; set; }
    }
}
