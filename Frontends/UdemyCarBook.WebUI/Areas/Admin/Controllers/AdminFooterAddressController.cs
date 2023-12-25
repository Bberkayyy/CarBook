using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UdemyCarBook.DTOs.FooterAddressDTOs;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/AdminFooterAddress")]
public class AdminFooterAddressController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AdminFooterAddressController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7041/api/FooterAddresses");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultFooterAddressDTO>>(jsonData);
            return View(values);
        }
        return View();
    }
    [HttpGet]
    [Route("CreateFooterAddress")]
    public IActionResult CreateFooterAddress()
    {
        return View();
    }

    [HttpPost]
    [Route("CreateFooterAddress")]
    public async Task<IActionResult> CreateFooterAddress(CreateFooterAddressDTO createFooterAddressDTO)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createFooterAddressDTO);
        StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("https://localhost:7041/api/FooterAddresses", content);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "AdminFooterAddress", new { area = "Admin" });
        }
        return View();
    }
    [Route("RemoveFooterAddress/{id}")]
    public async Task<IActionResult> RemoveFooterAddress(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync("https://localhost:7041/api/FooterAddresses?id="+id);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "AdminFooterAddress", new { area = "Admin" });
        return View();
    }
    [HttpGet]
    [Route("UpdateFooterAddress/{id}")]
    public async Task<IActionResult> UpdateFooterAddress(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"https://localhost:7041/api/FooterAddresses/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateFooterAddressDTO>(jsonData);
            return View(value);
        }
        return View();
    }
    [HttpPost]
    [Route("UpdateFooterAddress/{id}")]
    public async Task<IActionResult> UpdateFooterAddress(UpdateFooterAddressDTO updateFooterAddressDTO)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(updateFooterAddressDTO);
        StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PutAsync("https://localhost:7041/api/FooterAddresses/", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "AdminFooterAddress", new { area = "Admin" });
        return View();
    }
}
