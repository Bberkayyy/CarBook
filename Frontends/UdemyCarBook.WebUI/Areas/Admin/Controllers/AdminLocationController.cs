using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using UdemyCarBook.DTOs.LocationDTOs;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers;

[Authorize(Roles = "Admin")]
[Area("Admin")]
[Route("Admin/AdminLocation")]
public class AdminLocationController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AdminLocationController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        var token = User.Claims.FirstOrDefault(x => x.Type == "accessToken").Value;
        if (token is not null)
        {
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var responseMessage = await client.GetAsync("https://localhost:7041/api/Locations");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLocationDTO>>(jsonData);
                return View(values);
            }
        }
        return View();
    }
    [HttpGet]
    [Route("CreateLocation")]
    public IActionResult CreateLocation()
    {
        return View();
    }
    [HttpPost]
    [Route("CreateLocation")]
    public async Task<IActionResult> CreateLocation(CreateLocationDTO createLocationDTO)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createLocationDTO);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("https://localhost:7041/api/Locations", stringContent);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "AdminLocation", new { area = "Admin" });
        }
        return View();
    }
    [HttpGet]
    [Route("UpdateLocation/{id}")]
    public async Task<IActionResult> UpdateLocation(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"https://localhost:7041/api/Locations/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateLocationDTO>(jsonData);
            return View(value);
        }
        return View();
    }
    [HttpPost]
    [Route("UpdateLocation/{id}")]
    public async Task<IActionResult> UpdateLocation(UpdateLocationDTO updateLocationDTO)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(updateLocationDTO);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PutAsync("https://localhost:7041/api/Locations", stringContent);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "AdminLocation", new { area = "Admin" });
        }
        return View();
    }
    [Route("RemoveLocation/{id}")]
    public async Task<IActionResult> RemoveLocation(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync("https://localhost:7041/api/Locations?id=" + id);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "AdminLocation", new { area = "Admin" });
        }
        return View();
    }

}
