using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Interfaces.StatisticsInterfaces;

public interface IStatisticRepository
{
    int GetCarCount();
    int GetLocationCount();
    int GetAuthorCount();
    int GetBlogCount();
    int GetBrandCount();
    decimal GetAverageRentPriceForDaily();
    decimal GetAverageRentPriceForWeekly();
    decimal GetAverageRentPriceForMonthly();
    int GetCarCountByTransmissionIsAuto();
    string GetBrandNameByMaxCar();
    string GetBlogTitleMaxBlogComment();
    int GetCarCountByKmLessThen1000();
    int GetCarCountByFuelGasolineOrDiesel();
    int GetCarCountByFuelElectric();
    string GetCarBrandAndModelByRentPriceDailyMin();
    string GetCarBrandAndModelByRentPriceDailyMax();
}
