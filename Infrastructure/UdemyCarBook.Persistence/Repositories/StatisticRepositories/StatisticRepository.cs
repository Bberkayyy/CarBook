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
        var values = _context
    .Comments
    .GroupBy(x => x.BlogId)
    .Select(x => new
    {
        BlogId = x.Key,
        Count = x.Count()
    })
    .OrderByDescending(x => x.Count)
    .Take(1)
    .FirstOrDefault();
        var blogTitle= _context.Blogs.Where(x => x.Id == values.BlogId).Select(x => x.Title).FirstOrDefault();
        return blogTitle;
    }

    public string GetBrandNameByMaxCar()
    {
        var values = _context
            .Cars
            .GroupBy(x => x.BrandId)
            .Select(x => new
            {
                BrandId = x.Key,
                Count = x.Count()
            })
            .OrderByDescending(x => x.Count)
            .Take(1)
            .FirstOrDefault();
        var brandName = _context.Brands.Where(x => x.Id == values.BrandId).Select(x => x.Name).FirstOrDefault();
        return brandName;
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
        var pricingId = _context.Pricings.Where(x => x.Name == "Günlük").Select(x => x.Id).FirstOrDefault();
        var amount = _context.CarPricings.Where(x => x.PricingId == 2).Max(x => x.Amount);
        var carId = _context.CarPricings.Where(x => x.Amount == amount).Select(x => x.CarId).FirstOrDefault();
        var brandModel = _context.Cars.Where(x => x.Id == carId).Include(x => x.Brand).Select(x => x.Brand.Name + " " + x.Model).FirstOrDefault();
        return brandModel;
    }

    public string GetCarBrandAndModelByRentPriceDailyMin()
    {
        var pricingId = _context.Pricings.Where(x => x.Name == "Günlük").Select(x => x.Id).FirstOrDefault();
        var amount = _context.CarPricings.Where(x => x.PricingId == 2).Min(x => x.Amount);
        var carId = _context.CarPricings.Where(x => x.Amount == amount).Select(x => x.CarId).FirstOrDefault();
        var brandModel = _context.Cars.Where(x => x.Id == carId).Include(x => x.Brand).Select(x => x.Brand.Name + " " + x.Model).FirstOrDefault();
        return brandModel;
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
