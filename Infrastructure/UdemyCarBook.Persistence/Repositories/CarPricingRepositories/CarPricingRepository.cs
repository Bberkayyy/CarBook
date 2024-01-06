using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.CarPricingInterfaces;
using UdemyCarBook.Application.ViewModels;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.CarPricingRepositories;

public class CarPricingRepository : ICarPricingRepository
{
    private readonly CarBookContext _context;

    public CarPricingRepository(CarBookContext context)
    {
        _context = context;
    }

    public List<CarPricing> GetCarPricingWithCars()
    {
        var values = _context
            .CarPricings
            .Include(x => x.Car)
            .ThenInclude(x => x.Brand)
            .Include(x => x.Pricing)
            .Where(x => x.PricingId == 2)
            .ToList();
        return values;
    }

    public List<CarPricingViewModel> GetCarPricingWithTimePeriod()
    {
        List<CarPricingViewModel> values = new List<CarPricingViewModel>();
        using (var command = _context.Database.GetDbConnection().CreateCommand())
        {
            command.CommandText = "Select * From " +
                "(Select Brands.Name,Model,CoverImageUrl,PricingId,Amount From CarPricings Inner Join Cars On Cars.Id = CarPricings.CarId Inner Join Brands On Brands.Id=Cars.BrandId)" +
                " As SourceTable Pivot (Sum(Amount) For PricingId In([2],[3],[4])) as PivotTable;";
            command.CommandType = System.Data.CommandType.Text;
            _context.Database.OpenConnection();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    CarPricingViewModel carPricingViewModel = new CarPricingViewModel()
                    {
                        Model = reader["Model"].ToString(),
                        BrandName = reader["Name"].ToString(),
                        CoverImageUrl = reader["CoverImageUrl"].ToString(),
                        Amounts = new List<decimal>
                        {
                            Convert.ToDecimal(reader[3]),
                            Convert.ToDecimal(reader[4]),
                            Convert.ToDecimal(reader[5]),
                        }
                    };
                    values.Add(carPricingViewModel);
                }
            }
            _context.Database.CloseConnection();
            return values;
        }
    }
}