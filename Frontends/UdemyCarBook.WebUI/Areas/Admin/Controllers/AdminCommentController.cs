using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.DTOs.CommentDTOs;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/AdminComment")]
public class AdminCommentController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AdminCommentController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [Route("Index/{id}")]
    public async Task<IActionResult> Index(int id)
    {
        ViewBag.Id = id;
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7041/api/Comments/GetCommentsByBlogId?blogId=" + id);
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultGetCommentsByBlogIdDTO>>(jsonData);
            return View(values);
        }
        return View();
    }
}
