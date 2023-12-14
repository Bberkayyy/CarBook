using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers.Write;

public class RemoveSocialMediaCommandHandler : IRequestHandler<RemoveSocialMediaCommand>
{
    private readonly IRepository<SocialMedia> _socialMediaRepository;

    public RemoveSocialMediaCommandHandler(IRepository<SocialMedia> socialMediaRepository)
    {
        _socialMediaRepository = socialMediaRepository;
    }

    public async Task Handle(RemoveSocialMediaCommand request, CancellationToken cancellationToken)
    {
        var value = await _socialMediaRepository.GetByIdAsync(request.Id);
        await _socialMediaRepository.RemoveAsync(value);
    }
}
