using MediatR;
using MishaTelecoms.API.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MishaTelecoms.API.Services.CDRServices.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateCDRCommand : IRequest<bool>
    {
        /// <summary>
        /// 
        /// </summary>
        public CDRDataRequest Entity;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public CreateCDRCommand(CDRDataRequest entity)
        {
            Entity = entity;
        }
    }
}
