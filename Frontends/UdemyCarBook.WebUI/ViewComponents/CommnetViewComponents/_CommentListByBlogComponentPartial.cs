using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.DTOs.CommentDTOs;

namespace UdemyCarBook.WebUI.ViewComponents.CommnetViewComponents;

public class _CommentListByBlogComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _CommentListByBlogComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync(int id)
    {
        ViewBag.blogId = id;
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"https://localhost:7041/api/Comments/GetCommentsByBlogId?blogId=" + id);
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultGetCommentsByBlogIdDTO>>(jsonData);
            return View(values);
        }
        return View();
    }
}
