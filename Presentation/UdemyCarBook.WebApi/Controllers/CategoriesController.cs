﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.CQRS.Commands.CategoryCommands;
using UdemyCarBook.Application.Features.CQRS.Handlers.CategoryHandlers.Read;
using UdemyCarBook.Application.Features.CQRS.Handlers.CategoryHandlers.Write;
using UdemyCarBook.Application.Features.CQRS.Queries.CategoryQueries;

namespace UdemyCarBook.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly GetCategoryQueryHandler _getCategoryQueryHandler;
    private readonly GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler;
    private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
    private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;
    private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;

    public CategoriesController(GetCategoryQueryHandler getCategoryQueryHandler,
                            GetCategoryByIdQueryHandler getCategoryByIdQueryHandler,
                            CreateCategoryCommandHandler createCategoryCommandHandler,
                            UpdateCategoryCommandHandler updateCategoryCommandHandler,
                            RemoveCategoryCommandHandler removeCategoryCommandHandler)
    {
        _getCategoryQueryHandler = getCategoryQueryHandler;
        _getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
        _createCategoryCommandHandler = createCategoryCommandHandler;
        _updateCategoryCommandHandler = updateCategoryCommandHandler;
        _removeCategoryCommandHandler = removeCategoryCommandHandler;
    }

    [HttpGet]
    public async Task<IActionResult> CategoryList()
    {
        var values = await _getCategoryQueryHandler.Handle();
        return Ok(values);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategory(int id)
    {
        var value = await _getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));
        return Ok(value);
    }
    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
    {
        await _createCategoryCommandHandler.Handle(command);
        return Ok("Kategori bilgisi eklendi.");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
    {
        await _updateCategoryCommandHandler.Handle(command);
        return Ok("Kategori bilgisi güncellendi.");
    }
    [HttpDelete]
    public async Task<IActionResult> RemoveCategory(RemoveCategoryCommand command)
    {
        await _removeCategoryCommandHandler.Handle(command);
        return Ok("Kategori biligisi silindi.");
    }
}