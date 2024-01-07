using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.CommentCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.CommentHandlers.Write;

public class CreateCommentHandler : IRequestHandler<CreateCommentCommand>
{
    private readonly IRepository<Comment> _commentRepository;

    public CreateCommentHandler(IRepository<Comment> commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        await _commentRepository.CreateAsync(new Comment
        {
            Name = request.Name,
            Email = request.Email,
            CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString()),
            Description = request.Description,
            BlogId = request.BlogId,
        });
    }
}
