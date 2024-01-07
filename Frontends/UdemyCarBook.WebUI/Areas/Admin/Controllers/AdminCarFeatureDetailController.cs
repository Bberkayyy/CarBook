using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UdemyCarBook.DTOs.CarFeatureDTOs;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/AdminCarFeatureDetail")]
public class AdminCarFeatureDetailController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AdminCarFeatureDetailController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [Route("Index/{id}")]
    [HttpGet]
    public async Task<IActionResult> Index(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"https://localhost:7041/api/CarFeatures?carId={id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultGetCarFeaturesByCarIdDTO>>(jsonData);
            return View(values);
        }
        return View();
    }
    [HttpPost]
    [Route("Index/{id}")]
    public async Task<IActionResult> Index(List<ResultGetCarFeaturesByCarIdDTO> resultGetCarFeaturesByCarIdDTOs)
    {
        var client = _httpClientFactory.CreateClient();       
        foreach (var item in resultGetCarFeaturesByCarIdDTOs)
        {
            if (item.Available)
            {
                var responseMessage = await client.GetAsync($"https://localhost:7041/api/CarFeatures/AvailableToTrue?id={item.Id}");
            }
            else
            {
                var responseMessage = await client.GetAsync($"https://localhost:7041/api/CarFeatures/AvailableToFalse?id={item.Id}");
            }
        }
        return RedirectToAction("Index","AdminCar");

    }
}
