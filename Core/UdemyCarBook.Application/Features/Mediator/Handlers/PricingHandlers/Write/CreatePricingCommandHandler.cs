using MediatR;
using UdemyCarBook.Application.Features.Mediator.Commands.PricingCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.PricingHandlers.Write;

public class CreatePricingCommandHandler : IRequestHandler<CreatePricingCommand>
{
    private readonly IRepository<Pricing> _pricingRepository;

    public CreatePricingCommandHandler(IRepository<Pricing> pricingRepository)
    {
        _pricingRepository = pricingRepository;
    }

    public async Task Handle(CreatePricingCommand request, CancellationToken cancellationToken)
    {
        await _pricingRepository.CreateAsync(new Pricing
        {
            Name = request.Name,
        });
    }
}
