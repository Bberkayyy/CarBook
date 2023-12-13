using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Commands.AboutCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.AboutHandlers.Write;

public class CreateAboutCommandHandler
{
    private readonly IRepository<About> _aboutRepository;

    public CreateAboutCommandHandler(IRepository<About> aboutRepository)
    {
        _aboutRepository = aboutRepository;
    }

    public async Task Handle(CreateAboutCommand command)
    {
        await _aboutRepository.CreateAsync(new About
        {
            Description = command.Description,
            ImageUrl = command.ImageUrl,
            Title = command.Title,
        });
    }
}
