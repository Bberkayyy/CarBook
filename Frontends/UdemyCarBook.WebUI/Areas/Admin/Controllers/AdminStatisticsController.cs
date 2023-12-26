using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.DTOs.StatisticDTOs;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/AdminStatistics")]
public class AdminStatisticsController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AdminStatisticsController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    [Route("Index")]
    public async Task<IActionResult> Index()
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
        #region AuthorCountStatistic
        var responseMessageAuthorCount = await client.GetAsync("https://localhost:7041/api/Statistics/GetAuthorCount");
        if (responseMessageAuthorCount.IsSuccessStatusCode)
        {
            var jsonDataAuthorCount = await responseMessageAuthorCount.Content.ReadAsStringAsync();
            var valueAuthorCount = JsonConvert.DeserializeObject<ResultStatisticDTO>(jsonDataAuthorCount);
            ViewBag.AuthorCount = valueAuthorCount.AuthorCount;
        }
        #endregion
        #region BlogCountStatistic
        var responseMessageBlogCount = await client.GetAsync("https://localhost:7041/api/Statistics/GetBlogCount");
        if (responseMessageBlogCount.IsSuccessStatusCode)
        {
            var jsonDataBlogCount = await responseMessageBlogCount.Content.ReadAsStringAsync();
            var valueBlogCount = JsonConvert.DeserializeObject<ResultStatisticDTO>(jsonDataBlogCount);
            ViewBag.BlogCount = valueBlogCount.BlogCount;
        }
        #endregion#region BlogCountStatistic
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
        #region AverageRentPriceForWeeklyStatistic
        var responseMessageAverageRentPriceForWeekly = await client.GetAsync("https://localhost:7041/api/Statistics/GetAverageRentPriceForWeekly");
        if (responseMessageAverageRentPriceForWeekly.IsSuccessStatusCode)
        {
            var jsonDataAverageRentPriceForWeekly = await responseMessageAverageRentPriceForWeekly.Content.ReadAsStringAsync();
            var valueAverageRentPriceForWeekly = JsonConvert.DeserializeObject<ResultStatisticDTO>(jsonDataAverageRentPriceForWeekly);
            ViewBag.AverageRentPriceForWeekly = valueAverageRentPriceForWeekly.AverageRentPriceForWeekly.ToString("0.00");
        }
        #endregion
        #region AverageRentPriceForMonthlyStatistic
        var responseMessageAverageRentPriceForMonthly = await client.GetAsync("https://localhost:7041/api/Statistics/GetAverageRentPriceForMonthly");
        if (responseMessageAverageRentPriceForMonthly.IsSuccessStatusCode)
        {
            var jsonDataAverageRentPriceForMonthly = await responseMessageAverageRentPriceForMonthly.Content.ReadAsStringAsync();
            var valueAverageRentPriceForMonthly = JsonConvert.DeserializeObject<ResultStatisticDTO>(jsonDataAverageRentPriceForMonthly);
            ViewBag.AverageRentPriceForMonthly = valueAverageRentPriceForMonthly.AverageRentPriceForMonthly.ToString("0.00");
        }
        #endregion
        #region CarCountByTransmissionIsAutoStatistic
        var responseMessageCarCountByTransmissionIsAuto = await client.GetAsync("https://localhost:7041/api/Statistics/GetCarCountByTransmissionIsAuto");
        if (responseMessageCarCountByTransmissionIsAuto.IsSuccessStatusCode)
        {
            var jsonDataCarCountByTransmissionIsAuto = await responseMessageCarCountByTransmissionIsAuto.Content.ReadAsStringAsync();
            var valueCarCountByTransmissionIsAuto = JsonConvert.DeserializeObject<ResultStatisticDTO>(jsonDataCarCountByTransmissionIsAuto);
            ViewBag.CarCountByTransmissionIsAuto = valueCarCountByTransmissionIsAuto.CarCountByTransmissionIsAuto;
        }
        #endregion#region CarCountByTransmissionIsAutoStatistic
        #region CarCountByKmLessThen1000Statistic
        var responseMessageCarCountByKmLessThen1000 = await client.GetAsync("https://localhost:7041/api/Statistics/GetCarCountByKmLessThen1000");
        if (responseMessageCarCountByKmLessThen1000.IsSuccessStatusCode)
        {
            var jsonDataCarCountByKmLessThen1000 = await responseMessageCarCountByKmLessThen1000.Content.ReadAsStringAsync();
            var valueCarCountByKmLessThen1000 = JsonConvert.DeserializeObject<ResultStatisticDTO>(jsonDataCarCountByKmLessThen1000);
            ViewBag.CarCountByKmLessThen1000 = valueCarCountByKmLessThen1000.CarCountByKmLessThen1000;
        }
        #endregion
        #region CarCountByFuelGasolineOrDieselStatistic
        var responseMessageCarCountByFuelGasolineOrDiesel = await client.GetAsync("https://localhost:7041/api/Statistics/GetCarCountByFuelGasolineOrDiesel");
        if (responseMessageCarCountByFuelGasolineOrDiesel.IsSuccessStatusCode)
        {
            var jsonDataCarCountByFuelGasolineOrDiesel = await responseMessageCarCountByFuelGasolineOrDiesel.Content.ReadAsStringAsync();
            var valueCarCountByFuelGasolineOrDiesel = JsonConvert.DeserializeObject<ResultStatisticDTO>(jsonDataCarCountByFuelGasolineOrDiesel);
            ViewBag.CarCountByFuelGasolineOrDiesel = valueCarCountByFuelGasolineOrDiesel.CarCountByFuelGasolineOrDiesel;
        }
        #endregion#region CarCountByFuelGasolineOrDieselStatistic
        #region CarCountByFuelElectricStatistic
        var responseMessageCarCountByFuelElectric = await client.GetAsync("https://localhost:7041/api/Statistics/GetCarCountByFuelElectric");
        if (responseMessageCarCountByFuelElectric.IsSuccessStatusCode)
        {
            var jsonDataCarCountByFuelElectric = await responseMessageCarCountByFuelElectric.Content.ReadAsStringAsync();
            var valueCarCountByFuelElectric = JsonConvert.DeserializeObject<ResultStatisticDTO>(jsonDataCarCountByFuelElectric);
            ViewBag.CarCountByFuelElectric = valueCarCountByFuelElectric.CarCountByFuelElectric;
        }
        #endregion 
        #region BrandNameByMaxCarStatistic
        var responseMessageBrandNameByMaxCar = await client.GetAsync("https://localhost:7041/api/Statistics/GetBrandNameByMaxCar");
        if (responseMessageBrandNameByMaxCar.IsSuccessStatusCode)
        {
            var jsonDataBrandNameByMaxCar= await responseMessageBrandNameByMaxCar.Content.ReadAsStringAsync();
            var valueBrandNameByMaxCar = JsonConvert.DeserializeObject<ResultStatisticDTO>(jsonDataBrandNameByMaxCar);
            ViewBag.BrandNameByMaxCar = valueBrandNameByMaxCar.BrandNameByMaxCar;
        }
        #endregion
        #region CarBrandAndModelByRentPriceDailyMinStatistic
        var responseMessageCarBrandAndModelByRentPriceDailyMin = await client.GetAsync("https://localhost:7041/api/Statistics/GetCarBrandAndModelByRentPriceDailyMin");
        if (responseMessageCarBrandAndModelByRentPriceDailyMin.IsSuccessStatusCode)
        {
            var jsonDataCarBrandAndModelByRentPriceDailyMin = await responseMessageCarBrandAndModelByRentPriceDailyMin.Content.ReadAsStringAsync();
            var valueCarBrandAndModelByRentPriceDailyMin = JsonConvert.DeserializeObject<ResultStatisticDTO>(jsonDataCarBrandAndModelByRentPriceDailyMin);
            ViewBag.CarBrandAndModelByRentPriceDailyMin = valueCarBrandAndModelByRentPriceDailyMin.CarBrandAndModelByRentPriceDailyMin;
        }
        #endregion
        #region CarBrandAndModelByRentPriceDailyMaxStatistic
        var responseMessageCarBrandAndModelByRentPriceDailyMax = await client.GetAsync("https://localhost:7041/api/Statistics/GetCarBrandAndModelByRentPriceDailyMax");
        if (responseMessageCarBrandAndModelByRentPriceDailyMax.IsSuccessStatusCode)
        {
            var jsonDataCarBrandAndModelByRentPriceDailyMax = await responseMessageCarBrandAndModelByRentPriceDailyMax.Content.ReadAsStringAsync();
            var valueCarBrandAndModelByRentPriceDailyMax = JsonConvert.DeserializeObject<ResultStatisticDTO>(jsonDataCarBrandAndModelByRentPriceDailyMax);
            ViewBag.CarBrandAndModelByRentPriceDailyMax = valueCarBrandAndModelByRentPriceDailyMax.CarBrandAndModelByRentPriceDailyMax;
        }
        #endregion
        #region BlogTitleMaxBlogCommentStatistic
        var responseMessageBlogTitleMaxBlogComment = await client.GetAsync("https://localhost:7041/api/Statistics/GetBlogTitleMaxBlogComment");
        if (responseMessageBlogTitleMaxBlogComment.IsSuccessStatusCode)
        {
            var jsonDataBlogTitleMaxBlogComment = await responseMessageBlogTitleMaxBlogComment.Content.ReadAsStringAsync();
            var valueBlogTitleMaxBlogComment = JsonConvert.DeserializeObject<ResultStatisticDTO>(jsonDataBlogTitleMaxBlogComment);
            ViewBag.BlogTitleMaxBlogComment = valueBlogTitleMaxBlogComment.BlogTitleMaxBlogComment;
        }
        #endregion
        

        return View();
    }

}
