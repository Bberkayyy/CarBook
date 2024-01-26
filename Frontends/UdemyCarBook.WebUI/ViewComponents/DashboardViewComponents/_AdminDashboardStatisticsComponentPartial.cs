using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.DTOs.StatisticDTOs;

namespace UdemyCarBook.WebUI.ViewComponents.DashboardViewComponents;

public class _AdminDashboardStatisticsComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _AdminDashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
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
        #region AverageRentPriceForDailyStatistic
        var responseMessageAverageRentPriceForDaily = await client.GetAsync("https://localhost:7041/api/Statistics/GetAverageRentPriceForDaily");
        if (responseMessageAverageRentPriceForDaily.IsSuccessStatusCode)
        {
            var jsonDataAverageRentPriceForDaily = await responseMessageAverageRentPriceForDaily.Content.ReadAsStringAsync();
            var valueAverageRentPriceForDaily = JsonConvert.DeserializeObject<ResultStatisticDTO>(jsonDataAverageRentPriceForDaily);
            ViewBag.AverageRentPriceForDaily = valueAverageRentPriceForDaily.AverageRentPriceForDaily.ToString("0.00");
        }
        #endregion#region AverageRentPriceForDailyStatistic  
        return View();
    }
}
