using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.DTOs.BlogDTOs;

namespace UdemyCarBook.WebUI.Controllers;

public class BlogController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public BlogController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.v1 = "Bloglar";
        ViewBag.v2 = "Yazarlarımızın Blogları";
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7041/api/Blogs/GetAllBlogsWithAuthors");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultAllBlogsWithAuthorDTO>>(jsonData);
            return View(values);
        }
        return View();
    }
    public async Task<IActionResult> BlogDetail(int id)
    {
        ViewBag.v1 = "Bloglar";
        ViewBag.v2 = "Blog Detayı ve Yorumlar";
        ViewBag.blogId = id;
        var client = _httpClientFactory.CreateClient();
        var responseMessageCommentCountByBlog = await client.GetAsync($"https://localhost:7041/api/Comments/GetCommentCountByBlog?blogId={id}");
        if (responseMessageCommentCountByBlog.IsSuccessStatusCode)
        {
            var jsonDataCommentCountByBlog = await responseMessageCommentCountByBlog.Content.ReadAsStringAsync();
            ViewBag.CommentCountByBlog = jsonDataCommentCountByBlog;
        }
        return View();
    }
}
