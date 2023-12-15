using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.TestimonialCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.TestimonialHandlers.Write;

public class RemoveTestimonialCommandHandler : IRequestHandler<RemoveTestimonialCommand>
{
    private readonly IRepository<Testimonial> _testimonialRepository;

    public RemoveTestimonialCommandHandler(IRepository<Testimonial> testimonialRepository)
    {
        _testimonialRepository = testimonialRepository;
    }

    public async Task Handle(RemoveTestimonialCommand request, CancellationToken cancellationToken)
    {
        var value = await _testimonialRepository.GetByIdAsync(request.Id);
        await _testimonialRepository.RemoveAsync(value);
    }
}
