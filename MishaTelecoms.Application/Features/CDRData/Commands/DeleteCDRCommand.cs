using MediatR;
using System;

namespace MishaTelecoms.Application.Features.CDRData.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteCDRCommand : IRequest<bool>
    {
        /// <summary>
        /// 
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public DeleteCDRCommand(Guid id)
        {
            Id = id;
        }
    }
}
