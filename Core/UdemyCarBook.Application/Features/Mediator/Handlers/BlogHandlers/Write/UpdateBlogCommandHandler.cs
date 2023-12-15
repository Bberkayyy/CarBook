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

public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand>
{
    private readonly IRepository<Blog> _blogRepository;

    public UpdateBlogCommandHandler(IRepository<Blog> blogRepository)
    {
        _blogRepository = blogRepository;
    }

    public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
    {
        var value = await _blogRepository.GetByIdAsync(request.Id);
        value.Description = request.Description;
        value.CreatedDate = request.CreatedDate;
        value.CategoryId = request.CategoryId;
        value.AuthorId = request.AuthorId;
        value.CoverImageUrl = request.CoverImageUrl;
        value.Title = request.Title;
        await _blogRepository.UpdateAsync(value);
    }
}
