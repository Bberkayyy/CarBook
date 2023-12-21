using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UdemyCarBook.DTOs.AuthorDTOs;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/AdminAuthor")]
public class AdminAuthorController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AdminAuthorController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7041/api/Authors");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultAuthorDTO>>(jsonData);
            return View(values);
        }
        return View();
    }
    [HttpGet]
    [Route("CreateAuthor")]
    public IActionResult CreateAuthor()
    {
        return View();
    }

    [HttpPost]
    [Route("CreateAuthor")]
    public async Task<IActionResult> CreateAuthor(CreateAuthorDTO createAuthorDTO)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createAuthorDTO);
        StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("https://localhost:7041/api/Authors", content);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "AdminAuthor", new { area = "Admin" });
        }
        return View();
    }
    [Route("RemoveAuthor/{id}")]
    public async Task<IActionResult> RemoveAuthor(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync($"https://localhost:7041/api/Authors/{id}");
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "AdminAuthor", new { area = "Admin" });
        return View();
    }
    [HttpGet]
    [Route("UpdateAuthor/{id}")]
    public async Task<IActionResult> UpdateAuthor(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"https://localhost:7041/api/Authors/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateAuthorDTO>(jsonData);
            return View(value);
        }
        return View();
    }
    [HttpPost]
    [Route("UpdateAuthor/{id}")]
    public async Task<IActionResult> UpdateAuthor(UpdateAuthorDTO updateAuthorDTO)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(updateAuthorDTO);
        StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PutAsync("https://localhost:7041/api/Authors/", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "AdminAuthor", new { area = "Admin" });
        return View();
    }
}
