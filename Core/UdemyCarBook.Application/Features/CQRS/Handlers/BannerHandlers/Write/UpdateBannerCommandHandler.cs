using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Commands.BannerCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.BannerHandlers.Write;

public class UpdateBannerCommandHandler
{
    private readonly IRepository<Banner> _bannerRepository;

    public UpdateBannerCommandHandler(IRepository<Banner> bannerRepository)
    {
        _bannerRepository = bannerRepository;
    }
    public async Task Handle(UpdateBannerCommand command)
    {
        var value = await _bannerRepository.GetByIdAsync(command.Id);
        value.Description = command.Description;
        value.VideoDescription = command.VideoDescription;
        value.Title = command.Title;
        value.VideoUrl = command.VideoUrl;

        await _bannerRepository.UpdateAsync(value);
    }
}
