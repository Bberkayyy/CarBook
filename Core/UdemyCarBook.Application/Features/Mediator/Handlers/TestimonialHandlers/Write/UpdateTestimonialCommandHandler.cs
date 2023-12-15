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

public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommand>
{
    private readonly IRepository<Testimonial> _testimonialRepository;

    public UpdateTestimonialCommandHandler(IRepository<Testimonial> testimonialRepository)
    {
        _testimonialRepository = testimonialRepository;
    }

    public async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
    {
        var value = await _testimonialRepository.GetByIdAsync(request.Id);
        value.Title = request.Title;
        value.Comment = request.Comment;
        value.Name = request.Name;
        value.ImageUrl = request.ImageUrl;
        await _testimonialRepository.UpdateAsync(value);
    }
}
