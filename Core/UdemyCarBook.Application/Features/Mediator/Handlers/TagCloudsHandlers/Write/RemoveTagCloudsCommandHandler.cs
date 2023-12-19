using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.TagCloudsCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.TagCloudsHandlers.Write;

public class RemoveTagCloudsCommandHandler : IRequestHandler<RemoveTagCloudsCommand>
{
    private readonly IRepository<TagCloud> _tagCloudRepository;

    public RemoveTagCloudsCommandHandler(IRepository<TagCloud> tagCloudRepository)
    {
        _tagCloudRepository = tagCloudRepository;
    }

    public async Task Handle(RemoveTagCloudsCommand request, CancellationToken cancellationToken)
    {
        var value = await _tagCloudRepository.GetByIdAsync(request.Id);
        await _tagCloudRepository.RemoveAsync(value);
    }
}
