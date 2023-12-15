using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.AuthorCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.AuthorHandlers.Write;

public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand>
{
    private readonly IRepository<Author> _AuthorRepository;

    public CreateAuthorCommandHandler(IRepository<Author> AuthorRepository)
    {
        _AuthorRepository = AuthorRepository;
    }

    public async Task Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
    {
        await _AuthorRepository.CreateAsync(new Author
        {
            Name = request.Name,
            Description = request.Description,
            ImageUrl = request.ImageUrl,
        });
    }
}
