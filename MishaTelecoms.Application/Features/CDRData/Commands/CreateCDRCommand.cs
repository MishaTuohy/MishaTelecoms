using MediatR;
using MishaTelecoms.Application.Dtos;

namespace MishaTelecoms.Application.Features.CDRData.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateCDRCommand : IRequest<bool>
    {
        /// <summary>
        /// 
        /// </summary>
        public CDRDataDto CDR;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public CreateCDRCommand(CDRDataDto cdr)
        {
            CDR = cdr;
        }
    }
}
