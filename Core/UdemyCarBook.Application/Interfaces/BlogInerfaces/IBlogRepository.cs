﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Interfaces.BlogInerfaces;

public interface IBlogRepository
{
    List<Blog> GetLast3BlogWithAuthor();
    List<Blog> GetAllBlogsWithAuthor();
    List<Blog> GetBlogByAuthorId(int id);
}
