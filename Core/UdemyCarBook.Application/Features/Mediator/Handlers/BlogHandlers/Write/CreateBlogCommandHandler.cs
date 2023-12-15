using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.BlogCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.BlogHandlers.Write;

public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand>
{
    private readonly IRepository<Blog> _blogRepository;

    public CreateBlogCommandHandler(IRepository<Blog> blogRepository)
    {
        _blogRepository = blogRepository;
    }

    public  async Task Handle(CreateBlogCommand request, CancellationToken cancellationToken)
    {
        await _blogRepository.CreateAsync(new Blog
        {
            AuthorId = request.AuthorId,
            CategoryId = request.CategoryId,
            CoverImageUrl = request.CoverImageUrl,
            CreatedDate = request.CreatedDate,
            Description = request.Description,
            Title = request.Title,
            
        });
    }
}
