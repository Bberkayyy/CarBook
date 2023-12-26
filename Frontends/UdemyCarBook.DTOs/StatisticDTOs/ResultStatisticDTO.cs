using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.DTOs.StatisticDTOs;

public class ResultStatisticDTO
{
    public int CarCount { get; set; }
    public int LocationCount { get; set; }
    public int AuthorCount { get; set; }
    public string BlogTitleMaxBlogComment { get; set; }
    public string BrandNameByMaxCar { get; set; }
    public decimal AverageRentPriceForDaily { get; set; }
    public decimal AverageRentPriceForMonthly { get; set; }
    public decimal AverageRentPriceForWeekly { get; set; }
    public int BlogCount { get; set; }
    public int BrandCount { get; set; }
    public string CarBrandAndModelByRentPriceDailyMax { get; set; }
    public string CarBrandAndModelByRentPriceDailyMin { get; set; }
    public int CarCountByFuelElectric { get; set; }
    public int CarCountByFuelGasolineOrDiesel { get; set; }
    public int CarCountByKmLessThen1000 { get; set; }
    public int CarCountByTransmissionIsAuto { get; set; }
}
