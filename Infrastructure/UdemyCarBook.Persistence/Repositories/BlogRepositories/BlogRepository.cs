﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.BlogInerfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.BlogRepositories;

public class BlogRepository : IBlogRepository
{
    private readonly CarBookContext _context;

    public BlogRepository(CarBookContext context)
    {
        _context = context;
    }

    public List<Blog> GetAllBlogsWithAuthor()
    {
        var values = _context
            .Blogs
            .Include(b => b.Author)
            .ToList();
        return values;
    }

    public List<Blog> GetBlogByAuthorId(int id)
    {
        var values = _context
            .Blogs
            .Include(x => x.Author)
            .Where(x => x.Id == id)
            .ToList();
        return values;
    }

    public List<Blog> GetLast3BlogWithAuthor()
    {
        var values = _context
            .Blogs
            .Include(b => b.Author)
            .OrderByDescending(x => x.Id)
            .Take(3)
            .ToList();
        return values;
    }
}
