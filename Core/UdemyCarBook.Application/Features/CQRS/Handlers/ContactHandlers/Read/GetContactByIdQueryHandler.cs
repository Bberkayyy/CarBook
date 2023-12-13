using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Queries.ContactQueries;
using UdemyCarBook.Application.Features.CQRS.Results.ContactResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.ContactHandlers.Read;

public class GetContactByIdQueryHandler
{
    private readonly IRepository<Contact> _contactRepository;

    public GetContactByIdQueryHandler(IRepository<Contact> contactRepository)
    {
        _contactRepository = contactRepository;
    }
    public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery query)
    {
        var value = await _contactRepository.GetByIdAsync(query.Id);
        return new GetContactByIdQueryResult
        {
            Id = value.Id,
            Email = value.Email,
            Message = value.Message,
            Name = value.Name,
            SendDate = value.SendDate,
            Subject = value.Subject,
        };
    }
}
