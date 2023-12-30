using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.DTOs.CarPricingDTOs;

namespace UdemyCarBook.WebUI.Controllers;

public class CarPricingController : Controller
{
	private readonly IHttpClientFactory _httpClientFactory;

	public CarPricingController(IHttpClientFactory httpClientFactory)
	{
		_httpClientFactory = httpClientFactory;
	}

	public async Task<IActionResult> Index()
	{
		ViewBag.v1 = "Fiyatlar";
		ViewBag.v2 = "Araç Fiyatları";
		var client = _httpClientFactory.CreateClient();
		var responseMessage = await client.GetAsync("https://localhost:7041/api/CarPricings/GetCarPricingWithTimePeriod");
		if (responseMessage.IsSuccessStatusCode)
		{
			var jsonData = await responseMessage.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<List<ResultCarPricingWithModelDTO>>(jsonData);
			return View(values);
		}
		return View();
	}
}
