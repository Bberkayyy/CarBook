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

public class CreateTagCloudsCommandHandler : IRequestHandler<CreateTagCloudsCommand>
{
    private readonly IRepository<TagCloud> _tagCloudRepository;

    public CreateTagCloudsCommandHandler(IRepository<TagCloud> tagCloudRepository)
    {
        _tagCloudRepository = tagCloudRepository;
    }

    public async Task Handle(CreateTagCloudsCommand request, CancellationToken cancellationToken)
    {
        await _tagCloudRepository.CreateAsync(new TagCloud
        {
            Title = request.Title,
            BlogId = request.BlogId,
        });
    }
}
