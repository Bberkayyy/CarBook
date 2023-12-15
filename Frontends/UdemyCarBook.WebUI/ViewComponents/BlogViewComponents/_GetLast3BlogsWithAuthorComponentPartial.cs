using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.DTOs.BlogDTOs;


namespace UdemyCarBook.WebUI.ViewComponents.BlogViewComponents;

public class _GetLast3BlogsWithAuthorComponentPartial:ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _GetLast3BlogsWithAuthorComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7041/api/Blogs/GetLast3BlogsWithAuthors");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultLast3BlogsWithAuthorDTO>>(jsonData);
            return View(values);
        }
        return View();
    }
}
