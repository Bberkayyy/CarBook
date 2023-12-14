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

public class RemoveFooterAddresCommandHandler : IRequestHandler<RemoveFooterAddressCommand>
{
    private readonly IRepository<FooterAddress> _footerAddressRepository;

    public RemoveFooterAddresCommandHandler(IRepository<FooterAddress> footerAddressRepository)
    {
        _footerAddressRepository = footerAddressRepository;
    }

    public async Task Handle(RemoveFooterAddressCommand request, CancellationToken cancellationToken)
    {
        var value = await _footerAddressRepository.GetByIdAsync(request.Id);
        await _footerAddressRepository.RemoveAsync(value);
    }
}
