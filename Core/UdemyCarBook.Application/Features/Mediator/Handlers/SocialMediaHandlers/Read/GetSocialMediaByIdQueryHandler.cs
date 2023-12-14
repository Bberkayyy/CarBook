using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.SocialMediaQueries;
using UdemyCarBook.Application.Features.Mediator.Results.SocialMediaResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers.Read;

public class GetSocialMediaByIdQueryHandler : IRequestHandler<GetSocialMediaByIdQuery, GetSocialMediaByIdQueryResult>
{
    private readonly IRepository<SocialMedia> _socialMediaRepository;

    public GetSocialMediaByIdQueryHandler(IRepository<SocialMedia> socialMediaRepository)
    {
        _socialMediaRepository = socialMediaRepository;
    }

    public async Task<GetSocialMediaByIdQueryResult> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _socialMediaRepository.GetByIdAsync(request.Id);
        return new GetSocialMediaByIdQueryResult
        {
            Id = value.Id,
            Icon = value.Icon,
            Name = value.Name,
            Url = value.Url,
        };
    }
}
