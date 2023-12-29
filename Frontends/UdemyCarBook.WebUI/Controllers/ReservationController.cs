using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http;
using UdemyCarBook.DTOs.LocationDTOs;

namespace UdemyCarBook.WebUI.Controllers;

public class ReservationController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ReservationController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        ViewBag.v1 = "Araç Kiralama";
        ViewBag.v2 = "Araç Rezervasyon Formu";
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7041/api/Locations");

        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultLocationDTO>>(jsonData);
        List<SelectListItem> values2 = (from x in values
                                        select new SelectListItem
                                        {
                                            Text = x.Name,
                                            Value = x.Id.ToString()
                                        }).ToList();
        ViewBag.v = values2;
        return View();
    }
}
