using MediatR;
using MishaTelecoms.Application.Dtos;

namespace MishaTelecoms.Application.Features.CDRData.Commands
{
    public class CreateCDRCommand : IRequest<bool>
    {
        public CDRDataDto CDR;
        public CreateCDRCommand(CDRDataDto cdr)
        {
            CDR = cdr;
        }
    }
}
