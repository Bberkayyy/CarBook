using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Commands.CarReviewCommands;

public class CreateCarReviewCommand : IRequest
{
    public string CustomerName { get; set; }
    public string CustomerImage { get; set; }
    public string Comment { get; set; }
    public int RaytingValues { get; set; }
    public DateTime ReviewDate { get; set; }
    public int CarId { get; set; }
}
