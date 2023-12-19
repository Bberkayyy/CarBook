using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.Mediator.Commands.TagCloudsCommands;

public class UpdateTagCloudsCommand:IRequest
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int BlogId { get; set; }
}
