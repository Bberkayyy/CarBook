using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Results.AboutResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.AboutHandlers.Read;

public class GetAboutQueryHandler
{
    private readonly IRepository<About> _aboutRepository;

    public GetAboutQueryHandler(IRepository<About> aboutRepository)
    {
        _aboutRepository = aboutRepository;
    }
    public async Task<List<GetAboutQueryResult>> Handle()
    {
        var values = await _aboutRepository.GetAllAsync();
        return values
            .Select(x => new GetAboutQueryResult
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
            })
            .ToList();
    }
}
