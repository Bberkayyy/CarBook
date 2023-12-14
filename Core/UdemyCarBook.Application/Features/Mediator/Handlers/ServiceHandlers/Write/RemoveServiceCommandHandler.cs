using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.ServiceCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.ServiceHandlers.Write;

public class RemoveServiceCommandHandler : IRequestHandler<RemoveServiceCommand>
{
    private readonly IRepository<Service> _serviceRepostiroy;

    public RemoveServiceCommandHandler(IRepository<Service> serviceRepostiroy)
    {
        _serviceRepostiroy = serviceRepostiroy;
    }

    public async Task Handle(RemoveServiceCommand request, CancellationToken cancellationToken)
    {
        var value = await _serviceRepostiroy.GetByIdAsync(request.Id);
        await _serviceRepostiroy.RemoveAsync(value);
    }
}
