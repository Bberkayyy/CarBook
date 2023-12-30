using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using UdemyCarBook.Application.Features.Mediator.Results.CarPricingResults;
using UdemyCarBook.Application.Interfaces.CarPricingInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.CarPricingHandlers.Read;

public class GetCarPricingWithTimePeriodQueryHandler : IRequestHandler<GetCarPricingWithTimePeriodQuery, List<GetCarPricingWithTimePeriodQueryResult>>
{
	private readonly ICarPricingRepository _carPricingRepository;

	public GetCarPricingWithTimePeriodQueryHandler(ICarPricingRepository carPricingRepository)
	{
		_carPricingRepository = carPricingRepository;
	}

	public async Task<List<GetCarPricingWithTimePeriodQueryResult>> Handle(GetCarPricingWithTimePeriodQuery request, CancellationToken cancellationToken)
	{
		var values = _carPricingRepository.GetCarPricingWithTimePeriod();
		return values.Select(x => new GetCarPricingWithTimePeriodQueryResult
		{
			Model = x.Model,
			DailyAmount = x.Amounts[0],
			WeeklyAmount = x.Amounts[1],
			MonthlyAmount = x.Amounts[2],
		}).ToList();
	}
}
