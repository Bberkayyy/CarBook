using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Commands.BrandCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.BrandHandlers.Write;

public class UpdateBrandCommandHandler
{
    private readonly IRepository<Brand> _brandRepository;

    public UpdateBrandCommandHandler(IRepository<Brand> brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public async Task Handle(UpdateBrandCommand command)
    {
        var value = await _brandRepository.GetByIdAsync(command.Id);
        value.Name = command.Name;

        await _brandRepository.UpdateAsync(value);

    }
}
