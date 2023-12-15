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

public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand>
{
    private readonly IRepository<Author> _AuthorRepository;

    public UpdateAuthorCommandHandler(IRepository<Author> AuthorRepository)
    {
        _AuthorRepository = AuthorRepository;
    }

    public async Task Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        var value = await _AuthorRepository.GetByIdAsync(request.Id);
        value.Name = request.Name;
        value.ImageUrl = request.ImageUrl;
        value.Description = request.Description;
        await _AuthorRepository.UpdateAsync(value);
    }
}
