using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MishaTelecoms.API.Models.Requests.CDRData.Post.Update
{
    public class UpdateCDRCallTypeRequest
    {
        /// <summary>
        /// Unique Id for CDRData Object
        /// </summary>
        public Guid Id { get; set; }
        /// /// <summary>
        /// Type of CallType/Communication medium | SMS/VOICE
        /// </summary>
        public string CallType { get; set; }
    }
}