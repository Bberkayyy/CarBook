﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.DTOs.ServiceDTOs;

namespace UdemyCarBook.WebUI.Controllers
{
    public class ServiceController : Controller
    {

        public IActionResult Index()
        {
 
            return View();
        }
    }
}