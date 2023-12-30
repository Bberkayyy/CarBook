using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using UdemyCarBook.DTOs.LocationDTOs;
using UdemyCarBook.DTOs.ReservationDTOs;

namespace UdemyCarBook.WebUI.Controllers;

public class ReservationController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ReservationController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    [HttpGet]
    public async Task<IActionResult> Index(int id)
    {
        ViewBag.v1 = "Araç Kiralama";
        ViewBag.v2 = "Araç Rezervasyon Formu";
        ViewBag.carId = id;
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
        ViewBag.locations = values2;
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Index(CreateReservationDTO createReservationDTO)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createReservationDTO);
        StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
        var responseMessage = await client.PostAsync("https://localhost:7041/api/Reservations", stringContent);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Default");
        return View();
    }
}
