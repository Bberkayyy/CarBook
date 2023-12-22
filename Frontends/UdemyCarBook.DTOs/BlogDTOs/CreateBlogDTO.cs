﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.DTOs.BlogDTOs;

public class CreateBlogDTO
{
    public string Title { get; set; }
    public int AuthorId { get; set; }
    public string AuthorName { get; set; }
    public string CoverImageUrl { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string AuthorDescription { get; set; }
    public string AuthorImageUrl { get; set; }
}
