using MediatR;
using UdemyCarBook.Application.Features.Mediator.Commands.PricingCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.PricingHandlers.Write;

public class RemovePricingCommandHandler : IRequestHandler<RemovePricingCommand>
{
    private readonly IRepository<Pricing> _pricingRepository;

    public RemovePricingCommandHandler(IRepository<Pricing> pricingRepository)
    {
        _pricingRepository = pricingRepository;
    }

    public async Task Handle(RemovePricingCommand request, CancellationToken cancellationToken)
    {
        var value = await _pricingRepository.GetByIdAsync(request.Id);
        await _pricingRepository.RemoveAsync(value);
    }
}
