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
				"(Select Model,PricingId,Amount From CarPricings Inner Join Cars On Cars.Id = CarPricings.CarId Inner Join Brands On Brands.Id=Cars.BrandId)" +
				" As SourceTable Pivot (Sum(Amount) For PricingId In([2],[3],[4])) as PivotTable;";
			command.CommandType = System.Data.CommandType.Text;
			_context.Database.OpenConnection();
			using (var reader = command.ExecuteReader())
			{
				while (reader.Read())
				{
					CarPricingViewModel carPricingViewModel = new CarPricingViewModel();
					Enumerable.Range(1, 3).ToList().ForEach(x =>
					{
						carPricingViewModel.Model = reader[0].ToString();
						if (DBNull.Value.Equals(reader[x]))
							carPricingViewModel.Amounts.Add(0);
						else
							carPricingViewModel.Amounts.Add(reader.GetDecimal(x));
					});
					values.Add(carPricingViewModel);
				}
			}
			_context.Database.CloseConnection();
			return values;
		}
	}
}
