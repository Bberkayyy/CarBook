using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.FooterAddressQueries;
using UdemyCarBook.Application.Features.Mediator.Results.FooterAddressResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers.Read;

public class GetFooterAddressByIdQueryHandler : IRequestHandler<GetFooterAddressByIdQuery, GetFooterAddressByIdQueryResult>
{
    private readonly IRepository<FooterAddress> _footerAddressRepository;

    public GetFooterAddressByIdQueryHandler(IRepository<FooterAddress> footerAddressRepository)
    {
        _footerAddressRepository = footerAddressRepository;
    }

    public async Task<GetFooterAddressByIdQueryResult> Handle(GetFooterAddressByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _footerAddressRepository.GetByIdAsync(request.Id);
        return new GetFooterAddressByIdQueryResult
        {
            Id = value.Id,
            Address = value.Address,
            Description = value.Description,
            Email = value.Email,
            Phone = value.Phone
        };
    }
}
