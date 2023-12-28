using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.DTOs.RentACarDTOs;

namespace UdemyCarBook.WebUI.Controllers;

public class RentACarListController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public RentACarListController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index(int locationId)
    {
        var bookpickdate = TempData["bookpickdate"];
        var bookoffdate = TempData["bookoffdate"];
        var timepick = TempData["timepick"];
        var timeoff = TempData["timeoff"];
        var id = TempData["id"];

        locationId =int.Parse(id.ToString());

        ViewBag.bookpickdate = bookpickdate;
        ViewBag.bookoffdate = bookoffdate;
        ViewBag.timepick = timepick;
        ViewBag.timeoff = timeoff;
        ViewBag.id = id;

        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"https://localhost:7041/api/RentACars?locationId={locationId}&available=true");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<FilterRentACarDTO>>(jsonData);
            return View(values);
        }

        return View();
    }
}
