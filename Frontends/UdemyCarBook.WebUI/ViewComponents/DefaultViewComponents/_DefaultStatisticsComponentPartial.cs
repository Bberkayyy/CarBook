using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.DTOs.StatisticDTOs;

namespace UdemyCarBook.WebUI.ViewComponents.DefaultViewComponents;

public class _DefaultStatisticsComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _DefaultStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();

        #region CarCountStatistic       
        var responseMessageCarCount = await client.GetAsync("https://localhost:7041/api/Statistics/GetCarCount");
        if (responseMessageCarCount.IsSuccessStatusCode)
        {
            var jsonDataCarCount = await responseMessageCarCount.Content.ReadAsStringAsync();
            var valueCarCount = JsonConvert.DeserializeObject<ResultStatisticDTO>(jsonDataCarCount);
            ViewBag.CarCount = valueCarCount.CarCount;
        }
        #endregion
        #region LocationCountStatistic
        var responseMessageLocationCount = await client.GetAsync("https://localhost:7041/api/Statistics/GetLocationCount");
        if (responseMessageLocationCount.IsSuccessStatusCode)
        {
            var jsonDataLocationCount = await responseMessageLocationCount.Content.ReadAsStringAsync();
            var valueLocationCount = JsonConvert.DeserializeObject<ResultStatisticDTO>(jsonDataLocationCount);
            ViewBag.LocationCount = valueLocationCount.LocationCount;
        }
        #endregion
        #region BrandCountStatistic
        var responseMessageBrandCount = await client.GetAsync("https://localhost:7041/api/Statistics/GetBrandCount");
        if (responseMessageBrandCount.IsSuccessStatusCode)
        {
            var jsonDataBrandCount = await responseMessageBrandCount.Content.ReadAsStringAsync();
            var valueBrandCount = JsonConvert.DeserializeObject<ResultStatisticDTO>(jsonDataBrandCount);
            ViewBag.BrandCount = valueBrandCount.BrandCount;
        }
        #endregion
        #region CarCountByFuelElectricStatistic
        var responseMessageCarCountByFuelElectric = await client.GetAsync("https://localhost:7041/api/Statistics/GetCarCountByFuelElectric");
        if (responseMessageCarCountByFuelElectric.IsSuccessStatusCode)
        {
            var jsonDataCarCountByFuelElectric = await responseMessageCarCountByFuelElectric.Content.ReadAsStringAsync();
            var valueCarCountByFuelElectric = JsonConvert.DeserializeObject<ResultStatisticDTO>(jsonDataCarCountByFuelElectric);
            ViewBag.CarCountByFuelElectric = valueCarCountByFuelElectric.CarCountByFuelElectric;
        }
        #endregion 
        return View();
    }
}
