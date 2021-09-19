using MediatR;
using MishaTelecoms.Application.Dtos;
using MishaTelecoms.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MishaTelecoms.Application.Features.CDRData.Queries.GetCDRByDateCreated
{
    public class GetCDRByDateCreatedQuery : IRequest<Response<IReadOnlyList<CDRDataDto>>>
    {
        public string DateCreated { get; set; }
        public GetCDRByDateCreatedQuery(string dateCreated)
        {
            DateCreated = dateCreated;
        }
    }
}
