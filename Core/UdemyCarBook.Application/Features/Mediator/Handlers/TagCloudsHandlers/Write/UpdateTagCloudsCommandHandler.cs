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

public class UpdateTagCloudsCommandHandler : IRequestHandler<UpdateTagCloudsCommand>
{
    private readonly IRepository<TagCloud> _tagCloudRepository;

    public UpdateTagCloudsCommandHandler(IRepository<TagCloud> tagCloudRepository)
    {
        _tagCloudRepository = tagCloudRepository;
    }

    public async Task Handle(UpdateTagCloudsCommand request, CancellationToken cancellationToken)
    {
        var value = await _tagCloudRepository.GetByIdAsync(request.Id);
        value.Title = request.Title;
        value.BlogId = request.BlogId;
        await _tagCloudRepository.UpdateAsync(value);
    }
}
