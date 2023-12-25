using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.StatisticsInterfaces;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.StatisticRepositories;

public class StatisticRepository : IStatisticRepository
{
    public readonly CarBookContext _context;

    public StatisticRepository(CarBookContext context)
    {
        _context = context;
    }

    public string GetBlogTitleMaxBlogComment()
    {
        throw new NotImplementedException();
    }

    public string GetBrandNameByMaxCar()
    {
        throw new NotImplementedException();
    }

    public int GetAuthorCount()
    {
        return _context
            .Authors
            .Count();
    }

    public decimal GetAverageRentPriceForDaily()
    {
        var pricingId = _context.Pricings.Where(x => x.Name == "Günlük").Select(x => x.Id).FirstOrDefault();
        var value = _context
            .CarPricings
            .Where(x => x.PricingId == pricingId)
            .Average(x => x.Amount);
        return value;
    }

    public decimal GetAverageRentPriceForMonthly()
    {
        var pricingId = _context.Pricings.Where(x => x.Name == "Aylık").Select(x => x.Id).FirstOrDefault();
        var value = _context
            .CarPricings
            .Where(x => x.PricingId == pricingId)
            .Average(x => x.Amount);
        return value;
    }

    public decimal GetAverageRentPriceForWeekly()
    {
        var pricingId = _context.Pricings.Where(x => x.Name == "Haftalık").Select(x => x.Id).FirstOrDefault();
        var value = _context
            .CarPricings
            .Where(x => x.PricingId == pricingId)
            .Average(x => x.Amount);
        return value;
    }

    public int GetBlogCount()
    {
        return _context
            .Authors
            .Count();
    }

    public int GetBrandCount()
    {
        return _context
            .Brands
            .Count();
    }

    public string GetCarBrandAndModelByRentPriceDailyMax()
    {
        throw new NotImplementedException();
    }

    public string GetCarBrandAndModelByRentPriceDailyMin()
    {
        throw new NotImplementedException();
    }

    public int GetCarCount()
    {
        return _context
             .Cars
             .Count();
    }

    public int GetCarCountByFuelElectric()
    {
        return _context.Cars.Where(x => x.Fuel == "Elektrik").Count();
    }

    public int GetCarCountByFuelGasolineOrDiesel()
    {
        return _context.Cars.Where(x => x.Fuel == "Benzin" || x.Fuel == "Dizel").Count();
    }

    public int GetCarCountByKmLessThen1000()
    {
        return _context.Cars.Where(x => x.Km <= 1000).Count();
    }

    public int GetCarCountByTransmissionIsAuto()
    {
        return _context.Cars.Where(x => x.Transmission == "Otomatik").Count();
    }

    public int GetLocationCount()
    {
        return _context
            .Locations
            .Count();
    }
}
