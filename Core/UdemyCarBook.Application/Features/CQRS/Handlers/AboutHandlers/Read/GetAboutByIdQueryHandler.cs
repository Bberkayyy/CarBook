using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Queries.AboutQueries;
using UdemyCarBook.Application.Features.CQRS.Results.AboutResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.AboutHandlers.Read;

public class GetAboutByIdQueryHandler
{
    private readonly IRepository<About> _aboutRepository;
    public GetAboutByIdQueryHandler(IRepository<About> aboutRepository)
    {
        _aboutRepository = aboutRepository;
    }

    public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery query)
    {
        var value = await _aboutRepository.GetByIdAsync(query.Id);
        return new GetAboutByIdQueryResult
        {
            Id = value.Id,
            Description = value.Description,
            ImageUrl = value.ImageUrl,
            Title = value.Title,
        };
    }
}
