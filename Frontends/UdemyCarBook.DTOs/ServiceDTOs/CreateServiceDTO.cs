﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.DTOs.ServiceDTOs;

public class CreateServiceDTO
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string IconUrl { get; set; }
}
