using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.FooterAddressCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers.Write;

public class CreateFooterAddressCommandHandler : IRequestHandler<CreateFooterAddressCommand>
{
    private readonly IRepository<FooterAddress> _footerAddressRepository;

    public CreateFooterAddressCommandHandler(IRepository<FooterAddress> footerAddressRepository)
    {
        _footerAddressRepository = footerAddressRepository;
    }

    public async Task Handle(CreateFooterAddressCommand request, CancellationToken cancellationToken)
    {
        await _footerAddressRepository.CreateAsync(new FooterAddress
        {
            Address = request.Address,
            Description = request.Description,
            Email = request.Email,
            Phone = request.Phone,
        });
    }
}
