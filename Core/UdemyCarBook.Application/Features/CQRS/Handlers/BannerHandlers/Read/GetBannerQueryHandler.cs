using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Results.BannerResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.BannerHandlers.Read;

public class GetBannerQueryHandler
{
    private readonly IRepository<Banner> _bannerRepository;

    public GetBannerQueryHandler(IRepository<Banner> bannerRepository)
    {
        _bannerRepository = bannerRepository;
    }

    public async Task<List<GetBannerQueryResult>> Handle()
    {
        var values = await _bannerRepository.GetAllAsync();
        return values
            .Select(x => new GetBannerQueryResult
            {
                Id = x.Id,
                Description = x.Description,
                Title = x.Title,
                VideoDescription = x.VideoDescription,
                VideoUrl = x.VideoUrl,
            })
            .ToList();
    }
}
