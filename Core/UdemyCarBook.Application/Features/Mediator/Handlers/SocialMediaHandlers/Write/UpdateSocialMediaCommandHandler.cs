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

public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand>
{
    private readonly IRepository<SocialMedia> _socialMediaRepository;

    public UpdateSocialMediaCommandHandler(IRepository<SocialMedia> socialMediaRepository)
    {
        _socialMediaRepository = socialMediaRepository;
    }

    public async Task Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
    {
        var value = await _socialMediaRepository.GetByIdAsync(request.Id);
        value.Url = request.Url;
        value.Name = request.Name;
        value.Icon = request.Icon;
        await _socialMediaRepository.UpdateAsync(value);
    }
}
