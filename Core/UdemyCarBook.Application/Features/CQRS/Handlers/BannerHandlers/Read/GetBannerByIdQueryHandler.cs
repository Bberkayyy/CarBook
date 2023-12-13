
using UdemyCarBook.Application.Features.CQRS.Queries.BannerQueries;
using UdemyCarBook.Application.Features.CQRS.Results.BannerResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.BannerHandlers.Read;

public class GetBannerByIdQueryHandler
{
    private readonly IRepository<Banner> _bannerRepository;

    public GetBannerByIdQueryHandler(IRepository<Banner> bannerRepository)
    {
        _bannerRepository = bannerRepository;
    }

    public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery query)
    {
        var value = await _bannerRepository.GetByIdAsync(query.Id);
        return new GetBannerByIdQueryResult
        {
            Id = value.Id,
            Title = value.Title,
            Description = value.Description,
            VideoDescription = value.VideoDescription,
            VideoUrl = value.VideoUrl
        };
    }
}
